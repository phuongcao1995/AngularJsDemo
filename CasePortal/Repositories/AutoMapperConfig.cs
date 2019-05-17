using AutoMapper;
using CasePortal.Models;
using CasePortal.ViewModel;

namespace CasePortal.Repositories
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Log, LogViewModel>()
                  .ForMember(dest => dest.IncidentDate, opt => opt.MapFrom(src => src.IncidentDate.ToShortDateString()))
                  .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => src.CreateAt.Value.ToString("MMM d, yyyy")));

                cfg.CreateMap<Log, Log>().ForMember(dest => dest.IncidentTypeId, opt => opt.MapFrom(src => src.IncidentType.Id))
               .ForMember(dest => dest.DistrictId, opt => opt.MapFrom(src => src.District.Id));
                cfg.CreateMap<Medium, MediaViewModel>();
                cfg.CreateMap<Document, DocumentViewModel>();
            });
        }
    }
}