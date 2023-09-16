using AutoMapper;
using HomeFinder.Core.Dto.Account;
using HomeFinder.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Mapper
{
    public class AccountProfile:Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDto>();
            CreateMap<AccountUpdateDto, Account>();
            CreateMap<AccountCreateDto,Account>();
        }
    }
}
