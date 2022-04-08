using Microsoft.Extensions.Configuration;
/// <summary>
/// Author: redakker
/// Vörös Ákos - redman at redman do hu
/// https://github.com/redakker
/// </summary>

namespace AmbientLight
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IConfiguration configIF = Utils.GetConfiguration();            
            Config config = configIF.Get<Config>();

            ApplicationConfiguration.Initialize();
            Application.Run(new AmbientForm(config));
        }
       
    }
}