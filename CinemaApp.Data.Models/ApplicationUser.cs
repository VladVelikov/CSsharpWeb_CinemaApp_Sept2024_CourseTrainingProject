﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();   
        }

        public virtual ICollection<ApplicationUserMovie> ApplicationUsersMovies { get; set; }
                         = new HashSet<ApplicationUserMovie>(); 
        // to do add our properties to our user
    }
}
