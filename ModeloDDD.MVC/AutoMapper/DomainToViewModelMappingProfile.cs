using AutoMapper;
using ModeloDDD.Domain.Entities;
using ModeloDDD.MVC.ViewModel;

namespace ModeloDDD.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
        }
        
    }
}