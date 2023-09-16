using AutoMapper;
using HomeFinder.Core.Dto.Account;
using HomeFinder.Core.Entity;
using HomeFinder.Core.Interface.Repository;
using HomeFinder.Core.Interface.Service;

namespace HomeFinder.Core.Service
{
    public class AccountService : BaseService<Account, AccountDto, AccountCreateDto, AccountUpdateDto>, IAccountService
    {
        // private readonly IAccountRepository _accountRepository;
        // private readonly IMapper _mapper; 
        public AccountService(IAccountRepository accountRepository, IMapper mapper) : base(accountRepository, mapper)
        {
            // _accountRepository = accountRepository;

        }
    }
}
