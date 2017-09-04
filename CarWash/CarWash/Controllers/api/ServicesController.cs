﻿using CarWash.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarWash.Controllers.api
{
    public class ServicesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServicesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("api/services")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var services = await _unitOfWork.Services.GetAll();
            return Ok(services);
        }
    }
}
