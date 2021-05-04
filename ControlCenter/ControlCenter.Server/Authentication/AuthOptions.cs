using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ControlCenter.Server.Authentication
{
    public class AuthOptions
    {
        public const string ISSUER = "SolarSystemServer"; 
        public const string AUDIENCE = "SolarSystemClient"; 
        public const int LIFETIME = 60;
        private const string KEY = "Key_3284789SADdasdAS_$$%sadias";

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
