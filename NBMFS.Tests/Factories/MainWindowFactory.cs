using System.Windows.Shell;
using System.Windows.Controls;
using System.Collections.Generic;
using NBMFS.Models;
using System.Windows;
using System.ComponentModel;
using NBMFS;
// <copyright file="MainWindowFactory.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;

namespace NBMFS
{
    /// <summary>A factory for NBMFS.MainWindow instances</summary>
    public static partial class MainWindowFactory
    {
        /// <summary>A factory for NBMFS.MainWindow instances</summary>
        [PexFactoryMethod(typeof(MainWindow))]
        public static MainWindow Create(
            List<Message> os_list,
            Button btnLoad_button,
            Button btnRead_button1,
            TextBox txtMessageHeader_textBox,
            Image napierLogo_image,
            TextBox txtMessageBody_textBox1,
            Label lblMentions_label,
            ListBox lstMentions_listBox,
            Label lblHashtags_label1,
            ListBox lstHashtags_listBox1,
            Label lblBody_label2,
            Label lblHeader_label3,
            ListBox lstSIR_listBox2,
            ListBox lstMessages_listBox3,
            Label lblMessageslist_label4,
            Label lblTitle_label5,
            Button btnNext_button2,
            Button btnPrevious_button3,
            Label lblMessageslist_Copy_label6,
            TaskbarItemInfo value_taskbarItemInfo,
            WindowStartupLocation value_i,
            Window value_window,
            bool? value_nullb,
            Size value_size,
            Size availableSize_size1,
            Rect finalRect_rect
        )
        {
            MainWindow mainWindow = new MainWindow();
            ( (ISupportInitialize)mainWindow ).BeginInit();
            mainWindow.os = os_list;
            mainWindow.btnLoad = btnLoad_button;
            mainWindow.btnRead = btnRead_button1;
            mainWindow.txtMessageHeader = txtMessageHeader_textBox;
            mainWindow.napierLogo = napierLogo_image;
            mainWindow.txtMessageBody = txtMessageBody_textBox1;
            mainWindow.lblMentions = lblMentions_label;
            mainWindow.lstMentions = lstMentions_listBox;
            mainWindow.lblHashtags = lblHashtags_label1;
            mainWindow.lstHashtags = lstHashtags_listBox1;
            mainWindow.lblBody = lblBody_label2;
            mainWindow.lblHeader = lblHeader_label3;
            mainWindow.lstSIR = lstSIR_listBox2;
            mainWindow.lstMessages = lstMessages_listBox3;
            mainWindow.lblMessageslist = lblMessageslist_label4;
            mainWindow.lblTitle = lblTitle_label5;
            mainWindow.btnNext = btnNext_button2;
            mainWindow.btnPrevious = btnPrevious_button3;
            mainWindow.lblMessageslist_Copy = lblMessageslist_Copy_label6;
            ( (Window)mainWindow ).TaskbarItemInfo = value_taskbarItemInfo;
            ( (Window)mainWindow ).WindowStartupLocation = value_i;
            ( (Window)mainWindow ).Owner = value_window;
            ( (Window)mainWindow ).DialogResult = value_nullb;
            ( (UIElement)mainWindow ).RenderSize = value_size;
            ( (UIElement)mainWindow ).Measure(availableSize_size1);
            ( (UIElement)mainWindow ).Arrange(finalRect_rect);
            ( (Window)mainWindow ).Show();
            ( (ISupportInitialize)mainWindow ).EndInit();
            return mainWindow;

            // TODO: Edit factory method of MainWindow
            // This method should be able to configure the object in all possible ways.
            // Add as many parameters as needed,
            // and assign their values to each field by using the API.
        }
    }
}
