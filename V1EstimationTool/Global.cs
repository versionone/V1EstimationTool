using System;
using VersionOne.SDK.ObjectModel;

namespace V1EstimationTool
{
    public static class Global
    {
        private static Config _config;

        private static V1Instance _instance;

        static Global()
        {
            Config.OnChanged += Configuration_OnChanged;
        }

        public static Config Config
        {
            get { return _config ?? (_config = new Config()); }
        }

        public static V1Instance Instance
        {
            get
            {
                return _instance ??
                       (_instance =
                        new V1Instance(Config.ApplicationPath ?? string.Empty, Config.Username ?? string.Empty,
                                       Config.Password ?? string.Empty, Config.UseWindowsIntegrated));
            }
        }

        public static bool IsValid
        {
            get
            {
                try
                {
                    Instance.Validate();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        private static void Configuration_OnChanged(object sender, EventArgs e)
        {
            _instance = null;
        }
    }
}