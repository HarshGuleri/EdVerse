using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace EdVerse.Data.Data.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;
    }
}