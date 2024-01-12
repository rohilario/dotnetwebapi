using dotnetwebapi.Models;

namespace dotnetwebapi.Services
{
    public interface ITokenService
    {
       public User GenerateToken();
 
    }
}