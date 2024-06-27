using AutoTrading.Application.Accounts.Commands.CreateAccount;
using AutoTrading.Application.Accounts.Commands.UpdateAccount;
using AutoTrading.Application.Accounts.Queries.GetAccountDetails;
using AutoTrading.Client.Common;
using AutoTrading.Shared.Extensions;

namespace AutoTrading.Client.Services.Account;

public class AccountService : IAccountService
{
    private readonly IRestClient _client;
    private const string BaseUri = "api/accounts/";

    public AccountService(IRestClient client)
    {
        _client = client;
    }

    public async Task<RestResult<AccountDetailsVm>> GetAccountDetails()
    {
        // TODO
        return await _client.GetAsync<AccountDetailsVm>("api");
    }

    public async Task<RestResult<long>> CreateAccount(CreateAccountCommand command)
    {
        return await _client.PostAsync<CreateAccountCommand, long>($"{BaseUri}{nameof(CreateAccount)}", command);
    }

    public async Task<RestResult<bool>> UpdateAccount(long id, UpdateAccountCommand command)
    {
        return await _client.PutAsync<UpdateAccountCommand, bool>($"{BaseUri}{nameof(UpdateAccount)}/{id}", command);
    }

    public async Task<RestResult<bool>> DeleteAccount(long id)
    {
        return await _client.DeleteAsync<bool>($"{BaseUri}{nameof(DeleteAccount)}/{id}");
    }
}