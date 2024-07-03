using System.Reflection;
using System.Runtime.CompilerServices;
using AutoMapper;
using AutoTrading.Application.AccountDetails.Queries.GetAccountDetailsWithPagination;
using AutoTrading.Application.Accounts.Queries.GetAccountDetails;
using AutoTrading.Application.ActionRoles.Queries.GetActionRolesWithPagination;
using AutoTrading.Application.Actions.Queries.GetActions;
using AutoTrading.Application.CodeCategories.Queries.GetCodes;
using AutoTrading.Application.Codes.Queries.GetCodesWithPagination;
using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Application.Promotions.Queries.GetMainPromotion;
using AutoTrading.Application.Roles.Queries.GetRolesWithPagination;
using AutoTrading.Application.Roles.Queries.GetUserRoles;
using AutoTrading.Application.Stocks.Queries.GetStocksWithPagination;
using AutoTrading.Application.UserRoles.Queries.GetUserRolesWithPagination;
using AutoTrading.Domain.Entities;
using Action = AutoTrading.Domain.Entities.Action;

namespace Application.UnitTests.Common.Mappings;

public class MappingTests
{
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;

    public MappingTests()
    {
        _configuration = new MapperConfiguration(config =>
            config.AddMaps(Assembly.GetAssembly(typeof(IApplicationDbContext))));

        _mapper = _configuration.CreateMapper();
    }

    [Test]
    public void ShouldHaveValidConfiguration()
    {
        _configuration.AssertConfigurationIsValid();
    }
    
    [Test]
    [TestCase(typeof(AccountDetail), typeof(AccountDetailBriefDto))]
    [TestCase(typeof(AccountDetail), typeof(AccountDetailDto))]
    [TestCase(typeof(Account), typeof(AccountDto))]
    [TestCase(typeof(CodeCategory), typeof(CodeCategoryDto))]
    [TestCase(typeof(Code), typeof(CodeDto))]
    [TestCase(typeof(Code), typeof(CodeBriefDto))]
    [TestCase(typeof(Role), typeof(RoleBriefDto))]
    [TestCase(typeof(Role), typeof(RoleBriefDto))]
    [TestCase(typeof(Role), typeof(RoleDto))]
    [TestCase(typeof(Stock), typeof(StockBriefDto))]
    [TestCase(typeof(UserRole), typeof(UserRoleDto))]
    [TestCase(typeof(UserRole), typeof(UserRolesBriefDto))]
    [TestCase(typeof(ActionRole), typeof(ActionRoleDto))]
    [TestCase(typeof(ActionRole), typeof(ActionRolesBriefDto))]
    [TestCase(typeof(Action), typeof(ActionDto))]
    [TestCase(typeof(Promotion), typeof(PromotionBriefDto))]
    public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
    {
        var instance = GetInstanceOf(source);
    
        _mapper.Map(instance, source, destination);
    }

    private object GetInstanceOf(Type type)
    {
        if (type.GetConstructor(Type.EmptyTypes) != null)
            return Activator.CreateInstance(type)!;

        // Type without parameterless constructor
        return RuntimeHelpers.GetUninitializedObject(type);
    }
}