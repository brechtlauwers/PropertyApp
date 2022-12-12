using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet.Models;
using aspnet.Contexts;

namespace aspnet.Repositories
{
    public class MysqlRepo : IRepo
    {
        private readonly PropertyContext _context;

        public MysqlRepo(PropertyContext context)
        {
            _context = context;
        }


        public void AddProp(Property p)
        {
            _context.properties.Add(p);
        }

        public void DeleteProp(Property p)
        {
            _context.properties.Remove(p);
        }

        public IEnumerable<Property> GetAllProp()
        {
            return _context.properties;
        }

        public Property GetPropById(int id)
        {
            Property? prop = _context.properties.FirstOrDefault<Property>(t => t.Id == id);

            if(prop != null)
                return prop;
            else
                return new Property();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateProp(Property p)
        {
            throw new NotImplementedException();
        }
    }
}