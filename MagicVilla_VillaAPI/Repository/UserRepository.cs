using System;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository.IRepository;

namespace MagicVilla_VillaAPI.Repository
{
	public class UserRepository : IUserRepository
	{
        private readonly ApplicationDbContext _db;
        private string secretKey;
		public UserRepository(ApplicationDbContext db, IConfiguration configuration)
		{
            _db = db;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
		}

        public bool IsUniqueUser(string username)
        {
            var user = _db.LocalUsers.FirstOrDefault(x => x.Username == username);
            if(user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _db.LocalUsers.FirstOrDefault(u => u.Username.ToLower() == loginRequestDTO.Username.ToLower()
            && u.Password == loginRequestDTO.Password);
            if(user == null)
            {
                return null;
            }
            // if user was found, generate JWT Token

        }

        public async Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            LocalUser user = new LocalUser()
            {
                Username = registrationRequestDTO.Username,
                Password = registrationRequestDTO.Password,
                Name = registrationRequestDTO.Name,
                Role = registrationRequestDTO.Role,
            };

            _db.LocalUsers.Add(user);
            await _db.SaveChangesAsync();
            user.Password = "";
            return user;
        }
    }
}

