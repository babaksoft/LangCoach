using System;

namespace BabakSoft.LangCoach.Model
{
    public class Word : ILanguageItem
    {
        public Word()
        {
            Meanings = new List<Meaning>();
        }

        public static string DataPath
        {
            get { return Path.Combine("..", "..", "..", "Data", "words.json"); }
        }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }

        /// <summary>
        /// Can be masculin, féminin, both
        /// </summary>
        /// <remarks>
        /// When both genders apply (e.g. in adjectives, profession names, etc.) name will contain both forms,
        /// first the male form, then the female form, separated by comma (e.g. vert,verte)
        /// </remarks>
        public string Gender { get; set; }

        /// <inheritdoc/>
        public List<Meaning> Meanings { get; private set; }
    }
}
