﻿using AutoMapper;
using Automaton.Contratos.Entorno;
using Automaton.Contratos.Helpers;
using Automaton.Logica.Dtos;
using Automaton.Logica.Dtos.Model;

namespace Automaton.ProfileMapping
{
    public class TableroProfile : Profile
    {
        public TableroProfile()
        {
            CreateMap<ITablero, TableroModel>()
                    .ForMember(m => m.TurnoRobot, y => y.MapFrom(m => m.TurnoRobot != null ? (int?)m.TurnoRobot.GetHashCode() : null))
                    ;

            CreateMap<IFilaTablero, FilaTableroModel>();

            CreateMap<ICasillero, CasilleroModel>()
                .ForMember(m => m.Muralla, y => y.MapFrom(m => m.Muralla != null ? (int?)m.Muralla.GetHashCode() : null))
                .ForMember(m => m.Robots, y => y.MapFrom(m => m.Robots != null ? m.Robots.Count : 0))
                .ForMember(m => m.RobotDuenio, y => y.MapFrom(m => m.ObtenerRobotLider() != null ? (int?)m.ObtenerRobotLider().GetHashCode() : null));

            CreateMap<TableroDto, TableroModel>()
                .ForMember(m => m.TurnoRobot, y => y.MapFrom(m => m.TurnoRobot != null ? (int?)m.TurnoRobot.GetHashCode() : null))
                .ForMember(m => m.Consola, y => y.MapFrom(m => m.Consola));
        }
    }
}