using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using StarSharksTool.Exceptions;
using System.Net;

namespace StarSharksTool
{
    internal static class Program
    {
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddMemoryCache().AddDistributedMemoryCache();//.AddDistributedMemoryCache<IDistributedCache, >();
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            ConfigureServices(services);


            ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            //Services.Service.RentShark("", 1);
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // Add the event handler for handling UI thread exceptions to the event.
            Application.ThreadException += new ThreadExceptionEventHandler(UIThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(DomainException);

            services.AddScoped<AccountManagement>();

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                Global.Cache = serviceProvider.GetService<IDistributedCache>();
                var form1 = serviceProvider.GetRequiredService<AccountManagement>();
                Application.Run(form1);
            }


            //Application.Run(new AccountManagement());
        }

        // Handle the UI exceptions by showing a dialog box, and asking the user whether
        // or not they wish to abort execution.
        private static void UIThreadException(object sender, ThreadExceptionEventArgs t)
        {
            ExceptionHandler(t.Exception!);
        }
        private static void DomainException(object sender, UnhandledExceptionEventArgs t)
        {
            var exception = t.ExceptionObject as Exception;
            ExceptionHandler(exception!);
        }

        private static void ExceptionHandler(Exception exception)
        {
            switch (exception)
            {
                case BusinessException _:
                    MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case ArgumentNullException _:
                case ArgumentException _:
                default:
                    MessageBox.Show($"{exception?.Message}\n{exception?.StackTrace}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    break;
            }
        }
    }
}