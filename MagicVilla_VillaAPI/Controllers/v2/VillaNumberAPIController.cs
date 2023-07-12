 using System;
using System.Data;
using System.Net;
using AutoMapper;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Logging;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Controllers.v2
{
    //[Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/VillaNumberAPI")]
	[ApiController]
    [ApiVersion("2.0")]
    public class VillaNumberAPIController : ControllerBase
    {
        protected APIResponse _response;
        public readonly IVillaNumberRepository _dbVillaNumber;
        public readonly IVillaRepository _dbVilla;
        public readonly IMapper _mapper;

        public VillaNumberAPIController(IVillaNumberRepository dbVillaNumber, IVillaRepository dbVilla,IMapper mapper)
        {
            _dbVilla = dbVilla;
            _dbVillaNumber = dbVillaNumber;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet("GetString")]
        public IEnumerable<string> Get()
        {
            return new string[] { "Ali Kaan", "Merve" };
        }    
    }
}

