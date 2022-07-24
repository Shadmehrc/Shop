using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Models;

namespace Application.RepositoryInterfaces
{
   public interface IPhoneRepository
    {
        public Task<bool> AddPhoneAsync(Phone model);
        public Task<Phone> ShowPhoneAsync(int id);
        public Task<bool> EditPhoneAsync(EditPhoneModel model );
        public Task<bool> DeletePhoneAsync(int id);
        public Task<List<Phone>> ShowPhoneAllAsync(GetAllPhonesPagination model);

    }

}
