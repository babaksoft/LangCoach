using System;

namespace BabakSoft.LangCoach.Model
{
    public class Verb : ILanguageItem
    {
        public Verb()
        {
            Meanings = new List<Meaning>();
        }

        public static string DataPath
        {
            get { return Path.Combine("..", "..", "..", "Data", "verbs.json"); }
        }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Main form of the verb; e.g. parler, ouvrir, etc.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Verbs are classified by their endings; e.g. -er, -ir, etc.
        /// </summary>
        /// <remarks>This property may not apply to languages other than French.</remarks>
        public string EndForm { get; set; }

        /// <inheritdoc/>
        public List<Meaning> Meanings { get; private set; }
    }
}
