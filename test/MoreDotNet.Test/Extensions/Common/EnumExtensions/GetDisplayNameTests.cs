namespace MoreDotNet.Test.Extensions.Common.EnumExtensions
{
    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class GetDisplayNameTests
    {
        private enum TestEnum
        {
            Default = 0,
            One = 1,
            Two = 2
        }

        [Fact]
        public void GetDisplayName__GivenTestEnum_ShouldReturnEnumNameString()
        {
            string expected = "Default";
            TestEnum testEnum = TestEnum.Default;

            string enumName = testEnum.GetDisplayName();

            Assert.Equal(enumName, expected);
        }

        [Fact]
        public void GetDescription_GivenInvalidTestEnumValue_ShouldReturnStringValue()
        {
            string expected = "4";
            int value = 4;

            string result = ((TestEnum)value).GetDescription();

            Assert.Equal(expected, result);
        }
    }
}
