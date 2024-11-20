using ProyectoGestorEscolar.Acceso_de_datos;
using ProyectoGestorEscolar.Logica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestorEscolar.Logica
{
    public class LogMateria
    {
        public ResAgregarMateria AgregarMateria(ReqAgregarMateria req)
        {
            ResAgregarMateria res = new ResAgregarMateria();
            res.ListaErrores = new List<string>();

            try
            {
                if (req != null)
                {
                    if (String.IsNullOrEmpty(req.materia.nombre))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Falta el usuario");
                    }

                    if (res.ListaErrores.Count == 0) // Procede solo si no hay errores previos
                    {
                        int? idReturn = 0;
                        int? idErrorId = 0;
                        string errorBD = "";


                        GestorEscolarConexionDataContext ConexionProyecto = new GestorEscolarConexionDataContext();
                        ConexionProyecto.SP_INGRESAR_MATERIA(req.materia.nombre, req.materia.descripcion, ref idErrorId, ref idErrorId, ref errorBD);


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

        public ResMostrarMaterias MostrarMaterias()
        {
            ResMostrarMaterias res = new ResMostrarMaterias();
            res.ListaErrores = new List<string>();
            res.ListaMaterias = new List<Materia>();
            try
            {
                GestorEscolarConexionDataContext ConexionProyecto = new GestorEscolarConexionDataContext();

                int? idReturn = 0;
                int? idErrorId = 0;
                string errorBD = "";
                string nombre = "";
                string descripcion = "";

                // Ejecutar el procedimiento almacenado
                ConexionProyecto.SP_MOSTRAR_MATERIAS(ref idReturn, ref idErrorId, ref errorBD, ref nombre, ref descripcion);

                // Validar si la ejecución fue exitosa
                if (idReturn <= 0)
                {
                    res.Resultado = false;
                    res.ListaErrores.Add(errorBD);
                }
                else
                {
                    res.Resultado = true;
                    res.ListaMaterias = ConexionProyecto.ExecuteQuery<Materia>("SELECT * FROM Materia").ToList();

                }
            }
            catch (Exception ex)
            {
                res.Resultado = false;
                res.ListaErrores.Add($"ERROR GRAVE: {ex.Message}");
            }
            return res;
        }

        public ResActualizarMateria ActualizarMateria(ReqActualizarMateria req)
        {
            ResActualizarMateria res = new ResActualizarMateria();
            res.ListaErrores = new List<string>();
            
            try
            {
                if (req != null)
                {
                    if (String.IsNullOrEmpty(req.NombreViejo))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Falta el nombre viejo de la materia");
                    }

                    if (String.IsNullOrEmpty(req.NombreNuevo))
                    {
                        res.Resultado = false;
                        res.ListaErrores.Add("Falta el nombre nuevo de la materia");
                    }

                    if (res.ListaErrores.Count == 0) // Procede solo si no hay errores previos
                    {
                        int? idReturn = 0;
                        int? idErrorId = 0;
                        string errorBD = "";

                        GestorEscolarConexionDataContext ConexionProyecto = new GestorEscolarConexionDataContext();

                        // Llamada al procedimiento almacenado para editar la materia
                        ConexionProyecto.SP_EDITAR_MATERIA(req.NombreViejo, req.NombreNuevo, req.NuevaDescripcion, ref idReturn, ref idErrorId, ref errorBD);

                        // Verificar si hubo un error al ejecutar el procedimiento
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

        public ResEliminarMateria EliminarMateria(ReqEliminarMateria req)
        {
            ResEliminarMateria res = new ResEliminarMateria();
            res.ListaErrores = new List<string>();
            string materia = req.materia.nombre;
            try
            {
                if (req != null)
                {
                    int? idReturn = 0;
                    int? idErrorId = 0;
                    string errorBD = "";

                    GestorEscolarConexionDataContext ConexionProyecto = new GestorEscolarConexionDataContext();
                    ConexionProyecto.SP_BORRAR_MATERIAS(materia, ref idReturn, ref idErrorId, ref errorBD);

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
