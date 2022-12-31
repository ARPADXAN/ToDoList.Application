using Domain.Attributes;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.User
{
    [AuditTable]
    public class Users:IdentityUser
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
    }
}
