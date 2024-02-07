using AutoMapper;

namespace Portfolio_API;

public class UserProfile : Profile
{
    public UserProfile()
    {

        CreateMap<UserModel, ReadUserDto>();
        CreateMap<CreateUserDto, UserModel>();
        CreateMap<UpdateUserDto, UserModel>();
    }
}
