using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly2.DTOs;
using Vidly2.Models;

namespace Vidly2.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();
            

            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MovieDTO, Movie>();

            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();
            Mapper.CreateMap<MembershipTypeDTO, MembershipType>();

            Mapper.CreateMap<Genre, GenreDTO>();
            Mapper.CreateMap<GenreDTO, Genre>();

            Mapper.CreateMap<CustomerDTO, Customer>().ForMember(x => x.CustomerId, opt => opt.Ignore());
            Mapper.CreateMap<MovieDTO, Movie>().ForMember(x => x.MovieId, opt => opt.Ignore());

        }
    }
}