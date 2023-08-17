using E470CodeChallenge.Attributes;

namespace E470CodeChallenge.Tests.Attributes
{
    public class ValidateYearAttributeTest
    {
        private readonly ValidateYearAttribute _attribute = new();

        [Theory]
        [InlineData("2000")]
        [InlineData("2001")]
        [InlineData("1950")]
        [InlineData("1995")]
        [InlineData(null)]
        public void Year_Is_Valid(string year) =>
            Assert.True(_attribute.IsValid(year));


        [Theory]
        [InlineData("!)!")]
        [InlineData("20")]
        [InlineData("ABC")]
        [InlineData("2091")]
        [InlineData("1500")]
        [InlineData("-2342")]
        [InlineData("")]
        [InlineData("   ")]
        public void Year_Is_Invalid(string year) =>
            Assert.True(!_attribute.IsValid(year));

    }
}
