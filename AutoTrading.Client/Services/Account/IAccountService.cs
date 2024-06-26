using AutoTrading.Application.Accounts.Commands.CreateAccount;
using AutoTrading.Application.Accounts.Commands.UpdateAccount;
using AutoTrading.Application.Accounts.Queries.GetAccountDetails;
using AutoTrading.Client.Common;
using AutoTrading.Shared.Models.Auth;
using MediatR;

namespace AutoTrading.Client.Services.Account;

public interface IAccountService
{
    Task<RestResult<AccountDetailsVm>> GetAccountDetails();
    
    Task<RestResult<long>> CreateAccount(CreateAccountCommand command);

    Task<RestResult<bool>> UpdateAccount(long id, UpdateAccountCommand command);

    Task<RestResult<bool>> DeleteAccount(long id);
}