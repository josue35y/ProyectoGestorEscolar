﻿using ProyectoGestorEscolar.Acceso_de_datos;
using ProyectoGestorEscolar.Logica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestorEscolar.Logica
{
    public class LogPeriodo
    {
        public ResIngresarPeriodo IngresarPeriodo(ReqIngresarPeriodo req)
        {
            ResIngresarPeriodo res = new ResIngresarPeriodo();
            res.ListaErrores = new List<string>();
           
            try
            {
                // Validar que req no sea null
                if (req == null)
                {
                    res.Resultado = false;
                    res.ListaErrores.Add("El objeto de solicitud es nulo.");
                    return res;
                }

                // Validar año entre 1900 y 3000
                if (req.periodo.ano < 1900 || req.periodo.ano > 3000)
                {
                    res.Resultado = false;
                    res.ListaErrores.Add("El año del periodo debe ser un valor entre 1900 y 3000.");
                }

                // Validar ciclo sea I, II o III
                if (req.periodo.ciclo != "I" && req.periodo.ciclo != "II" && req.periodo.ciclo != "III")
                {
                    res.Resultado = false;
                    res.ListaErrores.Add("El ciclo del periodo debe ser 'I', 'II' o 'III'.");
                }

                // Si hay errores hasta este punto, retornar inmediatamente
                if (res.ListaErrores.Count > 0)
                {
                    res.Resultado = false;
                    return res;
                }

                // Si no hay errores, proceder con la inserción
                int? idReturn = 0;
                int? idErrorId = 0;
                string errorBD = "";

                // Realizar la conexión con la base de datos y llamar al procedimiento almacenado
                GestorEscolarConexionDataContext ConexionProyecto = new GestorEscolarConexionDataContext();
                ConexionProyecto.SP_INGRESAR_PERIODO(req.periodo.ano, req.periodo.ciclo, ref idReturn, ref idErrorId, ref errorBD);

                if (idReturn <= 0)
                {
                    res.Resultado = false;
                    res.ListaErrores.Add($"Error en la base de datos: {errorBD}");
                }
                else
                {
                    res.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                res.Resultado = false;
                res.ListaErrores.Add($"ERROR GRAVE: {ex.Message}");
            }

            return res;
        }

        public ResMostrarPeriodos MostrarPeriodos()
        {
            ResMostrarPeriodos res = new ResMostrarPeriodos();
            res.ListaErrores = new List<string>();
            res.listaPeriodos = new List<Periodo>();
            try
            {
                GestorEscolarConexionDataContext ConexionProyecto = new GestorEscolarConexionDataContext();

                int? idReturn = 0;
                int? idErrorId = 0;
                string errorBD = "";

                // Ejecutar el procedimiento almacenado
                ConexionProyecto.SP_MOSTRAR_PERIODOS(ref idReturn, ref idErrorId, ref errorBD);

                // Validar si la ejecución fue exitosa
                if (idReturn <= 0)
                {
                    res.Resultado = false;
                    res.ListaErrores.Add(errorBD);
                }
                else
                {
                    res.Resultado = true;
                    res.listaPeriodos = ConexionProyecto.ExecuteQuery<Periodo>("SELECT ano, ciclo FROM Periodo").ToList();
                }
            }
            catch (Exception ex)
            {
                res.Resultado = false;
                res.ListaErrores.Add($"ERROR GRAVE: {ex.Message}");
            }
            return res;
        }


        //culo
        public ResEliminarPeriodo EliminarPeriodo(ReqEliminarPeriodo req)
        {
            ResEliminarPeriodo res = new ResEliminarPeriodo();
            res.ListaErrores = new List<string>();
            try
            {
                // Validar que req no sea null
                if (req == null)
                {
                    res.Resultado = false;
                    res.ListaErrores.Add("El objeto de solicitud es nulo.");
                    return res;
                }

                // Validar que el periodo no sea nulo
                if (req.periodo == null)
                {
                    res.Resultado = false;
                    res.ListaErrores.Add("El objeto periodo es nulo.");
                    return res;
                }

                // Validar que el año del periodo sea mayor que 0
                if (req.periodo.ano <= 0)
                {
                    res.Resultado = false;
                    res.ListaErrores.Add("El año debe ser un valor positivo.");
                    return res;
                }

                // Validar que el ciclo no sea nulo o vacío
                if (string.IsNullOrWhiteSpace(req.periodo.ciclo))
                {
                    res.Resultado = false;
                    res.ListaErrores.Add("El ciclo no puede ser nulo o vacío.");
                    return res;
                }

                // Variables para el procedimiento almacenado
                int? idReturn = 0;
                int? idErrorId = 0;
                string errorBD = "";

                // Realizar la conexión con la base de datos y llamar al procedimiento almacenado
                using (GestorEscolarConexionDataContext ConexionProyecto = new GestorEscolarConexionDataContext())
                {
                    // Llamar al procedimiento almacenado con Año y Ciclo del periodo
                    ConexionProyecto.SP_ELIMINAR_PERIODOS(
                        req.periodo.ano,
                        req.periodo.ciclo,
                        ref idReturn,
                        ref idErrorId,
                        ref errorBD
                    );

                    if (idReturn <= 0)
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add($"Error en la base de datos: {errorBD}");
                    }
                    else
                    {
                        res.Resultado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                res.Resultado = false;
                res.ListaErrores.Add($"ERROR GRAVE: {ex.Message}");
            }
            return res;
        }

    }
}
