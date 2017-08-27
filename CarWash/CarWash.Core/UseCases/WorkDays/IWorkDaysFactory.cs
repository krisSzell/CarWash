﻿using CarWash.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Core.UseCases.WorkDays
{
    public interface IWorkDaysFactory
    {
        List<WorkDay> GetNext5WorkDays();
    }
}