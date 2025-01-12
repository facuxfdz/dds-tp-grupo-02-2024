using AccesoAlimentario.Core.Entities.Direcciones;

namespace AccesoAlimentario.Core.Entities.Heladeras;

public class PuntoEstrategico
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Nombre { get; set; } = null!;
    public float Longitud { get; set; } = 0;
    public float Latitud { get; set; } = 0;
    public virtual Direccion Direccion { get; set; } = null!;

    public PuntoEstrategico()
    {
    }

    public PuntoEstrategico(string nombre, float longitud, float latitud, Direccion direccion)
    {
        Nombre = nombre;
        Longitud = longitud;
        Latitud = latitud;
        Direccion = direccion;
    }

    public void Actualizar(string nombre, float longitud, float latitud, Direccion direccion)
    {
        Nombre = nombre;
        Longitud = longitud;
        Latitud = latitud;
        Direccion.Actualizar(direccion.Calle, direccion.Numero, direccion.Localidad, direccion.CodigoPostal,
            direccion.Piso, direccion.Departamento);
    }
}