using System;
using System.Collections.Generic;
using System.Web.Services;
using BLL;
using Entities;
using System.Web.Services.Protocols;

namespace ManagerSystem.Web
{
    /// <summary>
    /// Servicio web SOAP para la gestión de tareas.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class SOAPService : WebService
    {
        private readonly TareasLogic _tareasLogic;

        public SOAPService()
        {
            _tareasLogic = new TareasLogic();
        }

       
        [WebMethod]
        public Tareas CreateTask(int tareaID, int proyectoID, string descripcion, string estado, DateTime fechaLimite)
        {
            try
            {
                // Validaciones
                if (string.IsNullOrWhiteSpace(descripcion))
                {
                    throw new ArgumentException("La descripción no puede estar vacía.");
                }

                if (string.IsNullOrWhiteSpace(estado))
                {
                    throw new ArgumentException("El estado no puede estar vacío.");
                }

                if (fechaLimite < DateTime.Now)
                {
                    throw new ArgumentException("La fecha límite no puede ser anterior a la fecha actual.");
                }

                var nuevaTarea = new Tareas
                {
                    TareaID = tareaID,
                    ProyectoID = proyectoID,
                    Descripcion = descripcion,
                    Estado = estado,
                    FechaLimite = fechaLimite
                };

                return _tareasLogic.Create(nuevaTarea);
            }
            catch (ArgumentException ex)
            {
                throw new SoapException("Error de validación: " + ex.Message, SoapException.ClientFaultCode);
            }
            catch (Exception ex)
            {
                throw new SoapException("Error al crear la tarea: " + ex.Message, SoapException.ServerFaultCode);
            }
        }

        [WebMethod]
        public Tareas GetTaskById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("El ID de la tarea debe ser mayor a 0.");
                }

                return _tareasLogic.RetrieveById(id);
            }
            catch (ArgumentException ex)
            {
                throw new SoapException("Error de validación: " + ex.Message, SoapException.ClientFaultCode);
            }
            catch (Exception ex)
            {
                throw new SoapException("Error al obtener la tarea: " + ex.Message, SoapException.ServerFaultCode);
            }
        }

        [WebMethod]
        public bool UpdateTask(int tareaID, int proyectoID, string descripcion, string estado, DateTime fechaLimite)
        {
            try
            {
                // Validaciones
                if (tareaID <= 0)
                {
                    throw new ArgumentException("El ID de la tarea debe ser mayor a 0.");
                }

                if (string.IsNullOrWhiteSpace(descripcion))
                {
                    throw new ArgumentException("La descripción no puede estar vacía.");
                }

                if (string.IsNullOrWhiteSpace(estado))
                {
                    throw new ArgumentException("El estado no puede estar vacío.");
                }

                if (fechaLimite < DateTime.Now)
                {
                    throw new ArgumentException("La fecha límite no puede ser anterior a la fecha actual.");
                }

                var tareaActualizar = new Tareas
                {
                    TareaID = tareaID,
                    ProyectoID = proyectoID,
                    Descripcion = descripcion,
                    Estado = estado,
                    FechaLimite = fechaLimite
                };

                return _tareasLogic.Update(tareaActualizar);
            }
            catch (ArgumentException ex)
            {
                throw new SoapException("Error de validación: " + ex.Message, SoapException.ClientFaultCode);
            }
            catch (Exception ex)
            {
                throw new SoapException("Error al actualizar la tarea: " + ex.Message, SoapException.ServerFaultCode);
            }
        }

        [WebMethod]
        public bool DeleteTask(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("El ID de la tarea debe ser mayor a 0.");
                }

                return _tareasLogic.Delete(id);
            }
            catch (ArgumentException ex)
            {
                throw new SoapException("Error de validación: " + ex.Message, SoapException.ClientFaultCode);
            }
            catch (Exception ex)
            {
                throw new SoapException("Error al eliminar la tarea: " + ex.Message, SoapException.ServerFaultCode);
            }
        }

        [WebMethod]
        public List<Tareas> SearchTasksByDescription(string description)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(description))
                {
                    throw new ArgumentException("La descripción no puede estar vacía.");
                }

                return _tareasLogic.Filter(description);
            }
            catch (ArgumentException ex)
            {
                throw new SoapException("Error de validación: " + ex.Message, SoapException.ClientFaultCode);
            }
            catch (Exception ex)
            {
                throw new SoapException("Error al filtrar las tareas: " + ex.Message, SoapException.ServerFaultCode);
            }
        }
    }
}
