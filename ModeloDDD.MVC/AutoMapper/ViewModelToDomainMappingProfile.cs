using AutoMapper;
using ModeloDDD.Domain.Entities;
using ModeloDDD.MVC.ViewModel;

namespace ModeloDDD.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
        }
    }
}