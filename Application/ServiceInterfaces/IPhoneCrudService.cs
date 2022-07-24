using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;


namespace Application.IPhoneCrudServices
{
    public interface IPhoneCrudService
    {
        public Task<bool> AddPhoneAsync(AddPhoneModel model);
        public Task<ShowPhoneModel> ShowPhoneAsync(int id);
        public Task<bool> EditPhoneAsync(EditPhoneModel model );
        public Task<bool> DeletePhoneAsync(int id);
        public Task<List<ShowPhoneModel>> ShowPhoneAllAsync(GetAllPhonesModel model);

    }
}
