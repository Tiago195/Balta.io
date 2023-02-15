using System.ComponentModel.DataAnnotations;

namespace BlogApi.ViewModels;

public class EditorCategoryViewModel
{
  [Required(ErrorMessage = "Name obrigatorio.")]
  [StringLength(40, MinimumLength = 2, ErrorMessage = "Name deve conter entre 2 e 40 caracteres.")]
  public string Name { get; set; }

  [Required(ErrorMessage = "Slug obrigatorio.")]
  public string Slug { get; set; }
}