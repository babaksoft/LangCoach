using System;

namespace BabakSoft.LangCoach.Model
{
    public class Word
    {
        public Word()
        {
            Meanings = new List<Meaning>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Can be masculin, féminin, both
        /// </summary>
        /// <remarks>
        /// When both genders apply (e.g. in adjectives, profession names, etc.) name will contain both forms,
        /// first the male form, then the female form, separated by comma (e.g. vert,verte)
        /// </remarks>
        public string Gender { get; set; }

        public List<Meaning> Meanings { get; private set; }
    }
}
