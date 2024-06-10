using AutoTrading.Application.Common.Models;
using AutoTrading.Application.UserRoles.Commands.CreateUserRole;
using AutoTrading.Application.UserRoles.Commands.DeleteUserRole;
using AutoTrading.Application.UserRoles.Commands.UpdateUserRole;
using AutoTrading.Application.UserRoles.Queries.GetUserRolesWithPagination;

namespace AutoTrading.Api.Endpoints;

public class UserRoles : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetUserRolesWithPagination)
            .MapPost(CreateUserRole)
            .MapPut(UpdateUserRole, "{userId}/{roleId}")
            .MapDelete(DeleteUserRole, "{userId}/{roleID}");
    }

    private Task<PaginatedList<UserRolesBriefDto>> GetUserRolesWithPagination(ISender sender,
        [AsParameters] GetUserRolesWithPaginationQuery query)
    {
        return sender.Send(query);
    }

    private Task<(long, long)> CreateUserRole(ISender sender, CreateUserRoleCommand command)
    {
        return sender.Send(command);
    }

    private async Task<IResult> UpdateUserRole(ISender sender, UpdateUserRoleCommand command, long userId, long roleId)
    {
        if (userId != command.UserId && roleId != command.RoleId)
            return Results.NotFound();

        await sender.Send(command);
        return Results.NoContent();
    }

    private async Task<IResult> DeleteUserRole(ISender sender, long userId, long roleId)
    {
        await sender.Send(new DeleteUserRoleCommand(userId, roleId));
        return Results.NoContent();
    }
}