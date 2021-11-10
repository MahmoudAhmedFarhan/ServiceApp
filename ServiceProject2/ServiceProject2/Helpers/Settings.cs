// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ServiceProject2.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private const string LangKey = "Lang_key";
        private const string LoginKey = "Login_key";
        private static readonly string SettingsDefault = string.Empty;

        #endregion


        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }

        public static string Language
        {
            get
            {
                return AppSettings.GetValueOrDefault(LangKey, "ar");
            }
            set
            {
                AppSettings.AddOrUpdateValue(LangKey, value);
            }
        }

        public static string IsLoginin
        {
            get
            {
                return AppSettings.GetValueOrDefault(LoginKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(LoginKey, value);
            }
        }
    }
}
