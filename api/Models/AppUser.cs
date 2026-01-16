using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class AppUser : IdentityUser
    {
        public List<UserStock> UserStocks { get; set; } = new List<UserStock>();
    }
}