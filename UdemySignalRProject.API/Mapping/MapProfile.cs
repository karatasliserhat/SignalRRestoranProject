using AutoMapper;
using UdemySignalRProject.DTO.Dtos;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.API.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<About, GetAboutDto>().ReverseMap();
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();

            CreateMap<About, GetBookingDto>().ReverseMap();
            CreateMap<About, ResultBookingDto>().ReverseMap();
            CreateMap<About, CreateBookingDto>().ReverseMap();
            CreateMap<About, UpdateBookingDto>().ReverseMap();

            CreateMap<About, GetCategoryDto>().ReverseMap();
            CreateMap<About, ResultCategoryDto>().ReverseMap();
            CreateMap<About, CreateCategoryDto>().ReverseMap();
            CreateMap<About, UpdateCategoryDto>().ReverseMap();

            CreateMap<About, GetContactDto>().ReverseMap();
            CreateMap<About, ResultContactDto>().ReverseMap();
            CreateMap<About, CreateContactDto>().ReverseMap();
            CreateMap<About, UpdateContactDto>().ReverseMap();

            CreateMap<About, GetDicsountDto>().ReverseMap();
            CreateMap<About, ResultDiscountDto>().ReverseMap();
            CreateMap<About, CreateDiscountDto>().ReverseMap();
            CreateMap<About, UpdateDiscountDto>().ReverseMap();

            CreateMap<About, GetFeatureDto>().ReverseMap();
            CreateMap<About, ResultFeatureDto>().ReverseMap();
            CreateMap<About, CreateFeatureDto>().ReverseMap();
            CreateMap<About, UpdateFeatureDto>().ReverseMap();

            CreateMap<About, GetProductDto>().ReverseMap();
            CreateMap<About, ResultProductDto>().ReverseMap();
            CreateMap<About, CreateProductDto>().ReverseMap();
            CreateMap<About, UpdateProductDto>().ReverseMap();

            CreateMap<About, GetSocialMediaDto>().ReverseMap();
            CreateMap<About, ResultSocialMediaDto>().ReverseMap();
            CreateMap<About, CreateSocialMediaDto>().ReverseMap();
            CreateMap<About, UpdateSocialMediaDto>().ReverseMap();

            CreateMap<About, GetTestimonialDto>().ReverseMap();
            CreateMap<About, ResultTestimonialDto>().ReverseMap();
            CreateMap<About, CreateTestimonialDto>().ReverseMap();
            CreateMap<About, UpdateTestimonialDto>().ReverseMap();
        }
    }
}
