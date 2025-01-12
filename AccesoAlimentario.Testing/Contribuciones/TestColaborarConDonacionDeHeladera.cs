﻿using AccesoAlimentario.Core.DAL;
using AccesoAlimentario.Core.Entities.Contribuciones;
using AccesoAlimentario.Core.Entities.Roles;
using AccesoAlimentario.Operations.Contribuciones;
using AccesoAlimentario.Testing.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace AccesoAlimentario.Testing.Contribuciones;

public class TestColaborarConDonacionDeHeladera
{
    [Test]

    public async Task TestDonacionDeHeladera()
    {
        var mockServices = new MockServices();
        var mediator = mockServices.GetMediator();

        using var scope = mockServices.GetScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        
        var colaborador = context.Roles.OfType<Colaborador>().First();
        var heladera = context.Heladeras.First();
        var puntoEstrategicoRequest = MockRequest.GetPuntoEstrategicoRequest();
        var sensorTemperaturaRequest = MockRequest.GetSensorTemperaturaRequest();
        var modeloHeladeraRequest = MockRequest.GetModeloHeladeraRequest();

        var command = new ColaborarConDonacionDeHeladera.ColaborarConDonacionDeHeladeraCommand
        {
            ColaboradorId = colaborador.Id,
            FechaContribucion = DateTime.Now,
            PuntoEstrategico = puntoEstrategicoRequest,
            Estado = heladera.Estado,
            FechaInstalacion = DateTime.Now,
            TemperaturaMaximaConfig = heladera.TemperaturaMaximaConfig,
            TemperaturaMinimaConfig = heladera.TemperaturaMinimaConfig,
            Sensores = [sensorTemperaturaRequest],
            Modelo = modeloHeladeraRequest
            
        };
        
        var result = await mediator.Send(command);
        
        switch (result)
        {
            case Microsoft.AspNetCore.Http.HttpResults.BadRequest<string> badRequest:
                Assert.Fail($"El comando devolvió BadRequest: {badRequest.Value}");
                break;
            case Microsoft.AspNetCore.Http.HttpResults.NotFound<string> notFound:
                Assert.Fail($"El comando devolvió NotFound: {notFound.Value}");
                break;
            case Microsoft.AspNetCore.Http.HttpResults.Ok okResult:
                // Accede al valor dentro del Ok
                Assert.Pass("El comando creo la donacion de la heladera.");
                break;
            default:
                Assert.Fail($"El comando no devolvió nulo - {result.GetType()}"); 
                break;
        }

    }
}