using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using EdVerse.Data.Data.Entity;

namespace EdVerse.Data.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedOn { get; set; }

        public DateTime? LastLogin { get; set; }

        // Navigation Properties

        //public Student? Student { get; set; }

        //public Staff? Staff { get; set; }
    }
}