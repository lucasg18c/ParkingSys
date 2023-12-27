namespace ParkingSys.API.Abstractions.Results;

public class Result<T> : Result
{
    protected Result(T value, bool isSuccess, Error error) : base(isSuccess, error) 
    {
        Value = value;
    }

    public T Value { get; }

    public static Result<T> Success(T value) => new(value, true, Error.None);
    new public static Result<T> Fail(Error error) => new(default!, false, error);
}

public class Result
{
    protected Result(bool isSuccess, Error error)
    {
        if ((isSuccess && error != Error.None) || (!isSuccess && error == Error.None))
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    public static Result Success() => new(true, Error.None);
    public static Result Fail(Error error) => new(false, error);
}
