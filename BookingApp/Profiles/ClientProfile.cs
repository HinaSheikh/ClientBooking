using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace BookingApp.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            //Mapping for Get Client
            CreateMap<Model.Client, DTO.ClientDto>().ForMember(viewModel => viewModel.ClientBooking, conf => conf.MapFrom(value => value.ClientBooking));
            CreateMap<Model.ClientBooking, DTO.ClientBookingDto>();
            CreateMap<Model.ClientContact, DTO.ClientContactDto>();
            //Mapping for Post and Put operations
            CreateMap<DTO.ClientDto, Model.Client>().ForMember(viewModel => viewModel.ClientBooking, conf => conf.MapFrom(value => value.ClientBooking));
            CreateMap<DTO.ClientBookingDto, Model.ClientBooking>();
            CreateMap<DTO.ClientContactDto, Model.ClientContact>();

        }
    }
}
