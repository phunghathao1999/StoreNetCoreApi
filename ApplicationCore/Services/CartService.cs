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
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CartService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateCartAsync(cartModels obj)
        {
            var store = _mapper.Map<cartModels, Cart>(obj);
            await _unitOfWork.Cart.AddAsync(store);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteCartAsync(int id)
        {
            var store = await _unitOfWork.Cart.GetByAsync(id);

            if (store == null) return;

            await _unitOfWork.Cart.RemoveAsync(store);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<cartModels> GetByIdAsync(int id)
        {
            var cart = await _unitOfWork.Cart.GetByAsync(id);
            return _mapper.Map<Cart, cartModels>(cart);
        }

        public async Task<PaginationModels<cartModels>> GetCartAsync([FromQuery] searchString search, [FromQuery] Pagination pagination)
        {
            var movies = await _unitOfWork.Cart.GetAllAsync();
            var cart = _mapper.Map<IEnumerable<Cart>, IEnumerable<cartModels>>(movies);

            PaginationModels<cartModels> _cart = new PaginationModels<cartModels>();
            int total = cart.Count();
            _cart.array = cart.Skip((pagination.Current - 1) * pagination.PageSize).Take<cartModels>(pagination.PageSize);
            _cart.totalPage = (int)Math.Ceiling(total / (double)pagination.PageSize);
            _cart.count = _cart.array.Count();
            _cart.current = pagination.Current;
            return _cart;
        }

        public async Task UpdateCartAsync(cartModels obj)
        {
            var cart = await _unitOfWork.Cart.GetByAsync(obj.Idcart);
            if (cart == null) return;

            _mapper.Map<cartModels, Cart>(obj, cart);

            await _unitOfWork.CompleteAsync();
        }
    }
}
