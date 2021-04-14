using System.Globalization;
using System.Threading;
using MusicShopManager.Engine;

namespace MusicShopManager
{
    public class MusicShopManagerProgram
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            MusicShopEngine.Instance.Start();
        }
    }
}