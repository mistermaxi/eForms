using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Services.Permissions
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsForModule(string module)
        {
            return new List<string>()
            {
                $"Permissions.{module}.Create",
                $"Permissions.{module}.View",
                $"Permissions.{module}.Edit",
                $"Permissions.{module}.Delete",
            };
        }
        public static class Sections
        {
            public const string View = "Permissions.Sections.View";
            public const string Create = "Permissions.Sections.Create";
            public const string Edit = "Permissions.Sections.Edit";
            public const string Delete = "Permissions.Sections.Delete";
        }

    }
}
