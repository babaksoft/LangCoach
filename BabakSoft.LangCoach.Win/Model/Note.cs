using System;

namespace BabakSoft.LangCoach.Model
{
    public class Note
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public int RevisionCount { get; set; }

        public string Text { get; set; }
    }
}
