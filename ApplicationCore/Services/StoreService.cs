using ApplicationCore.EF;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class StoreService : IStoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StoreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateStoreAsync(storeModels obj)
        {
            var store = _mapper.Map<storeModels, Store>(obj);
            await _unitOfWork.Store.AddAsync(store);
        }

        public async Task DeleteStoreAsync(int id)
        {
            var store = await _unitOfWork.Store.GetByAsync(id);

            if (store == null) return;

            await _unitOfWork.Store.RemoveAsync(store);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<storeModels> GetByIdAsync(int id)
        {
            var store = await _unitOfWork.Store.GetByAsync(id);
            return _mapper.Map<Store, storeModels>(store);
        }

        public async Task<PaginationModels<storeModels>> GetStoreAsync([FromQuery] searchString search, [FromQuery] Pagination pagination)
        {
            var movies = await _unitOfWork.Store.GetAllAsync();
            var product = _mapper.Map<IEnumerable<Store>, IEnumerable<storeModels>>(movies);

            if (search.Name != "")
            {
                product = product.Where(a =>
                a.Namestore.ToLower().Contains(search.Name.ToLower()));
            }

            PaginationModels<storeModels> _store = new PaginationModels<storeModels>();
            int total = product.Count();
            _store.array = product.Skip((pagination.Current - 1) * pagination.PageSize).Take<storeModels>(pagination.PageSize);
            _store.totalPage = (int)Math.Ceiling(total / (double)pagination.PageSize);
            _store.count = _store.array.Count();
            _store.current = pagination.Current;
            return _store;
        }

        public async Task UpdateStoreAsync(storeModels obj)
        {
            var store = await _unitOfWork.Store.GetByAsync(obj.Idstore);
            if (store == null) return;

            _mapper.Map<storeModels, Store>(obj, store);

            await _unitOfWork.CompleteAsync();
        }
    }
}
