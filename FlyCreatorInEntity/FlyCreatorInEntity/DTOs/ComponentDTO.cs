using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCreator.DTOs
{
    public class ComponentDTO
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public int MaterialOptionId { get; set; }
        public int SectionId { get; set; }
    }
}
