using Antifraud.Service;
using Antifraud.Service.Operations.Pix;
using Antifraud.Service.Operations.Ted;
using Bogus;
using Bogus.Extensions.Brazil;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

var container = Startup.RegisterServices();

var mediator = container.GetRequiredService<IMediator>();

Console.WriteLine("------------------ PIX ---------------- ");

await pixOperation(mediator);

var operationId = await pixWithAntifraudOperation(mediator, 8);

operationId = await pixWithAntifraudOperation(mediator, 10, operationId);

await pixWithAntifraudOperation(mediator, 10, operationId);

Console.WriteLine();
Console.WriteLine("------------------ TED ---------------- ");

await tedOperation(mediator);

operationId = await tedWithAntifraudOperation(mediator, 8);

operationId = await tedWithAntifraudOperation(mediator, 10, operationId);

await tedWithAntifraudOperation(mediator, 10, operationId);

Console.WriteLine();

static async Task pixOperation(IMediator mediator)
{
    var identification = new Faker().Person.Cpf();

    var pixCommand = new RequestPixCommand(identification, 8);

    var result = await mediator.Send(pixCommand);

    Console.Write(pixCommand.ToString());
    Console.Write(result.ToString());
}

static async Task<Guid?> pixWithAntifraudOperation(IMediator mediator, decimal amount, Guid? operationId = default)
{
    var antifraudPixCommand = operationId.HasValue ?
        AntifraudCommand<RequestPixCommand, RequestPixCommandResult>.Continue(operationId.Value) :
        AntifraudCommand<RequestPixCommand, RequestPixCommandResult>.Finish(new RequestPixCommand(new Faker().Person.Cpf(), amount));

    var antifraudResult = await mediator.Send(antifraudPixCommand);

    Console.WriteLine();
    Console.Write(antifraudPixCommand.ToString());
    Console.Write(antifraudResult.ToString());

    return antifraudResult.OperationId;
}

static async Task tedOperation(IMediator mediator)
{
    var accountNumber = new Faker().Finance.Account();

    var tedCommand = new RequestTedCommand(accountNumber, 8);

    var result = await mediator.Send(tedCommand);

    Console.Write(tedCommand.ToString());
    Console.Write(result.ToString());
}

static async Task<Guid?> tedWithAntifraudOperation(IMediator mediator, decimal amount, Guid? operationId = default)
{
    var antifraudTedCommand = operationId.HasValue ?
        AntifraudCommand<RequestTedCommand, RequestTedCommandResult>.Continue(operationId.Value) :
        AntifraudCommand<RequestTedCommand, RequestTedCommandResult>.Finish(new RequestTedCommand(new Faker().Finance.Account(), amount));

    var antifraudResult = await mediator.Send(antifraudTedCommand);

    Console.WriteLine();
    Console.Write(antifraudTedCommand.ToString());
    Console.Write(antifraudResult.ToString());

    return antifraudResult.OperationId;
}