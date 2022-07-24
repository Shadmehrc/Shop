using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common;
using Application.IPhoneCrudServices;
using Application.RepositoryInterfaces;
using Core.Entities;
using Core.Models;
using Mapster;

namespace Application.Services
{
    public class PhoneCrudService : IPhoneCrudService
    {
        private readonly IPhoneRepository _iPhoneRepository;

        public PhoneCrudService(IPhoneRepository iPhoneRepository)
        {
            this._iPhoneRepository = iPhoneRepository;
        }

        public async Task<bool> AddPhoneAsync(AddPhoneModel model)
        {
            var photoConverter = new ConvertImageToByteArray();
            var photo = await photoConverter.Get(model.Photo);
            var phone = new Phone()
            {
                Brand = model.Brand,
                GraphicModel = model.GraphicModel,
                InStock = model.InStock,
                LcdModel = model.LcdModel,
                Storage = model.Storage,
                TotalSold = model.TotalSold,
                Model = model.Model,
                Price = model.Price,
                Photo = photo
            };
            var result = await _iPhoneRepository.AddPhoneAsync(phone);
            return result;
        }

        public async Task<ShowPhoneDetailsModel> ShowPhoneDetailsAsync(int id)
        {
            var result = await _iPhoneRepository.ShowPhoneDetailsAsync(id);
            if (result!=null)
            {
                var phone=  result.Adapt<ShowPhoneDetailsModel>();
                return phone;
            }

            return null;
        }

        public async Task<ShowPhonePhotoModel> ShowPhonePhotoAsync(int id)
        {
            var result = await _iPhoneRepository.ShowPhonePhotoAsync(id);
            var phonePhoto = result.Adapt<ShowPhonePhotoModel>();
            return phonePhoto;
        }

        public async Task<bool> EditPhoneAsync(EditPhoneModel model)
        {
            var result = await _iPhoneRepository.EditPhoneAsync(model);
            return result;
        }

        public async Task<bool> DeletePhoneAsync(int id)
        {
            var result = await _iPhoneRepository.DeletePhoneAsync(id);
            return result;
        }

        public async Task<List<ShowPhoneDetailsModel>> ShowPhoneAllAsync(GetAllPhonesModel model)
        {
            var pagination = new GetAllPhonesPagination()
            {
                Take = model.ItemPerPage,
                Skip = (model.PageNumber -1) * model.ItemPerPage
            };
            var result = await _iPhoneRepository.ShowPhoneAllAsync(pagination);
            var phones = new List<ShowPhoneDetailsModel>();
            foreach (var item in result)
            {
                phones.Add(item.Adapt<ShowPhoneDetailsModel>());
            }
            return phones;
        }
    }
}
