using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace AmbientLight
{
    public class Utils
    {
        

        public static Bitmap GetSreenshot()
        {
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            try
            {
                Graphics g = Graphics.FromImage(bmp);
                g.CopyFromScreen(0, 0, 0, 0, bmp.Size);

                // bmp.Save("screenshot.bmp");
            } catch
            {
                Debug.WriteLine("Cannot take a screenshot. Log off screen?");
            }

            return bmp;
        }


        public static IConfiguration GetConfiguration()
        {
            createConfigFile();

            if (string.IsNullOrEmpty(Constants.configPath))
            {
                Debug.WriteLine("The following file was used for confuration: " + Constants.configPath);
            }

            IConfigurationRoot builtConfig = null;

            try
            {
                // Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                builtConfig = new ConfigurationBuilder()
                    .SetBasePath(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData))
                    .AddJsonFile(Constants.configPath, optional: true)
                    .AddEnvironmentVariables()
                    .Build();
            }
            catch
            {
                string json = JsonSerializer.Serialize(new AmbientLight.Config());
                builtConfig = new ConfigurationBuilder().AddJsonStream(new MemoryStream(Encoding.ASCII.GetBytes(json))).Build();
                Debug.WriteLine("The config file is corrupt, use the default");
                createDefaultConfigFile();
            }

            return builtConfig;
        }


        /// <summary>
        /// Create a configFile if necessarry
        /// </summary>
        private static void createConfigFile()
        {
            if (!File.Exists(Constants.configPath))
            {
                createDefaultConfigFile();
            }

            Debug.WriteLine(Constants.configPath);
        }

        private static void createDefaultConfigFile()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(Constants.configPath));
            FileStream configFile = File.Create(Constants.configPath);
            configFile.Close();

            // Create the default config
            ConfigToJson(new AmbientLight.Config());
        }

        public static void ConfigToJson(Config config)
        {
            string json = JsonSerializer.Serialize(config);
            File.WriteAllText(Constants.configPath, json);
        }

        public static string replaceWildCards(string text, Color color)
        {
            text = text.Replace(WildCards.R, color.R.ToString());
            text = text.Replace(WildCards.G, color.G.ToString());
            text = text.Replace(WildCards.B, color.B.ToString());

            text = text.Replace(WildCards.HEX, ColorTranslator.ToHtml(color));

            return text;
        }
    }
}
