using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BlogApi.Extensions;

public static class ModelStateExtension
{
  public static List<string> GetErrors(this ModelStateDictionary state)
  {
    var result = new List<string>();
    foreach (var item in state.Values) result.AddRange(item.Errors.Select(x => x.ErrorMessage));

    return result;
  }
}