using System;
using System.Windows.Forms;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace CadastroFuncionario.FormsApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //SimpleInjector
            Container container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            CrossCutting.SimpleInjectorDependencyRegister.Configure(container);
            container.Verify();

            Application.Run(container.GetInstance<Form1>());
        }
    }
}
