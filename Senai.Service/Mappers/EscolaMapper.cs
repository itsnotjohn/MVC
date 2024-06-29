﻿using AutoMapper;
using Senai.Domain.DTos;
using Senai.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Service.Mappers
{
    public class EscolaMapper : Profile
    {
        public EscolaMapper() 
        {
            CreateMap<EscolaDto, Escola>()
                //.ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));
                .ReverseMap();
        }
    }
}
