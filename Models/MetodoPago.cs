namespace BackendTodoCode.Models;

public partial class MetodoPago
{
    public int IdMetodoPago { get; set; }

    public string MetodoPago1 { get; set; } = null!;

    public virtual ICollection<VentaPaquete>? VentaPaquetes { get; set; } = new List<VentaPaquete>();

    public virtual ICollection<VentaServicio>? VentaServicios { get; set; } = new List<VentaServicio>();
}
