namespace BackendTodoCode.Models;

public partial class Paquete
{
    public int IdPaquete { get; set; }

    public decimal CostoPaquete { get; set; }

    public virtual ICollection<VentaPaquete>? VentaPaquetes { get; set; } = new List<VentaPaquete>();

    public virtual ICollection<Servicio>? IdServicos { get; set; } = new List<Servicio>();
}
