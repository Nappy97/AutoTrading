using AutoTrading.Domain.Exceptions;
using AutoTrading.Domain.Generated;
using FluentAssertions;
using NUnit.Framework;

namespace Domain.UnitTests.ConstantTest;

public class ConstantTests
{
    int KisToken_1000 = C._10_KisToken;
    int 국내_1100 = C._11_국내;
    int 미장_1101 = C._11_미장;

    int 코스피_1200 = C._12_코스피;
    int 코스닥_1201 = C._12_코스닥;

    int 한국투자증권_1300 = C._13_한국투자증권;

    int 위탁계좌_1400 = C._14_위탁계좌;
    int ISA계좌_1401 = C._14_ISA계좌;
    int 연금저축계좌_1402 = C._14_연금저축계좌;

    int 매수_1500 = C._15_매수;
    int 매도_1501 = C._15_매도;

    [Test]
    public void 코드_리턴()
    {
        KisToken_1000.Should().Be(1000);

        국내_1100.Should().Be(1100);
        미장_1101.Should().Be(1101);

        코스피_1200.Should().Be(1200);
        코스닥_1201.Should().Be(1201);

        한국투자증권_1300.Should().Be(1300);

        위탁계좌_1400.Should().Be(1400);
        ISA계좌_1401.Should().Be(1401);
        연금저축계좌_1402.Should().Be(1402);

        매수_1500.Should().Be(1500);
        매도_1501.Should().Be(1501);
    }

    [Test]
    public void C와CodeCategory비교()
    {
        (KisToken_1000 / 100).Should().Be(CodeCategory.토큰분류_10);
        
        (국내_1100 / 100).Should().Be(CodeCategory.마켓분류_11);
        (미장_1101 / 100).Should().Be(CodeCategory.마켓분류_11);
        
        (코스피_1200 / 100).Should().Be(CodeCategory.상장시장분류_12);
        (코스닥_1201 / 100).Should().Be(CodeCategory.상장시장분류_12);
        
        (한국투자증권_1300 / 100).Should().Be(CodeCategory.증권사분류_13);
        
        (위탁계좌_1400 / 100).Should().Be(CodeCategory.계좌분류_14);
        (ISA계좌_1401 / 100).Should().Be(CodeCategory.계좌분류_14);
        (연금저축계좌_1402 / 100).Should().Be(CodeCategory.계좌분류_14);
        
        (매수_1500 / 100).Should().Be(CodeCategory.거래분류_15);
        (매도_1501 / 100).Should().Be(CodeCategory.거래분류_15);
    }
}