using System.Security.Claims;
using System.Text;
using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.Users.Queries.Login;

public record LoginUserQuery : IRequest<LoginResultDto>
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
}

public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoginResultDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public LoginUserQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<LoginResultDto> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var response = new LoginResultDto();
        var user = await _context.Users.FirstOrDefaultAsync(x =>
            x.UserName.ToLower().Equals(request.UserName));

        if (user is null)
        {
            response.Success = false;
            response.Message = "없는 계정입니다";
        }
        else if(user.Password != request.Password)
        {
            response.Success = false;
            response.Message = "틀린 비밀번호 입니다";
        }
        return response;
    }
}