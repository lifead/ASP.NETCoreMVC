using AutoMapper;
using System.Linq;
using WebStore.Domain.Entities.Identity;
using WebStore.Domain.Entities.Products;
using WebStore.Domain.ViewModels.Identity;
using WebStore.Domain.ViewModels.Product;

namespace WebStore.Infrastructure.AutoMapper
{
    public class ViewModelMapping : Profile
    {
        public ViewModelMapping()
        {
            CreateMap<Brand, BrandViewModel>().ReverseMap();
            CreateMap<RegisterUserViewModel, User>()
                .ForMember(user=>user.UserName, x=>x.MapFrom(model=> model.UserName));
        }
    }
}
