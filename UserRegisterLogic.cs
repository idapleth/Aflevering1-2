using Domain;

namespace Application;

    public class UserRegisterLogic : IUserRegisterLogic
    {
        private readonly IUserRegisterDao _userRegisterDao;

        public UserRegisterLogic(IUserRegisterDao userRegisterDao)
        {
            this._userRegisterDao = userRegisterDao;
        }
        
        public async Task<UserRegister> CreateAsync(UserRegisterCreationDto dto)
        {
            UserRegister? existing = await _userRegisterDao.GetByUsernameAsync(dto.UserName);
            if (existing != null)
                throw new Exception("Username already taken!");

            ValidateData(dto);
            UserRegister toCreate = new UserRegister
            {
                UserName = dto.UserName
            };
        
            UserRegister created = await _userRegisterDao.CreateAsync(toCreate);
        
            return created;
        }

        public Task<IEnumerable<UserRegister>> GetAsync(SearchUserRegisterParametersDto searchRegisterParameters)
        {
            return _userRegisterDao.GetAsync(searchRegisterParameters);
        }

        private static void ValidateData(UserRegisterCreationDto userRegisterToCreate)
        {
            string userName = userRegisterToCreate.UserName;

            if (userName.Length < 3)
                throw new Exception("Username must be at least 3 characters!");

            if (userName.Length > 15)
                throw new Exception("Username must be less than 16 characters!");
        }
}