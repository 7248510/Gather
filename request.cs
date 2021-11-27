using System;

namespace Gather
{
    internal static class Request
    {
        private static void Prompt()
        {
            PromptUser setup = new PromptUser(); //Spawn an instance
            Console.WriteLine(setup.Welcome);
            Console.WriteLine(setup.Welcome2);
        }

        private static void Main()
        {
            Prompt();
            Gather.CreateDirectory(); //Create the root directory
            var trackingVal = Gather.Url();
            Console.WriteLine(trackingVal == 0 ? "Program successfully executed." : "Program failed.");
        }
    }
}
