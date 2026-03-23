using Clinic.Test.Utils;
using Clinic.Domain.Entities;

namespace Clinic.Test.Domain;

public class PhoneTest_Valid
    : BaseTest<string>
{
    [Theory]
    [InlineData("+13065551234", "+13065551234")]
    [InlineData("13065551234", "+13065551234")]
    [InlineData("(306) 555-1234", "+3065551234")]
    [InlineData("+1-306-555-1234", "+13065551234")]
    [InlineData("  306 555 1234  ", "+3065551234")]
    public void Create_ShouldReturnNormalizedPhone(string input, string expected)
        => RunTest(() => Phone.Create(input).Value, expected);
}
public class PhoneTest_Invalid
    : BaseTestException
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("123")]                  // too short
    [InlineData("000000000")]            // invalid leading
    [InlineData("+1234567890123456")]    // too long (>15)
    [InlineData("abc-def-ghij")]         // no digits
    public void Create_ShouldThrowArgumentException(string input)
        => RunExceptionTest<ArgumentException>(() => Phone.Create(input));
}