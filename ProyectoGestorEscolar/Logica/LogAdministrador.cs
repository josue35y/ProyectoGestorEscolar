using ProyectoGestorEscolar.Acceso_de_datos;
using ProyectoGestorEscolar.Logica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestorEscolar.Logica
{
    public class LogAdministrador
    {
        public ResIngresarAdministrador InsertarAdministrador(ReqInsertarAdministrador req)
        {
            ResIngresarAdministrador res = new ResIngresarAdministrador();
            res.ListaErrores = new List<string>();

            try
            {
                if (req != null)
                {
                    if (String.IsNullOrEmpty(req.Administrador.Usuario))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Falta el usuario");
                    }
                    if (String.IsNullOrEmpty(req.Administrador.Pswd))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Faltan la contraseña");
                    }
                    if (String.IsNullOrEmpty(req.Administrador.Nombre))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Falta el nombre");
                    }
                    if (String.IsNullOrEmpty(req.Administrador.Apellido))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Falta el apellido");
                    }
                    if (String.IsNullOrEmpty(req.Administrador.Cedula))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Falta la Cedula");
                    }                    

                    if (res.ListaErrores.Count == 0) // Procede solo si no hay errores previos
                    {
                        int? idReturn = 0;
                        int? idErrorId = 0;
                        string errorBD = "";


                        GestorEscolarConexionDataContext GestorConexion = new GestorEscolarConexionDataContext();
                        GestorConexion.SP_AGREGAR_ADMINISTRADOR(req.Administrador.Usuario, req.Administrador.Pswd, req.Administrador.Nombre,
                            req.Administrador.Apellido, req.Administrador.Cedula, req.Administrador.FechaInico, ref idReturn, ref idErrorId, ref errorBD);


 
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
        public ResActualizarAdministrador ActualizarAdministrador(ReqActualizarAdministrador req)
        {
            ResActualizarAdministrador res = new ResActualizarAdministrador();
            res.ListaErrores = new List<string>();

            try
            {
                if (String.IsNullOrEmpty(req.Administrador.Cedula))
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
                    ConexionProyecto.SP_ACTUALIZAR_ADMINISTRADOR(req.Administrador.Usuario, req.Administrador.Pswd,
                        req.Administrador.Nombre, req.Administrador.Apellido, req.Administrador.Cedula, 
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
        public ResBuscarAdministrador BuscarAdministrador(ReqBuscarAdministrador req)
        {
            ResBuscarAdministrador res = new ResBuscarAdministrador();
            res.ListaErrores = new List<string>();
            res.Administrador = new Administrador();

            try
            {
                if (String.IsNullOrEmpty(req.Administrador.Cedula))
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
                    var resultado = ConexionProyecto.SP_BUSCAR_ADMINISTRADOR(req.Administrador.Cedula, 
                        ref idReturn, ref idErrorId, ref errorBD);

                    if (idReturn >= 0)
                    {
                        res.Resultado = true;
                        res.Administrador = resultado.Select(r => new Administrador
                        {
                            Usuario = r.Usuario,
                            Pswd = r.Pswd,
                            Nombre = r.Nombre,
                            Apellido = r.Apellido,
                            Cedula = r.Cedula,
                            FechaInico = (DateTime)r.FechaInicio
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

        public ResEliminarAdministrador EliminarAdministrador(ReqEliminarAdministrador req)
        {
            ResEliminarAdministrador res = new ResEliminarAdministrador();
            res.ListaErrores = new List<string>();

            try
            {
                if (req != null)
                {
                    int? idReturn = 0;
                    int? idErrorId = 0;
                    string errorBD = "";

                    GestorEscolarConexionDataContext ConexionProyecto = new GestorEscolarConexionDataContext();
                    ConexionProyecto.SP_ELIMINAR_ADMINISTRADOR(req.Administrador.Cedula, ref idReturn, 
                        ref idErrorId, ref errorBD);

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
