using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SensorWeb.Sensor.Models
{
    public class User : IdentityUser
    {
        // properties are password and email. is extend
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PassportID { get; set; }
    }
}
