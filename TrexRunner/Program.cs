using System;

namespace SimpleEcosystem
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new EcosystemSimulationGame())
                game.Run();
        }
    }
}
