namespace Dynamic_UI_gen_demo
{
    internal static class Program // class program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread] // tell Computer that this is  single Thread application apartment .
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();  // launch a method from ApplicationConfiguration Class name " Initialize "
            Application.Run(new Dynamic_UI_gen()); //function run a Form1 script
        }
    }
}