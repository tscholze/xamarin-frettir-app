using System;
namespace frettir.Utils
{
    public static class UriHelper
    {
        public static bool IsValidUrl(string urlString)
        {
            return Uri.IsWellFormedUriString(urlString, UriKind.Absolute);
        }
    }
}
