using ReznikovBusinessLogic;
using ReznikovDatabase;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace ReznikovView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IStudentStorage, StudentStorage>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEducationFormStorage, EducationFormStorage>(new
           HierarchicalLifetimeManager());

            currentContainer.RegisterType<StudentLogic>(new
           HierarchicalLifetimeManager()); 
            currentContainer.RegisterType<EducationFormLogic>(new
            HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
