// using AutoTrading.Shared.Models.Auth;
//
// namespace AutoTrading.Api.Endpoints;
//
// public class Users : EndpointGroupBase
// {
//     public override void Map(WebApplication app)
//     {
//         app.MapGroup(this)
//             .RequireAuthorization()
//             .MapGet(GetStocksWithPagination)
//             .MapPost(CreateStock)
//             .MapPut(UpdateStock, "{id}")
//             .MapDelete(DeleteStock, "{id}");
//     }
//
//     private Task<LoginResponse> Login(ISender sender)
//     {
//         
//     }
// }