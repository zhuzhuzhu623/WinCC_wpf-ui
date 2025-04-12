using Prism.Unity;
using Prism.Ioc;
using System.Windows;
using Prism.Mvvm;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Runtime;
using System.Windows.Media.Media3D;
using Translate.Views;

namespace Translate
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    { 
        //设置启动起始页
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
  

}
