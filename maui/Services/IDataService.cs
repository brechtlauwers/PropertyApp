using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maui.Models;

namespace maui.Services
{
    public interface IDataService
    {
        Task<List<Property>> GetAllPropAsync();
        Task AddPropAsync(Property prop);
        Task UpdatePropAsync(Property prop);
        Task DeletePropAsync(int id);
    }
}