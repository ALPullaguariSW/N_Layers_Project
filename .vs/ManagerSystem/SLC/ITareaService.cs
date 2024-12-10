using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC
{
    public interface ITareaService
    {
        Tareas Create(Tareas tareas);
        Tareas RetrieveById(int id);
        bool Update(Tareas tareaToUpdate);
        bool Delete(int id);
    }
}
