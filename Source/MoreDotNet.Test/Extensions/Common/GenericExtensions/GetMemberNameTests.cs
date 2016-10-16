namespace MoreDotNet.Tests.Extensions.Common.GenericExtensions
{
    using System;
    using MoreDotNet.Extensions.Common;
    using Xunit;

    public class GetMemberNameTests
    {
        [Fact]
        public void WhenPropertyOfClass_ShouldReturnCorrectName()
        {
            var testClass = new TestClass();
            Assert.Equal("Property", testClass.GetMemberName(obj => obj.Property));
        }

        [Fact]
        public void WhenFieldOfClass_ShouldReturnCorrectName()
        {
            var testClass = new TestClass();
            Assert.Equal("Field", testClass.GetMemberName(obj => obj.Field));
        }

        [Fact]
        public void WhenNestedFieldOfClass_ShouldReturnCorrectName()
        {
            var testClass = new TestClass();
            Assert.Equal("Field", testClass.GetMemberName(obj => obj.Property.Field));
        }

        [Fact]
        public void WhenPropertyOfStruct_ShouldReturnCorrectName()
        {
            var testStruct = new TestStruct();
            Assert.Equal("Property", testStruct.GetMemberName(obj => obj.Property));
        }

        [Fact]
        public void WhenFieldOStruct_ShouldReturnCorrectName()
        {
            var testStruct = new TestStruct();
            Assert.Equal("Field", testStruct.GetMemberName(obj => obj.Field));
        }

        [Fact]
        public void WhenNestedFieldOStruct_ShouldReturnCorrectName()
        {
            var testStruct = new TestStruct();
            Assert.Equal("Field", testStruct.GetMemberName(obj => obj.Field));
        }

        [Fact]
        public void WhenPassedNotMemberAccessExpression_ShouldThrowException()
        {
            var testClass = new TestClass();
            Assert.Throws<ArgumentException>(() => testClass.GetMemberName(obj => 42));
        }

        [Fact]
        public void WhenPassedNullExpression_ShouldThrowException()
        {
            var testClass = new TestClass();
            Assert.Throws<ArgumentNullException>(() => testClass.GetMemberName<TestClass, int>(null));
        }

        private class TestClass
        {
            // ReSharper disable once ConvertToConstant.Local
#pragma warning disable SA1401 // Fields must be private
            public readonly int Field = 42;
#pragma warning restore SA1401 // Fields must be private

            public TestClass Property => this;
        }

        private class TestStruct
        {
            // ReSharper disable once ConvertToConstant.Local
#pragma warning disable SA1401 // Fields must be private
            public readonly int Field = 42;
#pragma warning restore SA1401 // Fields must be private

            public TestStruct Property => this;
        }
    }
}
