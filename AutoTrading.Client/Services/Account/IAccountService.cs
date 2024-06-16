using AutoTrading.Application.Accounts.Commands.CreateAccount;
using AutoTrading.Application.Accounts.Queries.GetAccountDetails;
using AutoTrading.Client.Common;

namespace AutoTrading.Client.Services.Account;

public interface IAccountService
{
    Task<RestResult<long>> CreateAccount(CreateAccountCommand request);

    Task<RestResult<IResult>>
    Task<RestResult<AccountDetailsVm>> GetAccountDetails(GetAccountDetailsQuery query);
}