using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TareasLogic
    {
        public Tareas Create(Tareas tareas)
        {
            Tareas tar = null;
            
            using (var t = RepositoryFactory.CreateRepository())
            {
                Tareas result = t.Retrieve<Tareas>(p=> p.TareaID == tareas.TareaID);
                if (result == null)
                {
                    tar = t.Create<Tareas>(tareas);
                }
                else
                {
                    throw new InvalidOperationException("La tarea ya existe.");
                }
                return tar;
            }
            
        }
        public Tareas RetrieveById(int id)
        {
            Tareas tar= null;
            using (var t = RepositoryFactory.CreateRepository())
            {
                tar = t.Retrieve<Tareas>(p => p.TareaID == id);
            }
            return tar;
        }

        public bool Update(Tareas tareaToUpdate) 
        {
            bool tar = false;
            using (var t = RepositoryFactory.CreateRepository())
            {
                Tareas temp = t.Retrieve<Tareas>(p => p.TareaID == tareaToUpdate.TareaID);
                if (temp != null)
                {
                    tar = t.Update<Tareas>(tareaToUpdate);
                }
                else
                {
                    throw new InvalidOperationException("La tarea no existe.");
                }
            }
            return tar;
        }
        public bool Delete(int id)
        {
            bool tar = false;

            var tarea = RetrieveById(id);

            if (tarea != null)
            {
                using (var t = RepositoryFactory.CreateRepository())
                {
                    tar = t.Delete<Tareas>(tarea);
                }

            }
            else
            {
                throw new InvalidOperationException("La tarea no existe.");
            }
            return tar;
        }

        public List<Tareas> Filter(string name)
        {
            List<Tareas> tar = null;
            using (var repository = RepositoryFactory.CreateRepository())
            {
                tar = repository.Filter<Tareas>(p => p.Descripcion.Contains(name));
            }
            return tar;
        }

    }
}
