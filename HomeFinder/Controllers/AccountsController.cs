using HomeFinder.Core.Dto.Account;
using HomeFinder.Core.Entity;
using HomeFinder.Core.Interface.Service;
using HomeFinder.Core.Service;
using HomeFinder.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeFinder.Controllers
{
    [ApiController]
    public class AccountsController : BasesController<AccountDto, AccountCreateDto, AccountUpdateDto>
    {
        private readonly IAccountService _accountService;
        private readonly DatabaseContext _databaseContext;
        public AccountsController(IAccountService accountService, DatabaseContext databaseContext) : base(accountService)
        {
            _accountService = accountService;
            _databaseContext = databaseContext;
        }
    }
}
