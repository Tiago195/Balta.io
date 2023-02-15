namespace BlogApi.ViewModels;

public class ResultViewMode<T>
{
  public T Data { get; private set; }
  public List<string>? Errors { get; private set; }


  public ResultViewMode(string error) => Errors = new List<string> { error };
  public ResultViewMode(List<string> errors) => Errors = errors;
  public ResultViewMode(T data) => Data = data;
  public ResultViewMode(T data, List<string> errors)
  {
    Data = data;
    Errors = errors;
  }
}