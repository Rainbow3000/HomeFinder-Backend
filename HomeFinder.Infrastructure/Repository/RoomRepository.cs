﻿using AutoMapper;
using HomeFinder.Core.Entity;
using HomeFinder.Core.Interface.Repository;
using HomeFinder.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Infrastructure.Repository
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        public RoomRepository(DatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

    }
}
