using System;
using System.Collections.Generic;
using System.Text;

namespace VGP133_Final_Assignment.Core
{
    public static class ResolutionManager
    {
        public static void SetResolution()
        {
            
        }

        private static int s_virtualWidth = 384;
        private static int s_virtualHeight = 216;

        private static int s_uiScale = 5;
        public static int UIScale { get => s_uiScale; set => s_uiScale = value; }
    }
}
