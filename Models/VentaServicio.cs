namespace BackendTodoCode.Models;

public partial class VentaServicio
{
    public int IdVentaServicio { get; set; }

    public int IdCliente { get; set; }

    public int IdEmpleado { get; set; }

    public int IdServicio { get; set; }

    public DateTime FechaVenta { get; set; }

    public int IdMetodoPago { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; } = null!;

    public virtual Empleado? IdEmpleadoNavigation { get; set; } = null!;

    public virtual MetodoPago? IdMetodoPagoNavigation { get; set; } = null!;

    public virtual Servicio? IdServicioNavigation { get; set; } = null!;
}
