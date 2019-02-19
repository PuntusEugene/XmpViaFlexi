using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.DataTransferObjects
{
    public static class MapperExtension
    {
        static MapperExtension()
        {
            Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<VacationDTO, VacationModel>().ReverseMap();
                    cfg.CreateMap<UserCredentialDTO, UserCredentialModel>().ReverseMap();
                });
        }

        public static VacationModel ToVacationModel(this VacationDTO vacationDto)
        {
            return Mapper.Map<VacationModel>(vacationDto);
        }

        public static VacationDTO ToVacationDTO(this VacationModel vacationModel)
        {
            return Mapper.Map<VacationDTO>(vacationModel);
        }

        public static UserCredentialModel ToVacationModel(this UserCredentialDTO vacationDto)
        {
            return Mapper.Map<UserCredentialModel>(vacationDto);
        }

        public static UserCredentialDTO ToVacationDTO(this UserCredentialModel vacationModel)
        {
            return Mapper.Map<UserCredentialDTO>(vacationModel);
        }

        public static VacationModel ToVacationModel(this BaseResultOfVacationDTO baseResultOfVacationDto)
        {
            return baseResultOfVacationDto.Vacation.ToVacationModel();
        }

        public static IEnumerable<VacationModel> ToVacationModel(this BaseResultOfVacationCollectionDTO baseResultOfVacationCollectionDto)
        {
            return baseResultOfVacationCollectionDto.Collection.Select(ToVacationModel);
        }

        public static bool ToVacationModel(this BaseResultDTO baseResultDto)
        {
            return baseResultDto.Code == "OK";
        }
    }
}
