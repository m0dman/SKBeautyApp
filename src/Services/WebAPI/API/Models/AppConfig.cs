

using System.Diagnostics.CodeAnalysis;

namespace SKBeautyAPI.Models
{
    [ExcludeFromCodeCoverage]
    /// <summary>
    /// AppSettings class to control what is provided during development as configuration
    /// </summary>
    public class AppConfig
    {
        public string Region { get; set; }
        public string Environment { get; set; }
    }
}