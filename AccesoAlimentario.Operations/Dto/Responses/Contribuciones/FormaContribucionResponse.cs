﻿namespace AccesoAlimentario.Operations.Dto.Responses.Contribuciones;

public abstract class FormaContribucionResponse
{
    public Guid Id { get; set; } = Guid.Empty;
    public DateTime FechaContribucion { get; set; } = DateTime.Now;
    public string Tipo { get; set; } = string.Empty;
}