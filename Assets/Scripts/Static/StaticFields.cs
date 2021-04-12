public class StaticFields
{
    public static string VelocityX { get; } = "velocityX";
    public static string Jump { get; } = "jump";
    public static string Slide { get; } = "slide";
    public static string Mouse { get; } = "Mouse";
    public static string ToolBar { get; } = "ToolBar";
    public static string Ready { get; } = "Ready";
    public static string Left { get; } = "Left";
    public static string Right { get; } = "Right";
    public static string GameOver { get; } = "GameOver";
    public static bool[] LevelDone { get; set; } = new bool[3];
}
