namespace MoreDotNet.Tests.Extentions.Common.TypeExtensions
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MoreDotNet.Extentions.Common;

    using Xunit;

    public class TypeExtensionsTests
    {
        [Fact]
        public void IsNullable_GivenNullArgument_ShouldThrowException()
        {
            Type testType = null;

            Assert.Throws<ArgumentNullException>(() => testType.IsNullable());
        }

        [Fact]
        public void GetCoreType_GivenNullArgument_ShouldThrowException()
        {
            Type testType = null;

            Assert.Throws<ArgumentNullException>(() => testType.GetCoreType());
        }

        [Fact]
        public void IsNullable_GivenNullableArgument_ShouldReturnTrue()
        {
            var nullableTypes = new[]
            {
                typeof(Nullable<>),
                typeof(byte?),
                typeof(sbyte?),
                typeof(short?),
                typeof(ushort?),
                typeof(int?),
                typeof(uint?),
                typeof(long?),
                typeof(ulong?),
                typeof(double?),
                typeof(float?),
                typeof(decimal?)
            };

            foreach (var nullableType in nullableTypes)
            {
                Assert.True(nullableType.IsNullable());
            }
        }

        [Fact]
        public void GetCoreType_GivenNonNullableArgument_ShouldReturnSameType()
        {
            var nonNullableTypes = new[]
{
                typeof(byte),
                typeof(sbyte),
                typeof(short),
                typeof(ushort),
                typeof(int),
                typeof(uint),
                typeof(long),
                typeof(ulong),
                typeof(double),
                typeof(float),
                typeof(decimal)
            };

            foreach (var nonNullableType in nonNullableTypes)
            {
                Assert.Equal(nonNullableType.GetCoreType(), nonNullableType);
            }
        }

        [Fact]
        public void GetCoreType_GivenNullableArgument_ShouldReturnCoreType()
        {
            var nullableTypes = new[]
            {
                new { NullableType = typeof(byte?), CoreType = typeof(byte) },
                new { NullableType = typeof(sbyte?), CoreType = typeof(sbyte) },
                new { NullableType = typeof(short?), CoreType = typeof(short) },
                new { NullableType = typeof(ushort?), CoreType = typeof(ushort) },
                new { NullableType = typeof(int?), CoreType = typeof(int) },
                new { NullableType = typeof(uint?), CoreType = typeof(uint) },
                new { NullableType = typeof(long?), CoreType = typeof(long) },
                new { NullableType = typeof(ulong?), CoreType = typeof(ulong) },
                new { NullableType = typeof(double?), CoreType = typeof(double) },
                new { NullableType = typeof(float?), CoreType = typeof(float) },
                new { NullableType = typeof(decimal?), CoreType = typeof(decimal) },
                new { NullableType = typeof(Random), CoreType = typeof(Random) }
            };

            foreach (var type in nullableTypes)
            {
                Assert.Equal(type.NullableType.GetCoreType(), type.CoreType);
            }
        }
    }
}
