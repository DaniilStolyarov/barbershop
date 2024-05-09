using Barbershop.Components.Pages;
using Barbershop.Model.ViewModel;
using Blazorise;
using Blazorise.DeepCloner;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Security.Cryptography;

namespace Barbershop.Model.Entity;

/* 
    This service provides Login() and Logout() to manage auth_token in localStorage.
    Additionally, it provides AuthorizedUser getter with actual user data.
    If some problem occurs while fetching data, the Logout() method will be called,
        erasing all client data and redirecting to the home page.
    The purpose of this is to ensure that user has rights to a content.

    Note that this service may be utilized after OnAfterRender (because of JsInterop)

    Furthermore, the service provides CachedUser object for UI purposes
        to not access the Database too many times.
 */

public interface IAuthorizationService
{
    public Task<User?> GetAuthorizedUser();
    public User? CachedUser { get; }
    public Task Login(LoginViewModel loginData, string attemptedPage = "/home");
    public Task Logout();
    public delegate void NotifyUserLoggedIn();
    public event NotifyUserLoggedIn OnUserLoggedIn;
    public delegate void NotifyUserLoggedOut();
    public event NotifyUserLoggedOut OnUserLoggedOut;
}

public class AuthorizationService : IAuthorizationService
{
    IAuthorizationService.NotifyUserLoggedIn notifyLoggedIn;
    IAuthorizationService.NotifyUserLoggedOut notifyLoggedOut;

    /// <summary>
    /// Last User fetched object, with Password and AuthToken null
    /// </summary>
    public User? CachedUser { get
        {
            return cachedUser;
        } }
    private User? cachedUser;
    public async Task<User?> GetAuthorizedUser()
    {
       
       using (var db = new DatabaseContext())
       {
            string? authToken = await localStorage.GetItemAsync<string>("auth_token");
            if (authToken == null)
            {
                await Logout();
                return null;
            }

            User? rowUser = db.Users.Where(user => user.AuthToken == authToken).FirstOrDefault().DeepClone();
            if (rowUser == null)
            {
                await Logout();

                return null;

            }
            // not copying the AuthToken and Password, because CachedUser is for Displaying purposes
            cachedUser = new() 
            { 
                Name = rowUser.Name,
                Surname = rowUser.Surname,
                Lastname = rowUser.Lastname,
                PhoneNumber = rowUser.PhoneNumber,
                Role = rowUser.Role,
                Email = rowUser.Email,
                Password = "",
                AuthToken = null
            };
            notifyLoggedIn();
            return rowUser;
       }
    }
    private readonly Blazored.LocalStorage.ILocalStorageService localStorage;
    private readonly NavigationManager navigation;

    public AuthorizationService(
        Blazored.LocalStorage.ILocalStorageService localStorage,
        NavigationManager navigation
        )
    {
        // Dependency Injection
        this.localStorage = localStorage;
        this.navigation = navigation;
    }

    

    public async Task Logout()
    {
        await localStorage.ClearAsync();
        cachedUser = null;
        notifyLoggedOut();
        return;
    }
    public async Task Login(LoginViewModel loginData, string attemptedPage = "/home")
    {
        using (var db = new DatabaseContext())
        {
            User? userRow = db.Users.Where(user => user.Email == loginData.Email && user.Password == loginData.Password).FirstOrDefault();
            if (userRow == null)
            {
                throw new Exception("Неправильный логин или пароль");
            }
            string authTokenToAssign = GetUniqueBase64();
            userRow.AuthToken = authTokenToAssign;
            await db.SaveChangesAsync();

            await localStorage.SetItemAsync("auth_token", authTokenToAssign);
            navigation.NavigateTo(attemptedPage);
        }
    }
    private string GenerateKey()
    {
        byte[] key = new byte[32];
        RandomNumberGenerator.Fill(key);
        return Convert.ToBase64String(key);
    }

    private string GetUniqueBase64()
    {
        string base64;
        using (var db = new DatabaseContext())
        {
            do
            {
                base64 = GenerateKey();
            } while (db.Users.Any(user => user.AuthToken == base64));
        }
        return base64;
    }

    event IAuthorizationService.NotifyUserLoggedIn IAuthorizationService.OnUserLoggedIn
    {
        add
        {
            notifyLoggedIn += value;
        }

        remove
        {
            notifyLoggedIn -= value;
        }
    }

    event IAuthorizationService.NotifyUserLoggedOut IAuthorizationService.OnUserLoggedOut
    {
        add
        {
            notifyLoggedOut += value;
        }

        remove
        {
            notifyLoggedOut -= value;
        }
    }
}
