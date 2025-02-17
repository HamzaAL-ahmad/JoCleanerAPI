
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoCleaners.Core.Entities
{
    public class User : IdentityUser, IEntity
    {

        public Guid Id { get; set; }
        public string FullName { get; set; }
    }

}
