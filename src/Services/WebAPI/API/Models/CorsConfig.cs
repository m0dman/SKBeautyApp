

using System.Diagnostics.CodeAnalysis;

namespace SKBeautyAPI.Models
{
    [ExcludeFromCodeCoverage]
    /// <summary>
    /// AppSettings class to control what is provided during development as configuration
    /// </summary>
    public class CorsConfig
    {
        public string PolicyName { get; set; }
        public string Origin { get; set; }
    }
}