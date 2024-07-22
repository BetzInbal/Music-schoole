using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiusucScule2.Configuration
{
    internal static class AppConfiguration
    {
        public static string MiusicSchoolePath => Path.Combine(
            Directory.GetCurrentDirectory(),
            "MiusicSchoole.Xml"
            );
    }
}
