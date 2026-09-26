using AutoMapper;
using Steam.Domain.Model;
using Steam.Application.DTOs.AuthDTOs;
using Steam.Application.DTOs;
using Steam.Application.DTOs.UserDTOs;
using Steam.Application.DTOs.GameDTOs;
using Steam.Application.DTOs.GenreDTOs;
using Steam.Application.DTOs.TagDTOs;
using Steam.Application.DTOs.ProviderDTOs;
using Steam.Application.DTOs.MediaDTOs;
using Steam.Application.DTOs.SystemRequirementsDTOs;
using Steam.Application.DTOs.AchievementDTOs;

namespace Steam.Application.Mapping;

public class SteamProfile : Profile
{
    public SteamProfile()
    {
        CreateMap<ExternalAuthDTO, User>();

        CreateMap<UserCreateDTO, User>();
        CreateMap<User, UserDTO>();
        CreateMap<GameCreateDTO, Game>();
        CreateMap<Game, GameDTO>();

        CreateMap<Genre, GenreDTO>();
        CreateMap<Tag, TagDTO>();
        CreateMap<Provider, ProviderDTO>();
        CreateMap<MediaCreateDTO, Media>();
        CreateMap<Media, MediaDTO>();

        CreateMap<SystemRequirementsCreateDTO, SystemRequirements>();
        CreateMap<SystemRequirements, SystemRequirementsDTO>();

        CreateMap<AchievementCreateDTO, Achievement>();
        CreateMap<Achievement, AchievementDTO>();
    }
}