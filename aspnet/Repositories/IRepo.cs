using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet.Models;

namespace aspnet.Repositories
{
    public interface IRepo
    {
        IEnumerable<Property> GetAllProp();

        Property GetPropById(int id);

        void AddProp(Property p);

        void UpdateProp(Property p);

        void DeleteProp(Property p);

        void SaveChanges();
    }
}