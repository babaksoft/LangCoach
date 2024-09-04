using System;

namespace BabakSoft.LangCoach.Model
{
    public class Topic : IDataItem
    {
        public static string DataPath
        {
            get { return Path.Combine("..", "..", "..", "Data", "topics.json"); }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<SubTopic> SubTopics { get; private set; }
    }
}
