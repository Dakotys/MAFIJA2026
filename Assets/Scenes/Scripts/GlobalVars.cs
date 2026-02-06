using UnityEngine;

public static class GlobalVars
{
    // Player Stats
    public static int Health = 15;
    public static int MaxHealth = 30;
    public static int Stamina = 15;
    public static int MaxStamina = 30;
    public static int Intellect = 5;
    public static int MaxIntellect = 30;
    public static int Money = 50;

    // Time tracking
    public static float GameTimeHours = 7f; // Start at 6:00 AM
    public static bool HasSlept = false;

    // Player position (for scene transitions)
    public static Vector2 LastPlayerPosition = Vector2.zero;
    public static string LastSceneName = "";

    // Optional: Reset method for new game
    public static void ResetToDefaults()
    {
        Health = 15;
        MaxHealth = 30;
        Stamina = 15;
        MaxStamina = 30;
        Intellect = 5;
        MaxIntellect = 30;
        Money = 50;
        GameTimeHours = 7f;
        HasSlept = false;
        LastPlayerPosition = new Vector2(41.5f, -9f);
        LastSceneName = "";
    }
}
