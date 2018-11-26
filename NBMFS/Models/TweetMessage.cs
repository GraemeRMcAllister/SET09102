using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NBMFS.Models
{
    class TweetMessage : TextSpeakMessage
    {

        public List<Mentions> Mentions { get; private set; }
        public List<Hashtags> Hashtags { get; private set; }

        [JsonConstructor]
        public TweetMessage(string id, string sender, List<Mentions> mentions, List<Hashtags> hashtags, string body)
    : base(id, sender, body, 140, MessageType.TWEET)
        {
            Mentions = mentions;
            Hashtags = hashtags;
        }


        public TweetMessage(string id, string sender, string body)
            : base(id, sender, body, 140, MessageType.TWEET)
        {
            Mentions = new List<Mentions>();
            Hashtags = new List<Hashtags>();
            ParseTweet();
        }
        public void ParseTweet()
        {
            string[] words = Body.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {

                if (words[i].StartsWith("@"))
                {
                    bool found = false;
                    foreach (Mentions m in this.Mentions)
                        if (words[i] == m.Handle)
                        {
                            found = true;
                            m.Counter++;
                        }
                    if (!found)
                    {
                        Mentions mention = new Mentions(words[i]);
                        Mentions.Add(mention);
                    }
                }

                else if (words[i].StartsWith("#"))
                {
                    bool found = false;
                    foreach (Hashtags h in this.Hashtags)
                        if (words[i] == h.Hashtag)
                        {
                            found = true;
                            h.Counter++;
                        }
                    if (!found)
                    {
                        Hashtags hashtag = new Hashtags(words[i]);
                        Hashtags.Add(hashtag);
                    }

                }

            }
        }

        public override bool IsValidSender()
        {
            if (Sender.StartsWith("@") && Sender.Length <= 16)
                return true;

            return false;
        }

        public List<Hashtags> HashTagCount(List<Hashtags> MasterHashtags)
        {

            foreach (Hashtags h1 in this.Hashtags)
            {
                bool found = false;
                foreach (Hashtags h2 in MasterHashtags)
                {
                    if (h1.Hashtag == h2.Hashtag)
                    {
                        h2.Counter = h1.Counter + h2.Counter;
                        found = true;
                    }
                }
                if (!found)
                    MasterHashtags.Add(h1);
            }

            return MasterHashtags;
        }

        public List<Mentions> MentionsCount(List<Mentions> MasterMentions)
        {

            foreach (Mentions m1 in this.Mentions)
            {
                bool found = false;
                foreach (Mentions m2 in MasterMentions)
                {
                    if (m1.Handle == m2.Handle)
                    {
                        m2.Counter = m1.Counter + m2.Counter;
                        found = true;
                    }
                }
                if (!found)
                    MasterMentions.Add(m1);
            }

            return MasterMentions;
        }

        public override string ToString()
        {
            string result = $"ID: {ID}\nSender: {Sender}\nBody: {ConvertTextspeak()}\nType: {Type}\n";
            if (Mentions.Count != 0)
            {
                result += "\n@Mentions:\n";
                foreach (Mentions m in Mentions)
                {
                    result += $"{m.Handle} {m.Counter} \n";
                }
            }

            if (Hashtags.Count != 0)
            {
                result += "\n#hastags:\n";
                foreach (Hashtags h in Hashtags)
                {
                    result += $"{h.Hashtag} {h.Counter} \n";

                }
            }
            return result;
        }

        public override string ToFormBody()
        {
            return $"{Sender} {ConvertTextspeak()}";
        }       

    }
}
