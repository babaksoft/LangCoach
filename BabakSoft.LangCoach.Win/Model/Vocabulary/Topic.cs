using System;

namespace BabakSoft.LangCoach.Model
{
    public class Topic
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<SubTopic> SubTopics { get; private set; }
    }
}
