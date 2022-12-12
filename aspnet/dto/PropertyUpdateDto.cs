using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet.dto
{
    public class PropertyUpdateDto
    {
        public int Id { get; set; }
        public String Title { get; set; } = "";
        public String Address { get; set; } = "";
        public String Description { get; set; } = "";
        public Double Price { get; set; }
        public String Owner { get; set; } = "";
        public int Surface { get; set; }
        public int Bedrooms { get; set; }
        public String Picture { get; set; }
    }
}