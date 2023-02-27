using System.ComponentModel.DataAnnotations;

namespace BlogApi.ViewModels;

public class LoginViewModel
{
  [Required(ErrorMessage = "O E-mail é obrigatório")]
  [EmailAddress(ErrorMessage = "O E-mail é inválido")]
  public string Email { get; set; }

  [Required(ErrorMessage = "A Senha é obrigatória")]
  public string Password { get; set; }
}