using AutoTrading.Application.Users.Commands.CreateUser;
using AutoTrading.Application.Users.Commands.DeleteUser;
using AutoTrading.Application.Users.Commands.UpdateUser.ChangePassword;
using AutoTrading.Application.Users.Commands.UpdateUser.ChangeUserInformation;

namespace AutoTrading.Api.Endpoints;

public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(Register)
            .MapPut(UpdateUserInformation, "{id}")
            .MapPut(UpdateUserPassword, "{id}")
            .MapDelete(DeleteUser, "{id}");
    }

    private Task<long> Register(ISender sender, CreateUserCommand command)
    {
        return sender.Send(command);
    }

    private async Task<IResult> UpdateUserInformation(ISender sender, long id, UpdateUserInformationCommand command)
    {
        if (id != command.Id)
            return Results.BadRequest();

        await sender.Send(command);
        return Results.NoContent();
    }

    private async Task<IResult> UpdateUserPassword(ISender sender, long id, UpdateUserPasswordCommand command)
    {
        if (id != command.Id)
            return Results.BadRequest();

        await sender.Send(command);
        return Results.NoContent();
    }

    private async Task<IResult> DeleteUser(ISender sender, long id)
    {
        await sender.Send(new DeleteUserCommand(id));
        return Results.NoContent();
    }
}