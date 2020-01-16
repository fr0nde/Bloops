using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class GameInstanceInfo
{
    public static float timer { get; set; }
    public static bool launchTimer { get; set; } = false;
    public static int nbTry { get; set; }
    public static int nbBounce { get; set; }

    public static void init()
    {
        timer = 0;
        launchTimer = true;
        nbTry = 1;
        nbBounce = 0;
    }
}
