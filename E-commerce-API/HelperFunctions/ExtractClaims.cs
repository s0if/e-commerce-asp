using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace E_commerce_API.HelperFunctions
{
    public class ExtractClaims
    {
        static public int? ExtractUserId(string Token)
        {
            JwtSecurityTokenHandler TokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = TokenHandler.ReadJwtToken(Token);
            Claim userIdClaim = jwtToken.Claims.FirstOrDefault(type => type.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim is not null)
            {
                int.TryParse(userIdClaim.Value, out int userId);
                return userId;
            }
            return null;
        }
    }
}
