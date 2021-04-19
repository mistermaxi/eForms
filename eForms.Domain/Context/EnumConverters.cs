using eForms.Domain.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eForms.Domain.Context
{
    public class EnumStringConverter
    {
        private static string NonNullableFromEnum<T>(T t)
        {
            return ExtensionsEnum.GetDisplayFromName<T>(t.ToString());
        }

        private static T NonNullableToEnum<T>(string t)
        {
            string n = ExtensionsEnum.GetNameFromDisplay<T>(t);
            if (!Enum.IsDefined(typeof(T), n)) return default;
            return (T)Enum.Parse(typeof(T), n);
        }

        private class NonNullableConverter<T> : ValueConverter<T, string> where T : struct
        {
            public NonNullableConverter(ConverterMappingHints mappingHints = null) : base(x => NonNullableFromEnum(x), x => NonNullableToEnum<T>(x), mappingHints) { }
        }

        public static ValueConverter GetNonNullable(Type type)
        {
            Type converterType = typeof(NonNullableConverter<>).MakeGenericType(type);
            return (ValueConverter)Activator.CreateInstance(converterType, (object)null);
        }

        private static string NullableFromEnum<T>(T t)
        {
            if (t == null) return default;
            return ExtensionsEnum.GetDisplayFromName(Nullable.GetUnderlyingType(typeof(T)), t.ToString());
        }

        private static T NullableToEnum<T>(string t)
        {
            if (t == null) return default;
            string n = ExtensionsEnum.GetNameFromDisplay<T>(t);
            if (!Enum.IsDefined(Nullable.GetUnderlyingType(typeof(T)), n)) return default;
            return (T)Enum.Parse(Nullable.GetUnderlyingType(typeof(T)), n);
        }

        private class NullableConverter<T> : ValueConverter<T?, string> where T : struct
        {
            public NullableConverter(ConverterMappingHints mappingHints = null) : base(x => NullableFromEnum(x), x => NullableToEnum<T?>(x), mappingHints) { }
        }

        public static ValueConverter GetNullable(Type type)
        {
            Type converterType = typeof(NullableConverter<>).MakeGenericType(Nullable.GetUnderlyingType(type));
            return (ValueConverter)Activator.CreateInstance(converterType, (object)null);
        }
    }
}
