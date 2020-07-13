using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingApp.Controllers;

namespace BookingApp.Profiles
{
    public class ClientBookingProfile : Profile
    {
        public ClientBookingProfile()
        {
            CreateMap<Model.ClientBooking, DTO.ClientBookingDto>().ForMember(viewModel => viewModel.ClientBookingAddress, conf => conf.MapFrom(value => value.ClientBookingAddress));
            CreateMap<Model.ClientBookingAddress, DTO.ClientBookingAddressDto>();
            CreateMap<DTO.ClientBookingDto, Model.ClientBooking>().ForMember(viewModel => viewModel.ClientBookingAddress, conf => conf.MapFrom(value => value.ClientBookingAddress));
            CreateMap<DTO.ClientBookingAddressDto, Model.ClientBookingAddress>();
        }
    }
}
