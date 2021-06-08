using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTracking.Services.Helpers
{
    public static class AttemptsChecker
    {
        public static int AttemptsCounter { get; set; } = 1;
        public static void HowManyAttempts()
        {
            switch (AttemptsCounter)
            {
                case 1:
                    MessageHelper.Color("\nThis is your first invalid attempt to log in. You now have two left.", ConsoleColor.Red);
                    AttemptsCounter++;
                    MessageHelper.PressAnyKey();
                    break;

                case 2:
                    MessageHelper.Color("\nThis is your second invalid attempt to log in. Be careful, you only have one attempt left.", ConsoleColor.Red);
                    AttemptsCounter++;
                    MessageHelper.PressAnyKey();
                    break;

                case 3:
                    MessageHelper.Color("\nThis was your third incorrect attempt. The application will now close.", ConsoleColor.Red);
                    MessageHelper.PressAnyKey();
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }
    }
}
