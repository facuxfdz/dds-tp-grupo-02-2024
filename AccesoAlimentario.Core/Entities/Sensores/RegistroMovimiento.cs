namespace AccesoAlimentario.Core.Entities.Sensores;

public class RegistroMovimiento
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime Date { get; set; } = DateTime.UtcNow;
    public bool Movimiento { get; set; } = false;

    public RegistroMovimiento()
    {
    }

    public RegistroMovimiento(DateTime date, bool movimiento)
    {
        Date = date;
        Movimiento = movimiento;
    }
}