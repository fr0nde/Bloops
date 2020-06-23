using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class GameInstanceInfo
{
    public static float timer { get; set; }
    public static bool launchTimer { get; set; } = true;
    public static int nbTry { get; set; }
    public static int nbBounce { get; set; }
    public static Vector2 positionDepart { get; set; }

    public static void init()
    {
        launchTimer = true;
        timer = 0;
        nbTry = 1;
        nbBounce = 0;
        positionDepart = Vector2.zero;
    }
}
