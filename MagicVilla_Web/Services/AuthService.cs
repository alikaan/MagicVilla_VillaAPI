using System;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Services
{
	public class AuthService : BaseService, IAuthService
	{
        private readonly IHttpClientFactory _clientFactory;
        private string _villaUrl;

		public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
		{
            _clientFactory = clientFactory;
            _villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");

		}

        public Task<T> LoginAsync<T>(LoginRequestDTO obj)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                ApiType = MagicVilla_Utility.SD.ApiType.POST,
                Data = obj,
                Url = _villaUrl + "/api/UsersAuth/login"
            });
        }

        public Task<T> RegisterAsync<T>(UserDTO obj)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                ApiType = MagicVilla_Utility.SD.ApiType.POST,
                Data = obj,
                Url = _villaUrl + "/api/UsersAuth/register"
            });
        }
    }
}

