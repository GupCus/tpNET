using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Repository;

namespace Escritorio
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormPrincipal());

        }
    }
}