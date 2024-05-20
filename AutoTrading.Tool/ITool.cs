namespace AutoTrading.Tool;

public interface ITool
{
    void Run();

    string Description() => "여기에 설명 입력";
}