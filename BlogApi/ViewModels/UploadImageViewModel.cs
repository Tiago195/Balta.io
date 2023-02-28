using System.ComponentModel.DataAnnotations;

namespace BlogApi.ViewModels;

public class UploadImageViewModel
{
  [Required(ErrorMessage = "base64 obrigatoria")]
  public string Base64Image { get; set; }
}