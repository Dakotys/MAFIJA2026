using UnityEngine;

public static class GlobalVars
{
    // Player Stats
    public static int Health = 100;
    public static int MaxHealth = 100;
    public static int Stamina = 100;
    public static int MaxStamina = 100;
    public static int Intellect = 50;
    public static int MaxIntellect = 100;
    public static int Money = 50;

    // Time tracking
    public static float GameTimeHours = 6f; // Start at 6:00 AM
    public static bool HasSlept = false;

    // Player position (for scene transitions)
    public static Vector3 LastPlayerPosition = Vector3.zero;
    public static string LastSceneName = "";

    // Optional: Reset method for new game
    public static void ResetToDefaults()
    {
        Health = 100;
        MaxHealth = 100;
        Stamina = 100;
        MaxStamina = 100;
        Intellect = 50;
        MaxIntellect = 100;
        Money = 50;
        GameTimeHours = 6f;
        HasSlept = false;
        LastPlayerPosition = Vector3.zero;
        LastSceneName = "";
    }
}
