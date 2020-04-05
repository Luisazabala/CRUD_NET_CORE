using CRUD_NET_CORE.Clases;
using CRUD_NET_CORE.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_NET_CORE.Models.Abstract
{
    public interface IEmpleadoBusiness
    {
        Task guardarEmpleado(Empleado empleado);
        Task eliminarEmpleado(Empleado empleado);
        Task<IEnumerable<EmpleadoDetalle>> obtenerEmpleadosTodos();
        Task<Empleado> obtenerEmpleadoPorID(int? id);
        Task<List<CargoEmpleado>> obtenerCargoTodos();
        Task<IEnumerable<EmpleadoDetalle>> obtenerEmpleadosPorNombrePorId(string busqueda);


    }

}
