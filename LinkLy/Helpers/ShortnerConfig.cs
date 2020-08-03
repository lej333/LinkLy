using LinkLy.Interfaces;

namespace LinkLy.Helpers
{
    /// <summary>
    /// Class with config values from appsettings file for shortner helper class
    /// </summary>
    public class ShortnerConfig : IShortnerConfig
    {
        public string Alphabet { get; set; }
    }
}
