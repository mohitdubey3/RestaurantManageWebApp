using Microsoft.AspNetCore.Identity;
using TasteTown.Models;

namespace TasteTown.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Order>? Orders { get; set; }
    }
}
