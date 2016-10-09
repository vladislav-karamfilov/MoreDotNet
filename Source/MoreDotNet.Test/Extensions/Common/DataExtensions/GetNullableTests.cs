namespace MoreDotNet.Tests.Extensions.Common.DataExtensions
{
    using System;
    using System.Data;

    using Microsoft.SqlServer.Server;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class GetNullableTests
    {
        [Fact]
        public void GetNullable_NullDataRecord_ShouldThrowException()
        {
            IDataRecord dataRecord = null;
            Assert.Throws<ArgumentNullException>(() => dataRecord.GetNullable<int>(1));
        }

        [Fact]
        public void GetNullable_InvalidOrdinal_ShouldThrowException()
        {
            var dataRecord = new SqlDataRecord(
                new SqlMetaData("StringProp", SqlDbType.NVarChar, 20),
                new SqlMetaData("IntProp", SqlDbType.Int));
            dataRecord.SetValue(0, "String value.");
            dataRecord.SetValue(1, 123);

            Assert.Throws<IndexOutOfRangeException>(() => dataRecord.GetNullable<string>(3));
        }

        [Fact]
        public void GetNullableString_DbNullDataRecordValue_ShouldReturnNull()
        {
            var dataRecord = new SqlDataRecord(
                new SqlMetaData("StringProp", SqlDbType.NVarChar, 20),
                new SqlMetaData("IntProp", SqlDbType.Int));
            dataRecord.SetValue(1, 123);

            Assert.Equal(null, dataRecord.GetNullable<string>(0));
        }

        [Fact]
        public void GetNullableInt_DbNullDataRecordValue_ShouldReturnZero()
        {
            var dataRecord = new SqlDataRecord(
                new SqlMetaData("StringProp", SqlDbType.NVarChar, 20),
                new SqlMetaData("IntProp", SqlDbType.Int));
            dataRecord.SetValue(0, "String value.");

            Assert.Equal(0, dataRecord.GetNullable<int>(1));
        }

        [Fact]
        public void GetNullableString_ValidStringValue_ShouldReturnStringValue()
        {
            const string StringValue = "String value.";
            var dataRecord = new SqlDataRecord(
                new SqlMetaData("StringProp", SqlDbType.NVarChar, 20),
                new SqlMetaData("IntProp", SqlDbType.Int));
            dataRecord.SetValue(0, StringValue);
            dataRecord.SetValue(1, 123);

            Assert.Equal(StringValue, dataRecord.GetNullable<string>(0));
        }

        [Fact]
        public void GetNullableInt_ValidIntValue_ShouldReturnIntValue()
        {
            const int IntValue = 123;
            var dataRecord = new SqlDataRecord(
                new SqlMetaData("StringProp", SqlDbType.NVarChar, 20),
                new SqlMetaData("IntProp", SqlDbType.Int));
            dataRecord.SetValue(0, "String value.");
            dataRecord.SetValue(1, IntValue);

            Assert.Equal(IntValue, dataRecord.GetNullable<int>(1));
        }
    }
}
