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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateProductAsync(productModels obj)
        {
            var product = _mapper.Map<productModels, Product>(obj);
            await _unitOfWork.Product.AddAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _unitOfWork.Product.GetByAsync(id);

            if (product == null) return;

            await _unitOfWork.Product.RemoveAsync(product);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<productModels> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.Product.GetByAsync(id);
            return _mapper.Map<Product, productModels>(product);
        }

        public async Task<PaginationModels<productModels>> GetProductAsync([FromQuery] searchString search, [FromQuery] Pagination pagination)
        {
            var movies = await _unitOfWork.Product.GetAllAsync();
            var product = _mapper.Map<IEnumerable<Product>, IEnumerable<productModels>>(movies);
            
            if (search.Name != "")
            {
                product = product.Where(a =>
                a.Nameproduct.ToLower().Contains(search.Name.ToLower()));
            }

            PaginationModels<productModels> _product = new PaginationModels<productModels>();
            int total = product.Count();
            _product.array = product.Skip((pagination.Current - 1) * pagination.PageSize).Take<productModels>(pagination.PageSize);
            _product.totalPage = (int)Math.Ceiling(total / (double)pagination.PageSize);
            _product.count = _product.array.Count();
            _product.current = pagination.Current;
            return _product;
        }

        public async Task UpdateProductAsync(productModels obj)
        {
            var product = await _unitOfWork.Product.GetByAsync(obj.Idproduct);
            if (product == null) return;

            _mapper.Map<productModels, Product>(obj, product);

            await _unitOfWork.CompleteAsync();
        }
    }
}
