using AutoTrading.Application.Common.Models;
using AutoTrading.Application.Roles.Commands.CreateRole;
using AutoTrading.Application.Roles.Commands.DeleteRole;
using AutoTrading.Application.Roles.Commands.UpdateRole;
using AutoTrading.Application.Roles.Queries.GetRolesWithPagination;

namespace AutoTrading.Api.Endpoints;

public class Roles : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetRolesPagination)
            .MapPost(CreateRole)
            .MapPut(UpdateRole, "{id}")
            .MapDelete(DeleteRole, "{id}");
    }

    private Task<PaginatedList<RoleBriefDto>> GetRolesPagination(ISender sender,
        [AsParameters] GetRolesWithPaginationQuery query)
    {
        return sender.Send(query);
    }

    private Task<long> CreateRole(ISender sender, CreateRoleCommand command)
    {
        return sender.Send(command);
    }

    private async Task<IResult> UpdateRole(ISender sender, long id, UpdateRoleCommand command)
    {
        if (id != command.Id)
            return Results.NotFound();

        await sender.Send(command);
        return Results.NoContent();
    }

    private async Task<IResult> DeleteRole(ISender sender, long id)
    {
        await sender.Send(new DeleteRoleCommand(id));
        return Results.NoContent();
    }
}