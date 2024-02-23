using System;
using System.Collections.Generic;

namespace BackendTodoCode.Models;

public partial class Nacionalidad
{
    public int IdNacionalidad { get; set; }

    public string NombreNacionalidad { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
