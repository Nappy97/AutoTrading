namespace AutoTrading.Application.Common.Interfaces;

public interface IUser
{
    bool HasAuthenticated { get; }
    
    long Id { get; }
    
    string Name { get; }
    
    long[] Roles { get; }
}