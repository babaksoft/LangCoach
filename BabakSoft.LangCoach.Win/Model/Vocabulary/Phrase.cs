using System;

namespace BabakSoft.LangCoach.Model
{
    public class Phrase
    {
        public Phrase()
        {
            Meanings = new List<Meaning>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<Meaning> Meanings { get; private set; }
    }
}
