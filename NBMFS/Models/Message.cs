using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NBMFS.Models
{
    public enum MessageType
    {
        SMS,
        TWEET,
        EMAIL,
        SIR
    }

    public abstract class Message
    {
        public string ID { get; set; }
        public string Body { get; set; }
        public string Sender { get; set; }
        [JsonProperty]
        protected MessageType Type { get; set; }
        protected int MaxSize { get; set; }

        protected Message(string id, string sender, string body, int maxSize, MessageType type)
        {
            ID = id;
            Sender = sender;
            if(!IsValidSender())
                throw new Exception($"Invalid Sender: {Sender}\nMust be at start of body and be compatible with message type.");
            Body = body;
            MaxSize = maxSize;
            if(Body.Length > MaxSize)
                throw new Exception($"Body too big\nMax Size: {MaxSize}\n\n");
            Type = type;
        }

        public abstract override string ToString();

        public abstract bool IsValidSender();

        public string ToFormHeader()
        {
            return $"{( Type.ToString() ).Substring(0, 1)}{ID}";
        }

        public virtual string ToFormBody()
        {
            return $"{Sender} {Body}";
        }

        public string ToJson()
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            try
            {
                using(StreamWriter sw = new StreamWriter("json.JSON", true))
                {
                    using(JsonWriter writer = new JsonTextWriter(sw))
                    {
                        serializer.Serialize(writer, this);
                        sw.WriteLine();
                    }
                    return JsonConvert.SerializeObject(this);
                }
            }
            catch
            {
                return null;
            }

        }
    }
}
