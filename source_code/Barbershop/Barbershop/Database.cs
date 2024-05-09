using Barbershop.Model.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace Barbershop;
public class RoleTypes
{
    public const string Client = "Client";
    public const string Master = "Master";
    public const string Admin = "Admin";
}
public class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Master> Masters { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<MasterService> MasterServices { get; set; }
    public DbSet<RenderedService> RenderedServices { get; set; }
    public DbSet<Shift> Shifts { get; set; }
    
    public DatabaseContext(bool truncate = false)
    {
        if (truncate)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        else
            Database.EnsureCreated();

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
    public async Task AddUserClient(RegisterViewModel RegisterModel)
    {
        var addedUser = Users.Add(new User()
        {
            Name = RegisterModel.Name,
            Surname = RegisterModel.Surname,
            Lastname = RegisterModel.Lastname,
            Password = RegisterModel.Password,
            Email = RegisterModel.Email,
            PhoneNumber = RegisterModel.PhoneNumber,
            Role = RoleTypes.Client
        });
        await SaveChangesAsync();
        Clients.Add(new Client()
        {
            User = Users.Single(user => user.Id == addedUser.Entity.Id),
            Sex = RegisterModel.Sex,
            BonusBalance = 0
        });
        await SaveChangesAsync();
    }
    public async Task AddUserMaster(RegisterMasterViewModel RegisterModel)
    {
        var addedUser = Users.Add(new User()
        {
            Name = RegisterModel.Name,
            Surname = RegisterModel.Surname,
            Lastname = RegisterModel.Lastname,
            Password = RegisterModel.Password,
            Email = RegisterModel.Email,
            PhoneNumber = RegisterModel.PhoneNumber,
            Role = RoleTypes.Master
        });
        await SaveChangesAsync();
        Masters.Add(new Master()
        {
            User = Users.Single(user => user.Id == addedUser.Entity.Id),
            Skill = RegisterModel.Skill
        });
        await SaveChangesAsync();
    }
    public async Task addRenderedService(ApplyServiceViewModel applyViewModel)
    {
        // check if User is Client
        if (applyViewModel.AuthorizedUser.Role != RoleTypes.Client) return;
        if (!Clients.Any(client => client.User.Id == applyViewModel.AuthorizedUser.Id)) return;
        Client? userClient = Clients.Where(client => client.User.Id == applyViewModel.AuthorizedUser.Id).FirstOrDefault();
        Master? serviceMaster = Masters.Where(master => master.Id == applyViewModel.SelectedMasterId).SingleOrDefault();
        if (userClient == null) return;
        if (serviceMaster == null) return;

        decimal totalPrice = applyViewModel.SelectedService.PriceRubles - userClient.BonusBalance;
        if (totalPrice < 0)
        {
            userClient.BonusBalance = -totalPrice;
            totalPrice = 0;
        }
        else
        {
            userClient.BonusBalance = 0;
        }
        RenderedServices.Add(new()
        {
            Client = userClient,
            IsComplete = false,
            Mark = 0,
            Master = serviceMaster,
            Service = Services.Where(service => service.Id == applyViewModel.SelectedService.Id).First(),
            Timestamp = DateTime.SpecifyKind(DateTime.Parse(applyViewModel.SelectedDateString), DateTimeKind.Utc)
            .AddHours(applyViewModel.SelectedHour),
            TotalPriceRubles = totalPrice
        });
        SaveChanges();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Barbershop;Username=postgres;Password=postgres");
    }
}
public class User
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Lastname {  get; set; }
    public string Role { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string? AuthToken { get; set; }
    public ICollection<Master> Masters { get; set; } = [];
    public ICollection<Client> Clients { get; set; } = [];

}
public class Client
{
    [Key]
    public int Id { get; set; }
    public User User { get; set; }
    public string Sex { get; set; }
    public decimal BonusBalance { get; set; }
    public ICollection<RenderedService> RenderedServices { get; set; } = [];
}
public class Master
{
    [Key]
    public int Id { get; set; }
    public User User { get; set; }
    public string Skill { get; set; }
    public ICollection<RenderedService> RenderedServices { get; set; } = [];
    public ICollection<MasterService> MasterServices { get; set; } = [];
    public ICollection<Shift> Shifts { get; set; } = [];

}

public class Service
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal PriceRubles { get; set; }
    public string Sex { get; set; }
    public string ImageHref { get; set; }
    public string Description { get; set; }
    public ICollection<MasterService> MasterServices { get; set; } = [];
}

public class MasterService
{
    [Key]
    public int Id { get; set; } 
    public Master Master { get; set; }
    public Service Service { get; set; }
}

public class RenderedService
{
    [Key]
    public int Id { get; set; }
    public decimal TotalPriceRubles { get; set; }
    public int Mark { get; set; }
    public DateTime Timestamp { get; set; }
    public Client Client { get; set; }
    public Master Master { get; set; }
    public Service Service { get; set; }
    public bool IsComplete { get; set; } = false;
}

public class Shift
{
    [Key]
    public int Id { get; set; }
    public Master Master { get; set; }
    public DateTime Timestamp { get; set; }
}

