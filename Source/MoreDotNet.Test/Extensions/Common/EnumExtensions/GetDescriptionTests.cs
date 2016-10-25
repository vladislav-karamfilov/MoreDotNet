namespace MoreDotNet.Tests.Extensions.Common.EnumExtensions
{
    using System;
    using System.ComponentModel;
    using MoreDotNet.Extensions.Common;
    using Xunit;

    public class GetDescriptionTests
    {
        private enum TestEnumWithDescription
        {
            [Description("This is the default value.")]
            Default = 0,
            [Description("This is the second value")]
            One = 1,
            [Description("This is the third value")]
            Two = 2
        }

        private enum TestEnumWithoutDescription
        {
            Default = 0,
            One = 1,
            Two = 2
        }

        [Fact]
        public void GetDescription_GivenTestEnumWithDescription_ShouldReturnEnumDescriptionString()
        {
            string expected = "This is the default value.";
            TestEnumWithDescription testEnum = TestEnumWithDescription.Default;

            string enumDescription = testEnum.GetDescription();

            Assert.Equal(enumDescription, expected);
        }

        [Fact]
        public void GetDescription_GivenTestEnumWithoutDescription_ShouldReturnToStringMethodValue()
        {
            string expected = TestEnumWithoutDescription.Default.ToString();
            TestEnumWithoutDescription testEnum = TestEnumWithoutDescription.Default;

            string enumDescription = testEnum.GetDescription();

            Assert.Equal(enumDescription, expected);
        }

        [Fact]
        public void GetDescription_GivenInvalidTestEnumValue_ShouldReturnToStringMethodValue()
        {
            string expected = "4";
            int value = 4;

            string result = ((TestEnumWithoutDescription)value).GetDescription();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetDescription_GivenInvalidEnumType_ShouldThrowException()
        {
            TestStruct structTest = default(TestStruct);

            Assert.Throws<ArgumentException>(() => structTest.GetDescription());
        }

        private struct TestStruct
        {
            private int value;
            private string name;

            public TestStruct(int number, string key)
            {
                this.value = number;
                this.name = key;
            }
        }
    }
}
