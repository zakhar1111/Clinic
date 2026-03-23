namespace Clinic.Test.Utils;

public abstract class BaseTest<T>
{
    protected void RunTest(Func<T> action, T expected)
    {
        var result = action();
        Assert.Equal(expected, result);
    }
}

public abstract class BaseTestException
{
    protected void RunExceptionTest<TException>(Action action)
        where TException : Exception
    {
        Assert.Throws<TException>(action);
    }
}
public abstract class BaseTestInput<TInput, TResult>
{
    protected void RunTest(Func<TInput, TResult> action, TInput input, TResult expected)
    {
        var result = action(input);
        Assert.Equal(expected, result);
    }
}