using System;
using System.Collections.Generic;
using System.Linq;
using frettir.Models;
using frettir.Utils;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace frettir.Services
{
    public static class FeedPreferenceService
    {
        #region Public helper

        /// <summary>
        /// Adds the given feed.
        /// </summary>
        /// <param name="feed">Feed to add</param>
        public static void AddFeed(Feed feed)
        {
            var jsonString = JsonConvert.SerializeObject(feed);
            var jsonStrings = ReadJsonStringsFromPreferences().ToList();
            jsonStrings.Add(jsonString);

            var newJsonString = String.Join(Constants.PREFERENCE_LIST_SEPERATOR.ToString(), jsonStrings.ToArray());
            Preferences.Set(Constants.PREFERENCE_NAME_FILE_FEED, newJsonString);
        }

        /// <summary>
        /// Gets all stored feeds.
        /// </summary>
        /// <returns>The feeds.</returns>
        public static List<Feed> GetFeeds()
        {
            var feeds = new List<Feed>();
            foreach (var json in ReadJsonStringsFromPreferences())
            {
                feeds.Add(JsonConvert.DeserializeObject<Feed>(json));
            }

            return feeds;
        }

        #endregion

        #region Private helper

        /// <summary>
        /// Reads the json strings from preferences.
        /// </summary>
        /// <returns>The json strings from preferences.</returns>
        static string[] ReadJsonStringsFromPreferences()
        {
            var jsonString = Preferences.Get(Constants.PREFERENCE_NAME_FILE_FEED, String.Empty);
            return jsonString.Split(Constants.PREFERENCE_LIST_SEPERATOR, StringSplitOptions.RemoveEmptyEntries);
        }

        #endregion
    }
}
