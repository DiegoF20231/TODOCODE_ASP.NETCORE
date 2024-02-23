namespace BackendTodoCode.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string NombreEmpleado { get; set; } = null!;

    public string ApellidoEmpleado { get; set; } = null!;

    public string DireccionEmpleado { get; set; } = null!;

    public string Dniempleado { get; set; } = null!;

    public string FechaNacimiento { get; set; } = null!;

    public int IdNacionalidad { get; set; }

    public string CelularEmpleado { get; set; } = null!;

    public string EmailEmpleado { get; set; } = null!;

    public string Cargo { get; set; } = null!;

    public decimal Sueldo { get; set; }

    public virtual Nacionalidad? IdNacionalidadNavigation { get; set; } = null!;

    public virtual ICollection<VentaPaquete>? VentaPaquetes { get; set; } = new List<VentaPaquete>();

    public virtual ICollection<VentaServicio>? VentaServicios { get; set; } = new List<VentaServicio>();
}
