using System.ComponentModel.DataAnnotations;

public class LoginViewModelInput
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Senha { get; set; }
}
