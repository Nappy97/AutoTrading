using AutoTrading.Application.AccountDetails.Queries.GetAccountDetailsWithPagination;
using AutoTrading.Application.Accounts.Commands.CreateAccount;
using AutoTrading.Application.Accounts.Commands.UpdateAccount;
using AutoTrading.Application.Common.Models;
using AutoTrading.Client.Common;

namespace AutoTrading.Client.Services.AccountDetail;

public interface IAccountDetailService
{
    Task<RestResult<PaginatedList<AccountDetailBriefDto>>> GetAccountDetailsWithPagination(
        GetAccountDetailsWithPaginationQuery command);

    Task<RestResult<long>> CreateAccountDetail(CreateAccountCommand command);

    Task<RestResult<bool>> UpdateAccountDetail(long id, UpdateAccountCommand command);
}