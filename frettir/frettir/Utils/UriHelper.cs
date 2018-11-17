using System;
namespace frettir.Utils
{
    public static class UriHelper
    {
        /// <summary>
        /// True if given URL is a wellformed, absolut url.
        /// </summary>
        /// <returns><c>true</c>, if URL was valid, <c>false</c> otherwise.</returns>
        /// <param name="urlString">URL string.</param>
        public static bool IsValidUrl(string urlString)
        {
            return Uri.IsWellFormedUriString(urlString, UriKind.Absolute);
        }
    }
}
