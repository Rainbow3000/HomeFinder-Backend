﻿using HomeFinder.Core.Dto.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Interface.Service
{
    public interface IHomeService:IBaseService<HomeDto,HomeCreateDto,HomeUpdateDto>
    {
    }
}
