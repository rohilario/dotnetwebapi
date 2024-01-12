using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using dotnetwebapi.Models;

namespace dotnetwebapi.Services
{
	public class TokenService
	{
		public static object GenerateToken(User user)
		{
			var key = Encoding.ASCII.GetBytes(Key.Secret);
			var tokenConfig = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					//adiciona o id do usuário no token, para recuperar em qualquer momento da aplicacao.
                    new Claim("UserId", user.UserId.ToString()),
				}),
				// Define o tempo de expiracao
				Expires = DateTime.UtcNow.AddHours(1),
				// Algoritmo de encriptacao
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(tokenConfig);
			//hash para retornar
			var tokenString = tokenHandler.WriteToken(token);

			return new { tokenString };
			
		}

    }
}


