using LinkLy.Interfaces;

namespace LinkLy.Helpers
{
    /// <summary>
    /// Class with config values from appsettings file for visitor helper class
    /// </summary>
    public class VisitorConfig : IVisitorConfig
    {
        public string LookupUri { get; set; }
    }
}
