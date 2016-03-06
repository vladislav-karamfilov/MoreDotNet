namespace MoreDotNet.Extentions.Common
{
    using System;

    public static class TypeExtentions
    {
        /// <summary>
        /// Determine of specified type is nullable
        /// </summary>
        public static bool IsNullable(this Type type)
        {
            type.ThrowIfArgumentIsNull("type");

            return !type.IsValueType || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// Return underlying type if type is Nullable otherwise return the type
        /// </summary>
        public static Type GetCoreType(this Type type)
        {
            type.ThrowIfArgumentIsNull("type");

            if (type != null && IsNullable(type))
            {
                if (!type.IsValueType)
                {
                    return type;
                }

                return Nullable.GetUnderlyingType(type);
            }

            return type;
        }
    }
}
