namespace MoreDotNet.Extentions
{
    using System.Data;

    public static class DataExtentions
    {
        public static T GetNullable<T>(this IDataRecord dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? default(T) : (T)dr.GetValue(ordinal);
        }
    }
}
