using CommandApp.Feature;
using CommandApp.Exceptions;

namespace SnakeApp;

public class SetArenaSizeFeature : BaseFeature
{
    public override void Run()
    {
        try
        {
            SetSize("width");
        }
        catch (QuitInputRead)
        {
            return;
        }

        try
        {
            SetSize("height");
        }
        catch (QuitInputRead)
        {
            return;
        }
    }

    private void SetSize(string dimension)
    {
        App.Output.Write($"Enter {dimension}");
        int value = GetInt();

        App.Context[dimension] = value;
        App.Output.WriteAndWait($"Arena {dimension} is set to {value}");
    }

    private int GetInt()
    {
        string inp = App.Input.Get();

        try
        {
            return int.Parse(inp);
        }
        catch
        {
            throw new BaseException($"Wrong int format `{inp}`");
        }
    }
}
