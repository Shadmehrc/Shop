using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Application.RepositoryInterfaces;
using Core.Entities;
using Core.Models;
using Infrastructore.Sql.Context;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructore.Repository
{
   public class PhoneRepository: IPhoneRepository
   {
       private readonly DatabaseContext _dbContext;

       public PhoneRepository(DatabaseContext dbContext)
       {
           this._dbContext = dbContext;
       }

       public async Task<bool> AddPhoneAsync(Phone model)
       {
           var add = await _dbContext.Phones.AddAsync(model);
           var result = await _dbContext.SaveChangesAsync();
           if (result==1)
           {
               return true;
           }
           return false;
       }

        public async Task<Phone> ShowPhoneDetailsAsync(int id)
        {
            var phone = await _dbContext.Phones.FirstOrDefaultAsync(x => x.Id == id);
           if (phone != null && phone.IsRemoved!=true)
           {
                phone.TotalViewed += 1;
                await _dbContext.SaveChangesAsync();
                return phone;
           }
           return null;
        }

        public async Task<Phone> ShowPhonePhotoAsync(int id)
        {
            var phone =await _dbContext.Phones.FirstOrDefaultAsync(x => x.Id == id);
            if (phone != null && phone.IsRemoved != true && phone.Photo!=null)
            {
                phone.TotalViewed += 1;
                await _dbContext.SaveChangesAsync();
                return phone;
            }
            return null;
        }

        public async Task<bool> EditPhoneAsync(EditPhoneModel model) //todo change edit logic
        {
            var phone = await _dbContext.Phones.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (phone != null && phone.IsRemoved != true)
            {
                phone.Brand = model.Brand;
                phone.GraphicModel = model.GraphicModel;
                phone.InStock = model.InStock;
                phone.LcdModel = model.LcdModel;
                phone.Storage = model.Storage;
                phone.Model = model.Model;
                phone.Price = model.Price;
                var result = await _dbContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> DeletePhoneAsync(int id)
        {
            var phone = await _dbContext.Phones.FirstOrDefaultAsync(x => x.Id == id);
            if (phone != null && phone.IsRemoved != true) phone.IsRemoved = true;
            var result = await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Phone>> ShowPhoneAllAsync(GetAllPhonesPagination model)
        {
            var phones = await _dbContext.Phones.Skip(model.Skip).Take(model.Take).ToListAsync();
            foreach (var item in phones)
            {
                item.TotalViewed += 1;
                await _dbContext.SaveChangesAsync();
            }
            return phones;
        }
   }
}
