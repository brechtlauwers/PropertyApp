using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnet.Contexts
{
    public class PropertyContext : DbContext
    {
        public PropertyContext(DbContextOptions<PropertyContext> opt) : base(opt)
        {
            
        }
        
        public DbSet<Property> properties {get; set;}
    }
}