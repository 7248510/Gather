using System;


namespace carbonClient
{
    class request
    {
        static void prompt()
        {
            promptUser setup = new promptUser(); //Spawn an instance
            Console.WriteLine(setup.welcome);
            Console.WriteLine(setup.welcome2);
        }

        static void Main()
        {
            prompt();
            gather.createDirectory(); //Create the root directory
            int trackingVal = gather.url();
            if (trackingVal == 0)
            { 
                Console.WriteLine("Program succesfully executed.");
            }
            else { 
                Console.WriteLine("Program failed.");
            }
        }
    }
}
