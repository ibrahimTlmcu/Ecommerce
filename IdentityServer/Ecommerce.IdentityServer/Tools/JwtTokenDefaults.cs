using IdentityServer4.Models;

namespace Ecommerce.IdentityServer.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "http://localhost";//Gecerli hedef
        public const string ValidIssuer = "http://localhost";//Gecerli duzenleyici belirle
        public const string Key = "ecommerce-identity-server-key";
        //Bu sabit, JWT token'larının imzalanması ve doğrulanması
        //için kullanılan anahtarı belirtir.
        public const int  Expire = 60; //token suresi dakika cinsinden
    }
}
