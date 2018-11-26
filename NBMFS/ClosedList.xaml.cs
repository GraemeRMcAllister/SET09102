using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NBMFS
{
    /// <summary>
    /// Interaction logic for ClosedList.xaml
    /// </summary>
    public partial class ClosedList : Window
    {
        public ClosedList()
        {
            InitializeComponent();
            BuildWindow();
        }

        private void BuildWindow()
        {
            try
            {
                foreach (var l in ((MainWindow)Application.Current.MainWindow).lstSIR.Items)
                {
                    lstSIRListClosed.Items.Add(l);
                }
            }
            catch { lstSIRListClosed.Items.Add("No Incident Reports - "); }

            try
            {
                foreach (var l in ((MainWindow)Application.Current.MainWindow).lstMentions.Items)
                {
                    lstMentionsListClosed.Items.Add(l);
                }
            }
            catch { lstMentionsListClosed.Items.Add("No Mentions - "); }


            try
            {
                foreach (var l in ((MainWindow)Application.Current.MainWindow).lstHashtags.Items)
                {
                    lstHashtagsListClosed.Items.Add(l);
                }
            }
            catch { lstHashtagsListClosed.Items.Add("No Hashtags - "); }
        }


        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
