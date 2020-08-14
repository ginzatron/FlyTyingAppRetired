using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCreator.Models
{
    public class Fly : BaseEntity
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }

        public FlyClassification Classification { get; set; }

        public IList<Component> Components { get; set; }
    }
}
