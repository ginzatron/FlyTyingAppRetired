using FlyCreator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCreator.Models
{
    public class UserNote
    {
        public Guid Id { get; set; }
        public AppUser AppUser { get; set; }
        public string Note { get; set; }
    }
}
