using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinCC.Views.UcControls;

namespace WinCC
{
    public class Shell
    {
      public static  ProgressView ProgressView = new ProgressView(); 

        public static void ShowProgressView()
        {
            ProgressView = new ProgressView();
            ProgressView.ShowDialog();  
        }

        public static void CloseProgressView()
        {
            ProgressView.Close();
        }
    }
}
