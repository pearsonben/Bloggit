namespace Bloggit.Services;

public class Result<T> where T: class
{
    public bool IsSuccess { get; private set; } = true;
    public List<string>? Errors { get; private set; }
    public T? ResponseData { get; private set; }
    
    public static Result<T> Success(T responseData) => new Result<T> { IsSuccess = true, ResponseData = responseData, Errors = null };
    public static Result<T> Failure(List<string> errors) => new Result<T> { IsSuccess = false, Errors = errors };
    public static Result<T> Failure(string error) => new Result<T> { IsSuccess = false, Errors = [error] };
}