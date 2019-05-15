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
                  .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.District.Name))
                  .ForMember(dest => dest.IncidentTyleName, opt => opt.MapFrom(src => src.IncidentTyle.Name))
                  .ForMember(dest => dest.IncidentDate, opt => opt.MapFrom(src => src.IncidentDate.ToShortDateString()))
                  .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => src.CreateAt.Value.ToString("MMM d, yyyy")));

                cfg.CreateMap<Medium, MediaViewModel>();
                cfg.CreateMap<Document, DocumentViewModel>();
            });
        }
    }
}