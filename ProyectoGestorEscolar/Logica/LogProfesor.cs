using ProyectoGestorEscolar.Logica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoGestorEscolar.Acceso_de_datos;

namespace ProyectoGestorEscolar.Logica
{
    public class LogProfesor
    {
        public ResIngresarProfesor IngresarProfesor(ReqIngresarProfesor req)
        {
            ResIngresarProfesor res = new ResIngresarProfesor();
            res.ListaErrores = new List<string>();

            try
            {
                if (req != null)
                {
                    if (String.IsNullOrEmpty(req.Profesor.NombreUsuario))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Falta el usuario");
                    }
                    if (String.IsNullOrEmpty(req.Profesor.PSWD))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Faltan la contraseña");
                    }
                    if (String.IsNullOrEmpty(req.Profesor.Nombre))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Falta el nombre");
                    }
                    if (String.IsNullOrEmpty(req.Profesor.Apellidos))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Falta los apellidos");
                    }
                    if (String.IsNullOrEmpty(req.Profesor.Cedula))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Falta la cedula");
                    }
                    
                    if (String.IsNullOrEmpty(req.Profesor.Telefono))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Falta el Telefono");
                    }
                    if (String.IsNullOrEmpty(req.Profesor.Genero))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Falta el genero");
                    }
                    if (String.IsNullOrEmpty(req.Profesor.Correo))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Falta el correo");
                    }

                    if (res.ListaErrores.Count == 0) // Procede solo si no hay errores previos
                    {
                        int? idReturn = 0;
                        int? idErrorId = 0;
                        string errorBD = "";

                        GestorEscolarConexionDataContext ConexionProyecto = new GestorEscolarConexionDataContext();
                        ConexionProyecto.SP_AGREGAR_PROFESOR(req.Profesor.NombreUsuario, req.Profesor.PSWD,
                            req.Profesor.Nombre, req.Profesor.Apellidos, req.Profesor.Cedula, 
                            req.Profesor.Telefono, req.Profesor.Genero, req.Profesor.Correo, 
                            ref idReturn, ref idErrorId, ref errorBD);

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
        public ResActualizarProfesor ActualizarProfesor(ReqActualizarProfesor req)
        {
            ResActualizarProfesor res = new ResActualizarProfesor();
            res.ListaErrores = new List<string>();

            try
            {
                if (String.IsNullOrEmpty(req.Profesor.Cedula))
                {
                    res.Resultado = false;
                    res.ListaErrores.Add("Cedula no especificada");
                }
                else
                {
                    int? idReturn = 0;
                    int? idErrorId = 0;
                    string errorBD = "";

                    GestorEscolarConexionDataContext ConexionProyecto = new GestorEscolarConexionDataContext();
                    ConexionProyecto.SP_ACTUALIZAR_PROFESOR(req.Profesor.NombreUsuario, req.Profesor.PSWD,
                            req.Profesor.Nombre, req.Profesor.Apellidos, req.Profesor.Cedula,
                            req.Profesor.Telefono, req.Profesor.Genero, req.Profesor.Correo,
                            ref idReturn, ref idErrorId, ref errorBD);

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
            }
            catch (Exception ex)
            {
                res.Resultado = false;
                res.ListaErrores.Add($"ERROR GRAVE: {ex.Message}");
            }
            return res;
        }
        public ResBuscarProfesor BuscarProfesor(ReqBuscarProfesor req)
        {
            ResBuscarProfesor res = new ResBuscarProfesor();
            res.ListaErrores = new List<string>();

            try
            {
                if (String.IsNullOrEmpty(req.Profesor.Cedula))
                {
                    res.Resultado = false;
                    res.ListaErrores.Add("Cedula no especificada");
                }
                else
                {
                    int? idReturn = 0;
                    int? idErrorId = 0;
                    string errorBD = "";

                    GestorEscolarConexionDataContext ConexionProyecto = new GestorEscolarConexionDataContext();
                    var resultado = ConexionProyecto.SP_BUSCAR_PROFESOR(req.Profesor.Cedula, ref idReturn, ref idErrorId,
                        ref errorBD);

                    if (idReturn >= 0)
                    {
                        res.Resultado = true;
                        res.Profesor = resultado.Select(r => new Profesor
                        {
                            NombreUsuario = r.NombreUsuario,
                            PSWD = r.PSWD,
                            Nombre = r.Nombre,
                            Apellidos = r.Apellidos,
                            FechaInicio = (DateTime)r.FechaInicio,
                            Telefono = r.Telefono,
                            Cedula = r.Cedula,
                            Genero = r.Genero,
                            Correo = r.Correo
                        }).FirstOrDefault();
                    }
                    else
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add(errorBD);
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
        public ResEliminarProfesor EliminarProfesor(ReqEliminarProfesor req)
        {
            ResEliminarProfesor res = new ResEliminarProfesor();
            res.ListaErrores = new List<string>();

            try
            {
                if (req != null)
                {
                    int? idReturn = 0;
                    int? idErrorId = 0;
                    string errorBD = "";

                    GestorEscolarConexionDataContext ConexionProyecto = new GestorEscolarConexionDataContext();
                    ConexionProyecto.SP_ELIMINAR_PROFESOR(req.Profesor.Cedula, ref idReturn, ref idErrorId, ref errorBD);

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

