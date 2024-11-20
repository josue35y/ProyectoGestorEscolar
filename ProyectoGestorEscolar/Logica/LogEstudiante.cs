using ProyectoGestorEscolar.Acceso_de_datos;
using ProyectoGestorEscolar.Logica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestorEscolar.Logica
{
    public class LogEstudiante
    {
        public ResIngresarEstudiante IngresarEstudiante(ReqIngresarEstudiante req)
        {
            ResIngresarEstudiante res = new ResIngresarEstudiante();
            res.ListaErrores = new List<string>();

            try
            {
                if (req != null)
                {
                    if (String.IsNullOrEmpty(req.Estudiante.Usuario))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Falta el usuario");
                    }
                    if (String.IsNullOrEmpty(req.Estudiante.Pswd))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Faltan la contraseña");
                    }
                    if (String.IsNullOrEmpty(req.Estudiante.Nombres))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Falta el nombre");
                    }
                    if (String.IsNullOrEmpty(req.Estudiante.Apellidos))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Falta el apellido");
                    }
                    if (String.IsNullOrEmpty(req.Estudiante.Cedula))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Falta la Cedula");
                    }
                    if (String.IsNullOrEmpty(req.Estudiante.Direccion))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Falta la Cedula");
                    }
                    if (String.IsNullOrEmpty(req.Estudiante.Genero))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Falta el genero");
                    }
                    if (String.IsNullOrEmpty(req.Estudiante.Apellidos))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Falta el correo electrónico");
                    }
                    if (String.IsNullOrEmpty(req.Estudiante.FechaNacimiento.ToString()))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Falta la fecha de nacimiento");
                    }
                    if (String.IsNullOrEmpty(req.Estudiante.NombrePadre))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Falta el nombre del padre");
                    }
                    if (String.IsNullOrEmpty(req.Estudiante.ApellidosPadre))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Falta el apellido del padre");
                    }
                    if (String.IsNullOrEmpty(req.Estudiante.TelefonoPadre))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Falta el telefono del padre");
                    }

                    if (res.ListaErrores.Count == 0) // Procede solo si no hay errores previos
                    {
                        int? idReturn = 0;
                        int? idErrorId = 0;
                        string errorBD = "";

                        GestorEscolarConexionDataContext ConexionProyecto = new GestorEscolarConexionDataContext();
                        ConexionProyecto.SP_AGREGAR_ESTUDIANTE(req.Estudiante.Usuario, req.Estudiante.Pswd, req.Estudiante.Nombres,
                            req.Estudiante.Apellidos, req.Estudiante.Cedula, req.Estudiante.Direccion, req.Estudiante.Genero,
                            req.Estudiante.Email, req.Estudiante.FechaNacimiento, req.Estudiante.NombrePadre, req.Estudiante.ApellidosPadre,
                            req.Estudiante.TelefonoPadre, ref idReturn, ref idErrorId, ref errorBD);

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
        public ResActualizarEstudiante ActualizarEstudiante(ReqActualizarEstudiante req)
        {
            ResActualizarEstudiante res = new ResActualizarEstudiante();
            res.ListaErrores = new List<string>();

            try
            {
                if (String.IsNullOrEmpty(req.Estudiante.Cedula))
                {
                    res.Resultado = false;
                    res.ListaErrores.Add("Req null");
                }
                else
                {
                    int? idReturn = 0;
                    int? idErrorId = 0;
                    string errorBD = "";

                    GestorEscolarConexionDataContext ConexionProyecto = new GestorEscolarConexionDataContext();
                    ConexionProyecto.SP_ACTUALIZAR_ESTUDIANTE(req.Estudiante.Usuario, req.Estudiante.Pswd, req.Estudiante.Nombres,
                            req.Estudiante.Apellidos, req.Estudiante.Cedula, req.Estudiante.Direccion, req.Estudiante.Genero,
                            req.Estudiante.Email, req.Estudiante.FechaNacimiento, req.Estudiante.NombrePadre, req.Estudiante.ApellidosPadre,
                            req.Estudiante.TelefonoPadre, ref idReturn, ref idErrorId, ref errorBD);

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
        public ResBuscarEstudiante BuscarEstudiante(ReqBuscarEstudiante req)
        {
            ResBuscarEstudiante res = new ResBuscarEstudiante();
            res.ListaErrores = new List<string>();
            res.Estudiante = new Estudiante();

            try
            {
                if (String.IsNullOrEmpty(req.Estudiante.Cedula))
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
                    var resultado = ConexionProyecto.SP_BUSCAR_ESTUDIANTE(req.Estudiante.Cedula, ref idReturn, ref idErrorId,
                        ref errorBD);

                    if (idReturn >= 0)
                    {
                        res.Resultado = true;
                        res.Estudiante = resultado.Select(r => new Estudiante
                        {
                            Usuario = r.Usuario,
                            Pswd = r.Pswd,
                            Nombres = r.Nombres,
                            Apellidos = r.Apellidos,
                            Cedula = r.Cedula,
                            Direccion = r.Direccion,
                            Genero = r.Genero,
                            Email = r.Email,
                            FechaNacimiento = r.FechaNacimiento,
                            PrimerMatricula = r.PrimerMatricula,
                            NombrePadre = r.NombrePadre,
                            ApellidosPadre = r.ApellidosPadre,
                            TelefonoPadre = r.TelefonoPadre
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
        public ResEliminarEstudiante EliminarEstudiante(ReqEliminarEstudiante req)
        {
            ResEliminarEstudiante res = new ResEliminarEstudiante();
            res.ListaErrores = new List<string>();

            try
            {
                if (req != null)
                {
                    int? idReturn = 0;
                    int? idErrorId = 0;
                    string errorBD = "";

                    GestorEscolarConexionDataContext ConexionProyecto = new GestorEscolarConexionDataContext();
                    ConexionProyecto.SP_ELIMINAR_ESTUDIANTE(req.Estudiante.Cedula, ref idReturn, ref idErrorId, ref errorBD);

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
