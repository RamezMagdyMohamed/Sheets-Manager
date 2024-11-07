using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheetsManager.Revit
{
    public class FlagVariable
    {
        private static bool actionInvoked = false;

        public static void PerformAction()
        {
            // Perform the action
            actionInvoked = true; // Set the flag to indicate the action was invoked
        }

        public static bool WasActionInvoked()
        {
            return actionInvoked;
        }
    }
}
