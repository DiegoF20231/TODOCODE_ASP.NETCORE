namespace BackendTodoCode.Models;

public partial class VentaPaquete
{
    public int IdVentaPaquete { get; set; }

    public int IdCliente { get; set; }

    public int IdEmpleado { get; set; }

    public int IdPaquete { get; set; }

    public DateTime FechaVenta { get; set; }

    public int IdMetodoPago { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; } = null!;

    public virtual Empleado? IdEmpleadoNavigation { get; set; } = null!;

    public virtual MetodoPago? IdMetodoPagoNavigation { get; set; } = null!;

    public virtual Paquete? IdPaqueteNavigation { get; set; } = null!;
}
