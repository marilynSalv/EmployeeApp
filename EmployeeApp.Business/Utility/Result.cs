namespace EmployeeApp.Application.Utility;

public class Result
{
    public bool Success { get; }

    public bool IsFailure => !Success;

    public IEnumerable<string> Errors { get; }

    //public HttpStatusCode StatusCode { get; }

    protected Result(bool success, string error)
    {
        if(success && error != string.Empty)
        {
            throw new InvalidOperationException("A successful result cannot contain an error.");
        }

        if (!success && error == string.Empty) 
        {
            throw new InvalidOperationException("A failed result must contain an error message.");
        }

        Success = success;
        Errors = [error];
    }

    protected Result(bool success, IEnumerable<string> errors)
    {
        if (success && errors.Any(e => !string.IsNullOrWhiteSpace(e)))
        {
            throw new InvalidOperationException("A successful result cannot contain errors.");
        }

        if (!success && !errors.Any(e => !string.IsNullOrWhiteSpace(e)))
        {
            throw new InvalidOperationException("A failed result must contain at least one error message.");
        }

        Success = success;
        Errors = errors;
    }

    public static Result Fail(string message)
    {
        return new Result(false, message);
    }

    public static Result<T> Fail<T>(string message)
    {
        return new Result<T>(default, false, message);
    }

    public static Result Fail(IEnumerable<string> messages)
    {
        return new Result(false, messages);
    }

    public static Result<T> Fail<T>(IEnumerable<string> messages)
    {
        return new Result<T>(default, false, messages);
    }

    public static Result Ok()
    {
        return new Result(true, string.Empty);
    }

    public static Result<T> Ok<T>(T value)
    {
        return new Result<T>(value, true, string.Empty);
    }
}

public class Result<T> : Result
{
    public T Value { get; set; }

    // The type or member can be accessed by any code in the assembly in which it's declared, or from within a derived class in another assembly.
    protected internal Result (T value, bool success, string error)
        : base(success, error)
    {
        Value = value;
    }

    protected internal Result(T value, bool success, IEnumerable<string> errors)
    : base(success, errors)
    {
        Value = value;
    }
}