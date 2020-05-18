using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace KnightsBridge.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the KnightsBridgeUser class
    public class KnightsBridgeUser : IdentityUser
    {
        [Required]
        [PersonalData]
        public string FirstName { get; set; }
        [Required]
        [PersonalData]
        public string LastName { get; set; }
    }
}
