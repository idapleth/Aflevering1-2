using Domain;

namespace Application;

public interface IUserRegisterDao
{
    Task<UserRegister> CreateAsync(UserRegister user);
    Task<UserRegister?> GetByFirstNameAsync(string firstName);
    Task<UserRegister?> GetByLastNameAsync(string lastName);
    Task<UserRegister?> GetByUserNameAsync(string userName);
    Task<UserRegister?> GetByEmailAsync(string email);
    Task<UserRegister?> GetByPasswordAsync(string password);
    Task<UserRegister?> GetByIdAsync(int id);
    public Task<IEnumerable<UserRegister>> GetAsync(SearchUserRegisterParametersDto searchRegisterParameters);
    Task<UserRegister?> GetByUsernameAsync(string dtoUserName);
}
