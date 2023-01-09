using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Entities.Concrete;
using TodoApp.Core.Extensions;
using TodoApp.Core.Utilities.Security.Encryption;

namespace TodoApp.Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); //AppSettings'den TokenOptions alanını çekiyoruz.
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration); //Token bitiş süresini ayarlıyoruz.
        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey); //AppSettings'deki SecurityKey alanına göre bir key oluşturuyoruz.
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredential(securityKey); //Oluşturulan securityKey'i kullanarak HMAC SHA 256
                                                                                                    //şifreleme yöntemi kullanarak Credentials imzalama yapıyoruz.

            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims); //Bu metod çalışacak ve jwt değeri geri dönecek.

            //Oluşan jwt'yi bir helper vasıtasıyla yazmamız gerekmekte.
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user,operationClaims),
                signingCredentials: signingCredentials);
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims) //Bizim oluşturduğumuz OperationClaim nesnesini gerçek claim'e çeviren metod
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
