﻿namespace Automaton.Logica.Robots
{
    using System.Collections.Generic;
    using Automaton.Contratos.Entorno;
    using Automaton.Contratos.Helpers;
    using Automaton.Contratos.Robots;

    /// <summary>
    /// El nombre de la clase es el nombre del usuario. 
    /// Por lo tanto siempre debes utilizar el mismo nombre en la creación de tu clase
    /// </summary>
    /// <example> MiRobotJose </example>
    public class RobotDefensivo : ARobot
    {
        ///<summary>El metodo que resuelve el proximo movimiento que el robot debe ejecutar</summary>
        ///<returns>Devuelve una accion según el estado actual del tablero.</returns>
        public override AccionRobotDto GetAccionRobot(IConsole console)
        {
            /// -------------------------------------
            /// Completar aqui con tu logica
            /// -------------------------------------

            /// -------------------------------------
            /// Prueba distintos ejemplos de movimiento --->
            

            //return MovimientoEjemplo1();
            //return MovimientoEjemplo2();
            return MovimientoEjemplo3();
        }

        private AccionRobotDto MovimientoEjemplo1()
        {
            // Obtengo el casillero donde estoy parado
            var casillero = this.GetPosition();

            // Verifico si ya construi una muralla. Sino envio la orden de construir una
            if (casillero.Muralla == null && casillero.Robots.Count == 1)
            {
                return new AccionConstruirDto() { };
            }

            //Si tengo lugar, intento moverme para arriba
            if (this.BuscarRelativo(DireccionEnum.Arriba) != null)
            {
                return new AccionMoverDto { Direccion = DireccionEnum.Arriba };
            }
            // Sino, intento moverme para abajo
            else if (this.BuscarRelativo(DireccionEnum.Abajo) != null)
            {
                return new AccionMoverDto { Direccion = DireccionEnum.Abajo };
            }

            // Si no se que hacer, devuelvo nulo. Y el juego termina.
            return null;
        }

        private AccionRobotDto MovimientoEjemplo2()
        {
            // Obtengo el casillero donde estoy parado
            var casillero = this.GetPosition();

            // Verifico si ya construi una muralla. Sino envio la orden de construir una
            if (casillero.Muralla == null && casillero.Robots.Count == 1)
            {
                return new AccionConstruirDto() { };
            }

            //Si tengo lugar, intento moverme para arriba
            if (this.BuscarRelativo(DireccionEnum.Arriba) != null && this.BuscarRelativo(DireccionEnum.Arriba).Muralla == null)
            {
                return new AccionMoverDto { Direccion = DireccionEnum.Arriba };
            }
            // Sino, intento moverme para abajo
            else if (this.BuscarRelativo(DireccionEnum.Abajo) != null && this.BuscarRelativo(DireccionEnum.Abajo).Muralla == null)
            {
                return new AccionMoverDto { Direccion = DireccionEnum.Abajo };
            }

            // Si no se que hacer, devuelvo nulo. Y el juego termina.
            return null;
        }

        private AccionRobotDto MovimientoEjemplo3()
        {
            // Obtengo el casillero donde estoy parado
            var casillero = this.GetPosition();

            // Verifico si ya construi una muralla. Sino envio la orden de construir una
            if (casillero.Muralla == null && casillero.Robots.Count == 1)
            {
                return new AccionConstruirDto() { };
            }

            //Si tengo lugar, intento moverme para arriba
            if (this.BuscarRelativo(DireccionEnum.Arriba) != null && this.BuscarRelativo(DireccionEnum.Arriba).Muralla == null)
            {
                return new AccionMoverDto { Direccion = DireccionEnum.Arriba };
            }
            // Sino, intento moverme para abajo
            else if (this.BuscarRelativo(DireccionEnum.Abajo) != null && this.BuscarRelativo(DireccionEnum.Abajo).Muralla == null)
            {
                return new AccionMoverDto { Direccion = DireccionEnum.Abajo };
            }
            // Sino, intento moverme para abajo
            else if (this.BuscarRelativo(DireccionEnum.Izquierda) != null && this.BuscarRelativo(DireccionEnum.Izquierda).Muralla == null)
            {
                return new AccionMoverDto { Direccion = DireccionEnum.Izquierda };
            }
            // Sino, intento moverme para abajo
            else if (this.BuscarRelativo(DireccionEnum.Derecha) != null && this.BuscarRelativo(DireccionEnum.Derecha).Muralla == null)
            {
                return new AccionMoverDto { Direccion = DireccionEnum.Derecha };
            }


            // Si no se que hacer, devuelvo nulo. Y el juego termina.
            return null;
        }
    }
}