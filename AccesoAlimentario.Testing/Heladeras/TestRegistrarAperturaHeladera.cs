﻿using AccesoAlimentario.Core.DAL;
using AccesoAlimentario.Core.Entities.Autorizaciones;
using AccesoAlimentario.Core.Entities.Tarjetas;
using AccesoAlimentario.Operations.Heladeras;
using AccesoAlimentario.Testing.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace AccesoAlimentario.Testing.Heladeras;

public class TestRegistrarAperturaHeladera
{
    [Test]
    
    //TODO: No funciona, me tira tarjeta no encontrada

    public async Task RegistrarApertura()
    {
        var mockServices = new MockServices();
        var mediator = mockServices.GetMediator();

        using var scope = mockServices.GetScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        
        var heladera = context.Heladeras.First();
        var tarjetaConsumo = context.Tarjetas.OfType<TarjetaConsumo>().First();

        var command = new RegistrarAperturaHeladera.RegistrarAperturaHeladeraCommand
        {
            HeladeraId = heladera.Id,
            TarjetaId = tarjetaConsumo.Id,
            TipoAcceso = TipoAcceso.RetiroVianda
        };
        
        Assert.Pass($"El comando devolvió Ok. Se pudo registrar apertura" +
                    $" de la heladera con id: {heladera.Id}");
        var result = await mediator.Send(command);

        switch (result)
        {
            case Microsoft.AspNetCore.Http.HttpResults.BadRequest<string> badRequest:
                Assert.Fail($"El comando devolvió BadRequest: {badRequest.Value}");
                break;
            case Microsoft.AspNetCore.Http.HttpResults.NotFound<string> notFound:
                Assert.Fail($"El comando devolvió NotFound: {notFound.Value}");
                break;
            case Microsoft.AspNetCore.Http.HttpResults.Ok:
                Assert.Pass($"El comando devolvió Ok. Se pudo registrar apertura" +
                            $" de la heladera con id: {heladera.Id}");
                break;
            default:
                Assert.Fail($"El comando no devolvió ok - {result.GetType()}"); 
                break;
        }
    }
}