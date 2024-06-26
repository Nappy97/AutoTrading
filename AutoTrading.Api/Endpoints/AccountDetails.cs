using AutoTrading.Application.AccountDetails.Queries.GetAccountDetailsWithPagination;
using AutoTrading.Application.Accounts.Commands.CreateAccount;
using AutoTrading.Application.Accounts.Commands.UpdateAccount;
using AutoTrading.Application.Accounts.Queries.GetAccountDetails;
using AutoTrading.Application.Common.Models;

namespace AutoTrading.Api.Endpoints;

public class AccountDetails : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetAccountDetailsWithPagination)
            .MapPost(CreateAccountDetail)
            .MapPut(UpdateAccountDetail, "{id}");
    }

    private Task<PaginatedList<AccountDetailBriefDto>> GetAccountDetailsWithPagination(ISender sender,
        [AsParameters] GetAccountDetailsWithPaginationQuery query)
    {
        return sender.Send(query);
    }

    private Task<long> CreateAccountDetail(ISender sender, CreateAccountCommand command)
    {
        return sender.Send(command);
    }

    private async Task<IResult> UpdateAccountDetail(ISender sender, UpdateAccountCommand command, long id)
    {
        if (id != command.Id)
            return Results.BadRequest();

        await sender.Send(command);
        return Results.NoContent();
    }
}