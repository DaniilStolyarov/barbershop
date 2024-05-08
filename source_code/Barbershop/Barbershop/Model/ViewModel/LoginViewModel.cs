using System.ComponentModel.DataAnnotations;

namespace Barbershop.Model.ViewModel;

public class LoginViewModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Это поле обязательно")]
    public string Email { get; set; } = "";
    [Required(AllowEmptyStrings = false, ErrorMessage = "Это поле обязательно")]
    public string Password { get; set; } = "";
}
