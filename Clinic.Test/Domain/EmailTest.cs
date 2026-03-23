using Clinic.Test.Utils;
using Clinic.Domain.Entities;

namespace Clinic.Test.Domain;

public class EmailTest
    : BaseTest<string>
{
    [Theory]
    [InlineData("test@example.com", "test@example.com")]
    [InlineData("  TEST@Example.COM  ", "test@example.com")]
    [InlineData("user+tag@gmail.com", "user+tag@gmail.com")]
    public void Create_ShouldReturnNormalizedEmail(string input, string expected)
        => RunTest(() => Email.Create(input).Value, expected);
}

public class Email_Create_Invalid
    : BaseTestException
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("plainaddress")]
    [InlineData("@no-local-part.com")]
    [InlineData("user@.com")]
    [InlineData("user@domain")]
    [InlineData("user@domain..com")]
    [InlineData("user@@domain.com")]
    public void Create_ShouldThrowArgumentException(string input)
        => RunExceptionTest<ArgumentException>(() => Email.Create(input));
}
