﻿using System.Text.Json.Serialization;
using AccesoAlimentario.Operations.Dto.Responses.Personas;

namespace AccesoAlimentario.Operations.Dto.Responses.Roles;

public abstract class RolResponse
{
    public Guid Id { get; set; } = Guid.Empty;
    public PersonaResponse Persona { get; set; } = null!;
    public string Tipo { get; set; } = string.Empty;
}

public abstract class RolResponseMinimo
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Tipo { get; set; } = string.Empty;
}