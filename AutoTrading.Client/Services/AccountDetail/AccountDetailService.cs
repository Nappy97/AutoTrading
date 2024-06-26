using AutoTrading.Application.AccountDetails.Queries.GetAccountDetailsWithPagination;
using AutoTrading.Application.Accounts.Commands.CreateAccount;
using AutoTrading.Application.Accounts.Commands.UpdateAccount;
using AutoTrading.Application.Common.Models;
using AutoTrading.Client.Common;
using AutoTrading.Shared.Extensions;

namespace AutoTrading.Client.Services.AccountDetail;

public class AccountDetailService : IAccountDetailService
{
    private readonly IRestClient _client;
    private const string BaseUri = "api/accountdetails/";

    public AccountDetailService(IRestClient client)
    {
        _client = client;
    }
    
    public async Task<RestResult<PaginatedList<AccountDetailBriefDto>>> GetAccountDetailsWithPagination(GetAccountDetailsWithPaginationQuery command)
    {
        return await _client.GetAsync<GetAccountDetailsWithPaginationQuery, PaginatedList<AccountDetailBriefDto>>(
            $"{BaseUri}{nameof(GetAccountDetailsWithPagination)}", command);
    }

    public async Task<RestResult<long>> CreateAccountDetail(CreateAccountCommand command)
    {
        return await _client.PostAsync<CreateAccountCommand, long>($"{BaseUri}{nameof(CreateAccountDetail)}", command);
    }

    public async Task<RestResult<bool>> UpdateAccountDetail(long id, UpdateAccountCommand command)
    {
        var queryParameter = id.ToQueryParameters(nameof(id));
        return await _client.PutAsync<UpdateAccountCommand, bool>($"{BaseUri}{nameof(UpdateAccountDetail)}", command,
            queryParameter);
    }
}