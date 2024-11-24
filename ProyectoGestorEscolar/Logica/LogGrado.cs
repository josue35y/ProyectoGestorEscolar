using ProyectoGestorEscolar.Acceso_de_datos;
using ProyectoGestorEscolar.Logica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestorEscolar.Logica
{
    public class LogGrado
    {
        public ResAgregarGrado AgregarGrado(ReqAgregarGrado req)
        {
            ResAgregarGrado res = new ResAgregarGrado();
            res.ListaErrores = new List<string>();

            try
            {
                if (req != null)
                {
                    if (req.grado.grado < 1 || req.grado.grado > 6)
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("El grado debe ser un valor entre 1 y 6");
                    }

                    if (req.grado.seccion < 1 || req.grado.seccion > 10)
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("La seccion debe ser un valor entre 1 y 10");
                    }

                    if (res.ListaErrores.Count == 0) // Procede solo si no hay errores previos
                    {
                        int? idReturn = 0;
                        int? idErrorId = 0;
                        string errorBD = "";


                        GestorEscolarConexionDataContext ConexionProyecto = new GestorEscolarConexionDataContext();
                        ConexionProyecto.SP_INGRESAR_GRADO(req.grado.grado, req.grado.seccion, ref idReturn, ref idErrorId, ref errorBD);

                        //errorBD = "CULO";
                        if (idReturn <= 0)
                        {
                            res.Resultado = true;
                            res.ListaErrores.Add(errorBD);
                        }
                        else
                        {
                            res.Resultado = true;
                        }
                    }
                }
                else
                {
                    res.Resultado = false;
                    res.ListaErrores.Add("Req null");
                }
            }
            catch (Exception ex)
            {
                res.Resultado = false;
                res.ListaErrores.Add($"ERROR GRAVE: {ex.Message}");
            }

            return res;
        }
        public ResEliminarGrado EliminarGrado(ReqEliminarGrado req)
        {
            ResEliminarGrado res = new ResEliminarGrado();
            res.ListaErrores = new List<string>();

            try
            {
                if (req != null)
                {
                    int? idReturn = 0;
                    int? idErrorId = 0;
                    string errorBD = "";

                    GestorEscolarConexionDataContext ConexionProyecto = new GestorEscolarConexionDataContext();
                    ConexionProyecto.SP_BORRAR_GRADO(req.grado.grado, req.grado.seccion, ref idReturn, ref idErrorId, ref errorBD);

                    //errorBD = "CULO";
                    if (idReturn <= 0)
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add(errorBD);
                    }
                    else
                    {
                        res.Resultado = true;
                    }
                }
                else
                {
                    res.Resultado = false;
                    res.ListaErrores.Add("Req null");
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
