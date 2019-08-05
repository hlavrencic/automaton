﻿using AutoMapper;
using Tablero = Automaton.Contratos.Entorno.Tablero;
using Automaton.Logica;
using Automaton.Logica.Robots;
using Automaton.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Automaton.Logica.Dtos;
using Automaton.Logica.Registro;

namespace Automaton.Web.Logica
{
    public class DirectorJuego : IDirectorJuego
    {
        private readonly IJuego2v2 juego;
        private readonly IRegistroVictorias registroRobots;
        private readonly IMapper mapper;
        private readonly IFabricaRobot fabricaRobot;

        public DirectorJuego(
            IJuego2v2 juego,
            IRegistroVictorias registroRobots,
            IMapper mapper,
            IFabricaRobot fabricaRobot)
        {
            this.juego = juego;
            this.registroRobots = registroRobots;
            this.mapper = mapper;
            this.fabricaRobot = fabricaRobot;
        }

        public PartidaResueltaDto Iniciar(string logicaRobot, string usuario)
        {
            // Agrego visitante
            AgregarRobot(logicaRobot, usuario);

            var logicaCampeon = registroRobots.ObtenerLogicaCampeon();
            if (logicaCampeon.HasValue)
            {
                // Agrego Local
                AgregarRobot(logicaCampeon.Value.Key, logicaCampeon.Value.Value);
            }
            else
            {
                // Agrego Local defensivo base
                var jugador = typeof(RobotDefensivo);
                AgregarRobot(jugador);
            }

            // Obtengo resultado de la partida
            var tableros = GetTableros(juego).ToArray();

            // Registro jugador ganador
            var usuarioGanador = juego.ObtenerUsuarioGanador();
            var logicaGanador = usuarioGanador == usuario ? logicaRobot : null;
            registroRobots.RegistrarVictoria(usuarioGanador, logicaGanador);

            return new PartidaResueltaDto
            {
                Tableros = tableros,
                Ganador = usuarioGanador,
                //MotivoDerrota = tableros.Last().Consola.Last()  TODO
            };
        }

        private void AgregarRobot(Type robotType)
        {
            var r = fabricaRobot.ObtenerRobot(robotType);
            juego.AgregarRobot(robotType.Name, r);
        }

        private Type AgregarRobot(string robotCode, string usuario)
        {
            var r = fabricaRobot.ObtenerRobot(robotCode);
            var tipo = r.GetType();
            juego.AgregarRobot(usuario, r);
            return tipo;
        }

        private IEnumerable<Tablero> GetTableros(IJuego2v2 juego)
        {
            {
                yield return juego.Tablero;
            }

            var turnoFinal = false;
            while (!turnoFinal)
            {
                var resultado = juego.JugarTurno();
                yield return juego.Tablero;
                turnoFinal = (resultado is TurnoFinalDto);
            }
        }
    }
}
