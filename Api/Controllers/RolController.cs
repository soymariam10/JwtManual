using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers;
    public class RolController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public RolController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }


