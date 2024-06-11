using System;
using AutoMapper;
using TheLibrary.Models.Domain;
using TheLibrary.Models.DTOs;
using TheLibrary.Models.DTOs.Requests;
using TheLibrary.Models.DTOs.Requests.Book;
using TheLibrary.Models.DTOs.Requests.Category;
using TheLibrary.Models.DTOs.Requests.Country;
using TheLibrary.Models.DTOs.Requests.Review;
using TheLibrary.Models.DTOs.Requests.Reviewer;
using TheLibrary.Models.DTOs.Responses;
using TheLibrary.Models.DTOs.Responses.Book;
using TheLibrary.Models.DTOs.Responses.Category;
using TheLibrary.Models.DTOs.Responses.Country;
using TheLibrary.Models.DTOs.Responses.Review;
using TheLibrary.Models.DTOs.Responses.Reviewer;

namespace TheLibrary.Mapping
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
            CreateMap<Author, GetAuthorResponseDto>().ReverseMap();
			CreateMap<Author, PostAuthorResponseDto>().ReverseMap();
			CreateMap<Author, PostAuthorRequestDto>().ReverseMap();
			CreateMap<Author, PutAuthorRequestDto>().ReverseMap();
			CreateMap<Author, PutAuthorResponseDto>().ReverseMap();
			CreateMap<Author, DeleteAuthorResponseDto>().ReverseMap();
			CreateMap<Author, AuthorDto>().ReverseMap();

			CreateMap<Book, GetBookResponseDto>().ReverseMap();
            CreateMap<PostBookRequestDto, Book>()
                        .ForMember(dest => dest.BookAuthors, opt => opt.Ignore())
                        .ForMember(dest => dest.BookCategories, opt => opt.Ignore());

            CreateMap<Book, PostBookResponseDto>()
                .ForMember(dest => dest.BookAuthors, opt => opt.MapFrom(src => src.BookAuthors.Select(ba => ba.AuthorId)))
                .ForMember(dest => dest.BookCategories, opt => opt.MapFrom(src => src.BookCategories.Select(bc => bc.CategoryId)));


            CreateMap<Book, PutBookRequestDto>().ReverseMap();
			CreateMap<Book, PutBookResponseDto>().ReverseMap();
			CreateMap<Book, DeleteBookResponseDto>().ReverseMap();
			CreateMap<Book, BookDto>().ReverseMap();
			



            CreateMap<Category, GetCategoryResponseDto>().ReverseMap();
			CreateMap<Category, PostCategoryResponseDto>().ReverseMap();
			CreateMap<Category, PostCategoryRequestDto>().ReverseMap();
			CreateMap<Category, PutCategoryResponseDto>().ReverseMap();
			CreateMap<Category, PutCategoryRequestDto>().ReverseMap();
			CreateMap<Category, DeleteCategoryResponseDto>().ReverseMap();
			CreateMap<Category, CategoryDto>().ReverseMap();
			

			CreateMap<Country, GetCountryResponseDto>().ReverseMap();
			CreateMap<Country, PostCountryResponseDto>().ReverseMap();
			CreateMap<Country, PostCountryRequestDto>().ReverseMap();
			CreateMap<Country, PutCountryResponseDto>().ReverseMap();
			CreateMap<Country, PutCountryRequestDto>().ReverseMap();
			CreateMap<Country, DeleteCountryResponseDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();

            CreateMap<Reviewer, GetReviewerResponseDto>().ReverseMap();
			CreateMap<Reviewer, PostReviewerResponseDto>().ReverseMap();
			CreateMap<Reviewer, PostReviewerRequestDto>().ReverseMap();
			CreateMap<Reviewer, PutReviewerResponseDto>().ReverseMap();
			CreateMap<Reviewer, PutReviewerRequestDto>().ReverseMap();
			CreateMap<Reviewer, DeleteReviewerResponseDto>().ReverseMap();
			CreateMap<Reviewer, ReviewerDto>().ReverseMap();

			CreateMap<Review, GetReviewResponseDto>().ReverseMap();
			CreateMap<Review, PostReviewResponseDto>().ReverseMap();
			CreateMap<Review, PostReviewRequestDto>().ReverseMap();
			CreateMap<Review, PutReviewRequestDto>().ReverseMap();
			CreateMap<Review, PutReviewResponseDto>().ReverseMap();
			CreateMap<Review, DeleteReviewResponseDto>().ReverseMap();
			CreateMap<Review, GetBookResponseDto>().ReverseMap();
			CreateMap<Review, ReviewDto>().ReverseMap();
			
			CreateMap<Review, ReviewerDto>().ReverseMap();
			

			CreateMap<BookAuthor, BookAuthorDto>().ReverseMap();
			CreateMap<AuthorDto, BookAuthorDto>().ReverseMap();
			CreateMap<BookDto, BookAuthorDto>().ReverseMap();

			CreateMap<BookCategory, BookCategoryDto>().ReverseMap();
            CreateMap<CategoryDto, BookCategoryDto>().ReverseMap();
			CreateMap<BookDto, BookCategoryDto>().ReverseMap();


        }

    }
}

