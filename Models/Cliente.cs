namespace BackendTodoCode.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }
    public string? NombreCliente { get; set; } = null!;

    public string? ApellidoCliente { get; set; } = null!;

    public string? DireccionCliente { get; set; } = null!;

    public string? Dniempleado { get; set; } = null!;

    public string? FechaNacimiento { get; set; } = null!;

    public int? IdNacionalidad { get; set; }

    public int? CelularCliente { get; set; }

    public string? EmailCliente { get; set; } = null!;

    public virtual Nacionalidad? IdNacionalidadNavigation { get; set; } = null!;

    public virtual ICollection<VentaPaquete>? VentaPaquetes { get; set; } = new List<VentaPaquete>();

    public virtual ICollection<VentaServicio>? VentaServicios { get; set; } = new List<VentaServicio>();
}
