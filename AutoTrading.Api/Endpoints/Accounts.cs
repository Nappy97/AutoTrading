using AutoTrading.Application.Accounts.Commands.CreateAccount;
using AutoTrading.Application.Accounts.Commands.DeleteAccount;
using AutoTrading.Application.Accounts.Commands.UpdateAccount;
using AutoTrading.Application.Accounts.Queries.GetAccountDetails;

namespace AutoTrading.Api.Endpoints;

public class Accounts : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetAccountDetails)
            .MapPost(CreateAccount)
            .MapPut(UpdateAccount, "{id}")
            .MapDelete(DeleteAccount, "{id}");
    }

    private Task<AccountDetailsVm> GetAccountDetails(ISender sender)
    {
        return sender.Send(new GetAccountDetailsQuery());
    }

    private Task<long> CreateAccount(ISender sender, CreateAccountCommand command)
    {
        return sender.Send(command);
    }

    private async Task<IResult> UpdateAccount(ISender sender, long id, UpdateAccountCommand command)
    {
        if (id != command.Id)
            return Results.BadRequest();

        await sender.Send(command);
        return Results.NoContent();
    }

    private async Task<IResult> DeleteAccount(ISender sender, long id)
    {
        await sender.Send(new DeleteAccountCommand(id));
        return Results.NoContent();
    }
}