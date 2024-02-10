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
            SetSize("height");
        }
        catch (QuitInputRead)
        {
            return;
        }
    }

    private void SetSize(string dimension)
    {
        int? value;

        while (true)
        {
            App.Output.Write($"Enter {dimension}");
            value = GetInt();
            if (value != null) break;
        }

        App.Context[dimension] = value;
        App.Output.WriteAndWait($"Arena {dimension} is set to {value}");
    }

    private int? GetInt()
    {
        string inp = App.Input.Get();

        try
        {
            return int.Parse(inp);
        }
        catch
        {
            App.Output.WriteAndWait($"Wrong int format `{inp}`");
        }

        return null;
    }
}
