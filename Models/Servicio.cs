namespace BackendTodoCode.Models;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public string NombreServicio { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string DestinoServicio { get; set; } = null!;

    public DateTime FechaServicio { get; set; }

    public decimal CostoServicio { get; set; }

    public virtual ICollection<VentaServicio>? VentaServicios { get; set; } = new List<VentaServicio>();

    public virtual ICollection<Paquete>? IdPaquetes { get; set; } = new List<Paquete>();
}
