﻿namespace AccesoAlimentario.Operations.Dto.Responses.Roles;

public class TecnicoResponse : RolResponse
{
    public AreaCoberturaResponse AreaCobertura { get; set; } = null!;
}

public class TecnicoResponseMinimo : RolResponseMinimo
{
    public AreaCoberturaResponse AreaCobertura { get; set; } = null!;
}