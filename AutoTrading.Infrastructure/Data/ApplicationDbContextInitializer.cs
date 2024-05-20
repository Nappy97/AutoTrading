using AutoTrading.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AutoTrading.Infrastructure.Data;

public static class InitializerExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitializer
{
    private readonly ILogger<ApplicationDbContextInitializer> _logger;

    private readonly ApplicationDbContext _context;
    // private readonly UserManager<ApplicationUser> _userManager;
    // private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitializer(ILogger<ApplicationDbContextInitializer> logger,
        ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
        // _userManager = userManager;
        // _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedCodeCategoryAsync();
            // await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    private async Task TrySeedCodeCategoryAsync()
    {
        if (!_context.CodeCategories.Any())
        {
            _context.CodeCategories.AddRange(new List<CodeCategory>
            {
                new()
                {
                    Id = 10,
                    Text = "토큰 분류",
                    Codes = { new Code { Id = 1000, Text = "Kis Token", Memo = "한국투자증권 접속 토큰" } }
                },
                new()
                {
                    Id = 11,
                    Text = "마켓분류",
                    Codes =
                    {
                        new Code { Id = 1100, Text = "국내", Memo = "국장" },
                        new Code { Id = 1101, Text = "미장", Memo = "해외" }
                    }
                },
                new()
                {
                    Id = 12,
                    Text = "상장 시장 분류",
                    Codes =
                    {
                        new Code { Id = 1200, Text = "코스피", Memo = "국장" },
                        new Code { Id = 1201, Text = "코스닥", Memo = "국장" }
                    }
                },
                new()
                {
                    Id = 13,
                    Text = "증권사 분류",
                    Codes =
                    {
                        new Code { Id = 1300, Text = "한국투자증권", Memo = string.Empty }
                    }
                },
                new()
                {
                    Id = 14,
                    Text = "계좌 분류",
                    Codes =
                    {
                        new Code {Id = 1400, Text = "위탁계좌", Memo = "기본"},
                        new Code {Id = 1401, Text = "ISA계좌", Memo = string.Empty},
                        new Code {Id = 1402, Text = "연금저축계좌", Memo = string.Empty}
                    }
                },
                new ()
                {
                    Id = 15,
                    Text = "거래 분류",
                    Codes =
                    {
                        new Code {Id = 1500, Text = "매수", Memo = string.Empty},
                        new Code {Id = 1501, Text = "매도", Memo = string.Empty}
                    }
                }
            });


            await _context.SaveChangesAsync();
        }
    }

    // public async Task TrySeedAsync()
    // {
    //     // Default roles
    //     var administratorRole = new IdentityRole(Roles.Administrator);
    //
    //     if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
    //     {
    //         await _roleManager.CreateAsync(administratorRole);
    //     }
    //
    //     // Default users
    //     var administrator = new ApplicationUser
    //         { UserName = "administrator@localhost", Email = "administrator@localhost" };
    //
    //     if (_userManager.Users.All(u => u.UserName != administrator.UserName))
    //     {
    //         await _userManager.CreateAsync(administrator, "Administrator1!");
    //         if (!string.IsNullOrWhiteSpace(administratorRole.Name))
    //         {
    //             await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
    //         }
    //     }
    //
    //     // Default data
    //     // Seed, if necessary
    //     if (!_context.TodoLists.Any())
    //     {
    //         _context.TodoLists.Add(new TodoList
    //         {
    //             Title = "Todo List",
    //             Items =
    //             {
    //                 new TodoItem { Title = "Make a todo list 📃" },
    //                 new TodoItem { Title = "Check off the first item ✅" },
    //                 new TodoItem { Title = "Realise you've already done two things on the list! 🤯" },
    //                 new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
    //             }
    //         });
    //
    //         await _context.SaveChangesAsync();
    //     }
    // }
}