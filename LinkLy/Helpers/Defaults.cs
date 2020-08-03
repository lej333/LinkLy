using LinkLy.Interfaces;

namespace LinkLy.Helpers
{
    /// <summary>
    /// Helper class to store default values from appsettings file
    /// </summary>
    public class Defaults : IDefaults
    {
        public string Domain { get; set; }

        public int PageSize { get; set; }
    }
}
