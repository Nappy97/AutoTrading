using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.Common.Interfaces;

public interface ICodeCategoryService
{
    Task<List<CodeCategory>> GetCodeCategories();

    Task<List<Code>> GetCodesByCodeCategoryId(long codeCategoryId);
}