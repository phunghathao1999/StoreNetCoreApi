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
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAccountAsync(accountModels obj)
        {
            var account = _mapper.Map<accountModels, Account>(obj);
            await _unitOfWork.Account.AddAsync(account);
        }

        public async Task DeleteAccountAsync(int id)
        {
            var account = await _unitOfWork.Account.GetByAsync(id);

            if (account == null) return;

            await _unitOfWork.Account.RemoveAsync(account);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<PaginationModels<accountModels>> GetAccountAsync([FromQuery] searchString search, [FromQuery] Pagination pagination)
        {
            var movies = await _unitOfWork.Account.GetAllAsync();
            var account = _mapper.Map<IEnumerable<Account>, IEnumerable<accountModels>>(movies);

            if (search.Name != "")
            {
                account = account.Where(a =>
                a.Accountname.ToLower().Contains(search.Name.ToLower()));
            }

            PaginationModels<accountModels> _account = new PaginationModels<accountModels>();
            int total = account.Count();
            _account.array = account.Skip((pagination.Current - 1) * pagination.PageSize).Take<accountModels>(pagination.PageSize);
            _account.totalPage = (int)Math.Ceiling(total / (double)pagination.PageSize);
            _account.count = _account.array.Count();
            _account.current = pagination.Current;
            return _account;
        }

        public async Task<accountModels> GetByIdAsync(int id)
        {
            var account = await _unitOfWork.Account.GetByAsync(id);
            return _mapper.Map<Account, accountModels>(account);
        }

        public async Task UpdateAccountAsync(accountModels obj)
        {
            var account = await _unitOfWork.Account.GetByAsync(obj.Idaccount);
            if (account == null) return;

            _mapper.Map<accountModels, Account>(obj, account);

            await _unitOfWork.CompleteAsync();
        }
    }
}
