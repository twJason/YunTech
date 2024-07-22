﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using YunTech.Model;

namespace YunTech.Service
{
    public interface IDeptRepository
    {
        Task<List<Dept>> GetDeptsAsync();
    }
}