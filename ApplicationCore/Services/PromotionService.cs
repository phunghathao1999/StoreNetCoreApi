using ApplicationCore.EF;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class PromotionService : IPromotionService
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public PromotionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task CreatePromotionAsync(promotionModels obj)
        {
            var promotion = _mapper.Map<promotionModels, Promotion>(obj);
            await _unitOfWork.Promotion.AddAsync(promotion);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeletePromotionAsync(int id)
        {
            var promotion = await _unitOfWork.Promotion.GetByAsync(id);
            if (promotion == null) return;

            await _unitOfWork.Promotion.RemoveAsync(promotion);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<promotionModels> GetByIdAsync(int id)
        {
            var promotion = await _unitOfWork.Promotion.GetByAsync(id);
            return _mapper.Map<Promotion, promotionModels>(promotion);
        }

        public async Task<PaginationModels<promotionModels>> GetPromotionAsync([FromQuery] searchString search, [FromQuery] Pagination pagination)
        {
            var promotion = await _unitOfWork.Promotion.GetAllAsync();
            var result = _mapper.Map<IEnumerable<Promotion>, IEnumerable<promotionModels>>(promotion);

            PaginationModels<promotionModels> _promotion = new PaginationModels<promotionModels>();
            int total = result.Count();
            _promotion.array = result.Skip((pagination.Current - 1) * pagination.PageSize).Take<promotionModels>(pagination.PageSize);
            _promotion.totalPage = (int)Math.Ceiling(total / (double)pagination.PageSize);
            _promotion.count = _promotion.array.Count();
            _promotion.current = pagination.Current;
            return _promotion;
        }

        public async Task UpdatePromotionAsync(promotionModels obj)
        {
            var promotion = await _unitOfWork.Promotion.GetByAsync(obj.Idpromotion);
            if (promotion == null) return;

            _mapper.Map<promotionModels, Promotion>(obj, promotion);

            await _unitOfWork.CompleteAsync();
        }
    }
}
