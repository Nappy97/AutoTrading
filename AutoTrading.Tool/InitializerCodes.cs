using System.Reflection;
using AutoTrading.Domain.Entities;
using AutoTrading.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AutoTrading.Tool;

public class InitializerCodes : ITool
{
    private ApplicationDbContext _context;

    public void Run()
    {
        _context = Program.AddDbContext();

        DeleteTables();

        var codeCategoryEntities = new List<CodeCategory>
        {
            new() { CodeCategoryId = 10, Text = "토큰 분류" },
            new() { CodeCategoryId = 11, Text = "마켓분류" },
            new() { CodeCategoryId = 12, Text = "상장 시장 분류" },
            new() { CodeCategoryId = 13, Text = "증권사 분류" },
            new() { CodeCategoryId = 14, Text = "계좌 분류" },
            new() { CodeCategoryId = 15, Text = "거래 분류" }
        };
        _context.CodeCategories.AddRange(codeCategoryEntities);


        var codeEntities = new List<Code>
        {
            new() { CodeId = 1000, CodeCategoryId = 10, Text = "KisToken" },
            new() { CodeId = 1100, CodeCategoryId = 11, Text = "국내" },
            new() { CodeId = 1101, CodeCategoryId = 11, Text = "미장" },
            new() { CodeId = 1200, CodeCategoryId = 12, Text = "코스피" },
            new() { CodeId = 1201, CodeCategoryId = 12, Text = "코스닥" },
            new() { CodeId = 1300, CodeCategoryId = 13, Text = "한국투자증권" },
            new() { CodeId = 1400, CodeCategoryId = 14, Text = "위탁계좌" },
            new() { CodeId = 1401, CodeCategoryId = 14, Text = "ISA계좌" },
            new() { CodeId = 1402, CodeCategoryId = 14, Text = "연금저축계좌" },
            new() { CodeId = 1500, CodeCategoryId = 15, Text = "매수" },
            new() { CodeId = 1501, CodeCategoryId = 15, Text = "매도" }
        };

        codeEntities.ForEach(x => x.Enabled = true);
        _context.Codes.AddRange(codeEntities);
        
        _context.SaveChanges();
    }

    public string Description() => $"{nameof(Code)} & {nameof(CodeCategory)} initialize";

    private void DeleteTables()
    {
        _context.CodeCategories.ExecuteDelete();
        _context.Codes.ExecuteDelete();
    }
}