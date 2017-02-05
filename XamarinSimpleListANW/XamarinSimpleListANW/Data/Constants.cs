using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinSimpleListANW.Data
{
    public static class Constants
    {
        // constants that are here are here only because I didn't know if it's ok to create new class for them
        // GitHub specific:
        public readonly static Uri gitHubRepositoryUri = new Uri(@"https://api.github.com/users/xamarin/repos");
        public readonly static string gitHubHost = "api.github.com";
        public readonly static string neededHeader = "User-Agent";
        public readonly static string neededHeaderValue = "TeoDark";

    }
}
