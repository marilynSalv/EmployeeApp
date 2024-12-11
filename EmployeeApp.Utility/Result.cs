namespace EmployeeApp.Utility;

public class Result
{
    public bool Success { get; set; }
    public string Error { get; }
    public bool IsFailure => !Success;

    protected Result(bool success, string error)
    {
        if(success && error != string.Empty)
        {
            throw new InvalidOperationException();
        }

        if(!success && error == string.Empty) 
        {
            throw new InvalidOperationException();
        }

        Success = success;
        Error = error;
    }

    public static Result Fail(string message)
    {
        return new Result(false, message);
    }

    public static Result<T> Fail<T>(string message)
    {
        return new Result<T>(default, false, message);
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
}