using System;
namespace frettir.Utils
{
    public static class Constants
    {
        #region Min / Max Values

        public static int SHORTEND_FEED_TITLE_LENGTH = 10;

#endregion

        #region Notification keys

        /// <summary>
        /// The notification identifier for `addfeed failed`.
        /// </summary>
        public static string NOTIFICATION_ID_ADDFEED_FAILED = "NOTIFICATION_ID_ADDFEED_FAILED";

        /// <summary>
        /// The notification identifier `addtabitem.
        /// </summary>
        public static string NOTIFICATION_ID_ADDTABITEM = "NOTIFICATION_ID_ADDTABITEM";

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
    }
}
