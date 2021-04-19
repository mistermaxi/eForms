using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace eForms.Domain.Enums
{
    public static class ExtensionsEnum
    {
        private static string GetDisplayOfMember(MemberInfo m)
        {
            DisplayAttribute display = m.GetCustomAttribute<DisplayAttribute>();
            if (display == null) return m.Name;
            else return display.Name;
        }

        public static string GetDisplay(Enum e)
        {
            return GetDisplayOfMember(
                e.GetType()
                    .GetMember(e.ToString())
                    .First()
            );
        }

        public static Enum Parse(Type t, string str)
        {
            return TryParse(t, str) ?? default;
        }

        public static Enum? TryParse(Type t, string str)
        {
            foreach (Enum val in Enum.GetValues(t))
            {
                var members = t.GetMember(val.ToString());
                foreach (var member in members)
                {
                    if (GetDisplayOfMember(member) == str)
                    {
                        return (Enum)Enum.Parse(t, member.Name);
                    }
                }
            }
            return null;
        }

        public static string GetNameFromDisplay<T>(string display)
        {
            Type t = typeof(T);
            t = Nullable.GetUnderlyingType(t) == null ? t : Nullable.GetUnderlyingType(t);
            Enum e = Parse(t, display);
            if (e == null) return "";
            else return e.ToString();
        }

        public static string GetDisplayFromName<T>(string name)
        {
            return GetDisplay((Enum)Enum.Parse(typeof(T), name));
        }

        public static string GetDisplayFromName(Type t, string name)
        {
            return GetDisplay((Enum)Enum.Parse(t, name));
        }
    }
}
