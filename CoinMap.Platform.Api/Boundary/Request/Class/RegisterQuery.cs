using CoinMap.Platform.Api.Boundary.Request.Abstract;
using System.ComponentModel.DataAnnotations;

namespace CoinMap.Platform.Api.Boundary.Request.Class
{
    public class RegisterQuery : RequestViewModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; } = null!;
    }
}
