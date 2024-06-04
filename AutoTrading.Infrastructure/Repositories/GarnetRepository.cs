using Garnet.client;
using Garnet.networking;

namespace AutoTrading.Infrastructure.Repositories;

// TODO 아직 가넷 자료가 적음
public class GarnetRepository
{
    private readonly IServerHook _garnetClient;

    public GarnetRepository(GarnetClient garnetClient)
    {
        _garnetClient = garnetClient;
    }
    
    
}