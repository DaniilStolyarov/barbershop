using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Barbershop.Model.ViewModel;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Это поле обязательно")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Это поле обязательно")]
    public string Surname { get; set; }
    [Required(ErrorMessage = "Это поле обязательно")]
    public string Lastname { get; set; }
    [Required(ErrorMessage = "Это поле обязательно")]
    [MinLength(8, ErrorMessage = "Пароль слишком короткий")]
    [MaxLength(32, ErrorMessage = "Пароль слишком длинный")]
    public string Password { get; set; }
    [Required(ErrorMessage = "Это поле обязательно")]
    [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают")]
    public string PasswordConfirm { get; set; }
    [Required(ErrorMessage = "Это поле обязательно")]
    [EmailAddress(ErrorMessage = "Неправильный формат электронной почты")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Это поле обязательно")]
    [Phone(ErrorMessage = "Неправильный формат телефона")]
    [MinLength(11, ErrorMessage="Номер должен быть 11-значным")]
    [MaxLength(11, ErrorMessage = "Номер должен быть 11-значным")]
    public string PhoneNumber { get; set; }
    [Required(ErrorMessage = "Это поле обязательно")]
    [SexAttribute]
    public string Sex { get; set; } = "Мужской";
}

public class RegisterMasterViewModel : RegisterViewModel
{
    public string Skill { get; set; } = "Junior";
}
public sealed class SexAttribute : ValidationAttribute
{

    public override bool IsValid(object value)
    {
        var stringValue = value.ToString();
        if (stringValue == "Мужской" || stringValue == "Женский")
        {
            return true;
        }
        return false;
    }

    public SexAttribute()
    {
    }
}