using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using Microsoft.Win32;
using NBMFS.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace NBMFS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void ProcessMessage()
        {
            try
            {
                MessageValidation.ValidateHeader(txtMessageHeader.Text);
                Message m = ParseMessage();

                if (m is null)
                    throw new Exception("No Message");

                m.ToJson();
                os.Add(m);
                UpdateGlobalMessageList();

                if (m is SIREmail)
                    UpdateSIRList();

                if (m is TweetMessage)
                {
                    TweetMessage tm = m as TweetMessage;
                    MasterHashtags = tm.HashTagCount(MasterHashtags);
                    MasterMentions = tm.MentionsCount(MasterMentions);
                    Refresh();
                }

                MessageBox.Show("Message Added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message Not Added");
                return;
            }
        }

        private Message ParseMessage()
        {
            string txtSender = "";
            string txtBody = "";
            string messtype = txtMessageHeader.Text.Substring(0, 1);
            string id = txtMessageHeader.Text.Substring(1, 9);

            foreach (Message m in os)
                if (id == m.ID)
                    throw new Exception("Duplicate ID");

            try
            {
                index = txtMessageBody.Text.IndexOf(' ');
                txtSender = txtMessageBody.Text.Substring(0, index);
                txtBody = txtMessageBody.Text.Substring(index + 1, txtMessageBody.Text.Length - index - 1);
            }
            catch
            {
                throw new Exception("Missing Body Elements\nRequired:[Sender] [Body]");
            }

            if (messtype.Equals("S"))
            {
                return new SmsMessage(id, txtSender, txtBody); //returns SMS MEssage
            }

            else if (messtype.Equals("T"))
            {
                return new TweetMessage(id, txtSender, txtBody); //returns Tweet MEssage
            }

            else if (messtype.Equals("E"))
            {
                return ProcessEmail(id, txtSender, txtBody); //returns Email(or SIR) MEssage
            }
            return null;
        }

        private EmailMessage ProcessEmail(string id, string txtSender, string txtBody)
        {
            try
            {

                if (txtBody.StartsWith("SIR"))
                    try
                    {
                        return new SIREmail(id, txtSender, txtBody);
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                return new EmailMessage(id, txtSender,txtBody);
            }
            catch
            { 
                MessageBox.Show("Invalid Subject: Use . to indicate end of subject");
                return null;
            }

        }

        private void ReadPaste()
        {
            string clipboardText = Clipboard.GetText(TextDataFormat.Text);
            string clipboardTextheader = clipboardText.Substring(0, 10);
            clipboardText = clipboardText.Remove(0, 10);
            string clipboardTextBody = clipboardText.Substring(1, clipboardText.Length - 1);

            txtMessageHeader.Text = clipboardTextheader;
            txtMessageBody.Text = clipboardTextBody;
        }

        private void LoadJSON()
        {
            string loaded = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog();
            Nullable<bool> result = ofd.ShowDialog();

            if (ofd.FileName.EndsWith("JSON"))
            {
                int Count = 0;
                int x = 0;

                using (StreamReader file = new StreamReader(ofd.FileName))
                {
                    while (file.ReadLine() != null)
                    {
                        Count++;
                    }
                }

                using (StreamReader file = new StreamReader(ofd.FileName))
                {
                    while (x != Count)
                    {
                        x++;
                        loaded = file.ReadLine();
                        try
                        {
                            ConvertJSONMessage(loaded);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }

                    UpdateGlobalMessageList();
                }
            }
        }

        private void UpdateSIRList()
        {
            lstSIR.Items.Clear();

            foreach (Message m in os)
                if (m is SIREmail)
                {
                    SIREmail s = m as SIREmail;
                    lstSIR.Items.Add($"{s.ID} {s.Subject}: {s.SortCode} - {s.NOI}");
                }

        }


        private void UpdateGlobalMessageList()
        {
            lstMessages.Items.Clear();
            foreach (Message o in os)
            {
                txtMessageHeader.Text = o.ToFormHeader();
                txtMessageBody.Text = o.ToFormBody();
                lstMessages.Items.Add(o.ToFormHeader());
            }
            index = os.Count - 1;
        }


        private void ConvertJSONMessage(string loaded)
        {
            dynamic m = null;
            string strtype = loaded.Substring(loaded.LastIndexOf('}') - 1, 1);
            int type = Convert.ToInt32(strtype);

            if (type == 0)
            {
                m = JsonConvert.DeserializeObject<SmsMessage>(loaded);                
            }
            if (type == 1)
            {
                m = JsonConvert.DeserializeObject<TweetMessage>(loaded);
            }
            if (type == 2)
            {
                m = JsonConvert.DeserializeObject<EmailMessage>(loaded);
            }
            if (type == 3)
            {
                m = JsonConvert.DeserializeObject<SIREmail>(loaded);
            }

            if (!MessageAlreadyExists(m.ID))
                os.Add(m);

            if (m is TweetMessage)
            {
                MasterHashtags = m.HashTagCount(MasterHashtags);
                MasterMentions = m.MentionsCount(MasterMentions);
                Refresh();
            }
            if(m is SIREmail)
                UpdateSIRList();

            //MessageBox.Show(m.ToString());


        }      

        private bool MessageAlreadyExists(string id)
        {
            foreach (Message m2 in os)
            {
                if (id == m2.ID)
                {
                    return true;
                }
            }
            return false;
        }

        private void Refresh()
        {

            lstHashtags.Items.Clear();
            var OrderHashtags = MasterHashtags.OrderByDescending(i => i.Counter);
            foreach (Hashtags h in OrderHashtags)
            {
                if (h.Counter > 1)
                    lstHashtags.Items.Add($"{h.Counter}\t{h.Hashtag}");
                else
                    lstHashtags.Items.Add(h.Hashtag);
            }

            lstMentions.Items.Clear();
            var OrderMentions = MasterMentions.OrderByDescending(i => i.Counter);
            foreach (Mentions m in OrderMentions)
            {
                if (m.Counter > 1)
                    lstMentions.Items.Add($"{m.Handle}");
                else
                    lstMentions.Items.Add(m.Handle);
            }
        }
    }
}