using System.ComponentModel.DataAnnotations;

namespace BlogApi.ViewModels.Accounts;

public class UploadImageViewModel
{
  [Required(ErrorMessage = "base64 obrigatoria")]
  public string Base64Image { get; set; }
}