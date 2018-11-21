using System;
namespace frettir.Utils
{
    public static class Constants
    {
        #region Min / Max Values

        /// <summary>
        /// Max length of a shortend feed title.
        /// </summary>
        public static int SHORTEND_FEED_TITLE_LENGTH = 10;

        #endregion

        #region Notification keys

        /// <summary>
        /// The notification identifier for adding a new feed item failed.
        /// </summary>
        public static string NOTIFICATION_ID_FEED_ITEM_ADD_FAILED = "NOTIFICATION_ID_FEED_ITEM_ADD_FAILED";

        /// <summary>
        /// The notification identifier for adding a new feed item was succeeded.
        /// </summary>
        public static string NOTIFICATION_ID_FEED_ITEM_ADD_SUCCEEDED = "NOTIFICATION_ID_FEED_ITEM_ADD_SUCCEEDED";

        /// <summary>
        /// The notification identifier that a feed item got updated.
        /// </summary>
        public static string NOTIFICATION_ID_FEED_ITEM_UPDATED = "NOTIFICATION_ID_FEED_ITEM_UPDATED";

        /// <summary>
        /// The notification identifier that the settings page should be displayed.
        /// </summary>
        public static string NOTIFICATION_ID_SHOW_SETTINGS_PAGE = "NOTIFICATION_ID_SHOW_SETTINGS_PAGE";

        #endregion

        #region Identifier

        /// <summary>
        /// The system preference name for the feed list property.
        /// </summary>
        public static string PREFERENCE_NAME_FILE_FEED = "PREFERENCE_NAME_FILE_FEED";

        /// <summary>
        /// Preference list seperator.
        /// </summary>
        public static string[] PREFERENCE_LIST_SEPERATOR = { "-----------" };

        #endregion

        #region Misc.

        /// <summary>
        /// URI to the code repository of the app.
        /// </summary>
        public static Uri URI_REPOSITORY = new Uri("https://google.de");

        #endregion
    }
}
