namespace AutoTrading.Application.Common.Interfaces;

public interface IUser
{
    long Id { get; }
    
    string Name { get; }
    
    long[] Roles { get; }
}