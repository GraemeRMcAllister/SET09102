using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using NBMFS.Models;

namespace NBMFS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Hashtags> MasterHashtags = new List<Hashtags>();
        private List<Mentions> MasterMentions = new List<Mentions>();
        public List<Message> os = new List<Message>();
        private int index = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            ProcessMessage();
        }

        void txtMessageBodyEnterClicked(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ProcessMessage();
                e.Handled = true;
            }
        }


        private void btnPaste_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ReadPaste();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadJSON();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void BtnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (os.Count == 0)
                return;

            if (index == 0)
                index = 0;
            else index--;

            var obj = os[index] as Message;
            txtMessageHeader.Text = obj.ToFormHeader();
            txtMessageBody.Text = obj.ToFormBody();
            
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            if(os.Count == 0)
                return;

            if (index >= os.Count - 1)
                index = os.Count - 1;
            else if (os.Count <= 0 || index < 0)
                index = 0;
            else
                index++;

            Message obj = os[index] as Message;
            txtMessageHeader.Text = obj.ToFormHeader();
            txtMessageBody.Text = obj.ToFormBody();            
        }

        void lstMessages_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            foreach (Message m in os)
            {
                if (m.ToFormHeader() == lstMessages.Items[lstMessages.SelectedIndex].ToString())
                {
                    txtMessageHeader.Text = m.ToFormHeader();
                    txtMessageBody.Text = m.ToFormBody();
                }
            } 
        }

        void lstSIR_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            foreach (Message se in os)
            {
                if(se is SIREmail)
                if (se.ToFormHeader() == lstSIR.Items[lstSIR.SelectedIndex].ToString().Split(' ')[0])
                {
                    txtMessageHeader.Text = se.ToFormHeader();
                    txtMessageBody.Text = se.ToFormBody();
                }
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            ClosedList closed = new ClosedList();
            closed.Show();
            this.Hide();
        }

    }
}
