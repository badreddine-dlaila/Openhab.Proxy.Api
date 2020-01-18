using System.Text.RegularExpressions;

namespace Openhab.Proxy.Api.Configuration
{
    public interface ITokenController
    {
        string Token { get; set; }
        string Group { get; set; }
    }
}
