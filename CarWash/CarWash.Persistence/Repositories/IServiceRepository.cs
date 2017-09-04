﻿using CarWash.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Persistence.Repositories
{
    public interface IServiceRepository
    {
        Task<List<Service>> GetAll();
    }
}
