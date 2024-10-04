using AutoMapper;
using WhiteWebTech.API.Entities;
using WhiteWebTech.API.Models;

namespace WhiteWebTech.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {

            var mappingconfig = new MapperConfiguration(config =>
            {
                config.CreateMap<NewQuery, NewQueryDTO>();
                config.CreateMap<NewQueryDTO, NewQuery>();
                config.CreateMap<JobsDTO, Job>();
                config.CreateMap<Job, JobsDTO>();
                config.CreateMap<Applicant,ApplicantDTO>();
                config.CreateMap<ApplicantDTO,Applicant>();

            });
            return mappingconfig;
        }

    }
}
