﻿using AccesoAlimentario.API.Domain.Premios;

namespace AccesoAlimentario.API.Domain.Colaboraciones.Contribuciones;

public class OfertaPremio : Contribucion
{
    public Premio Premio { get; set; } = null!;
    
}