using System;
using AutoMapper;
using TheLibrary.Models.Domain;
using TheLibrary.Models.DTOs.Responses;

namespace TheLibrary.Mapping
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
            CreateMap<Author, GetAuthorResponseDto>().ReverseMap();
			CreateMap<Book, GetBookResponseDto>().ReverseMap();
			CreateMap<Category, GetCategoryResponseDto>().ReverseMap();
			CreateMap<Country, GetCountryResponseDto>().ReverseMap();
			CreateMap<Reviewer, GetReviewerResponseDto>().ReverseMap();
			CreateMap<Review, GetReviewResponseDto>().ReverseMap();
        }

	}
}

