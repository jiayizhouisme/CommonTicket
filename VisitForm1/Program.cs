namespace VisitForm1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
          
            Application.Run(new LogonForm());
          //  Application.Run(new MyOrderForm());
            // Application.Run(new ExhibitionForm1());
            //Application.Run(new RegisterForm());
            // Application.Run(new AddUserInfoForm());
            //  Application.Run(new Reserve());
            //Application.Run(new UpdatePwdForm());
        }
    }
}