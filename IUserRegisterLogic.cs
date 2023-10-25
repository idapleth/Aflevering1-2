using Domain;

namespace Application;

public interface IUserRegisterLogic
{
    public Task<UserRegister> CreateAsync(UserRegisterCreationDto dto);
    public Task<IEnumerable<UserRegister>> GetAsync(SearchUserRegisterParametersDto searchRegisterParameters);
}