using UnityEngine;

namespace Bloops.Game.Assets.Scripts.Services
{
    public static class ApplicationService
    {
        public static bool Internet
        {
            get
            {
                return Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork ||
                    Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork;
            }
        }

        public static string DataPath
        {
            get
            {
                return Application.persistentDataPath;
            }
        }

        public static string CachePath
        {
            get
            {
                return Application.temporaryCachePath;
            }
        }
    }
}