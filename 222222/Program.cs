using _222222;

namespace Online1
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
            // Application.Run(new Form1());
             Application.Run(new MainAppointmentForm());
            //Application.Run(new AppointmentForm());
            // Application.Run(new ExhibitionForm());
            // Application.Run(new AddAppointmentForm());
            // Application.Run(new AddExhibitionForm());
           
          //  Application.Run(new DeleteExhibitionForm());
        }
    }
}