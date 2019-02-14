using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.DataTransferObjects
{
    public static class MapperExtension
    {
        static MapperExtension()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<VacationDTO, VacationModel>().ReverseMap());
        }

        public static VacationModel ToVacationModel(this VacationDTO vacationDto)
        {
            return Mapper.Map<VacationModel>(vacationDto);
        }

        public static VacationDTO ToVacationDTO(this VacationModel vacationModel)
        {
            return Mapper.Map<VacationDTO>(vacationModel);
        }

        public static IEnumerable<VacationModel> ToVacationModel(this BaseResultOfVacationDTO baseResultOfVacationDto)
        {
            return baseResultOfVacationDto.Result.Select(ToVacationModel);
        }

        public static bool ToVacationModel(this BaseResultDTO baseResultDto)
        {
            return baseResultDto.Code == "OK";
        }
    }
}
