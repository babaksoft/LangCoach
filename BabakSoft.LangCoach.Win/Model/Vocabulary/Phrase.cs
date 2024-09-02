using System;

namespace BabakSoft.LangCoach.Model
{
    /// <summary>
    /// Represents a useful phrase in source language (French)
    /// </summary>
    public class Phrase : ILanguageItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Phrase"/> class
        /// </summary>
        public Phrase()
        {
            Meanings = new List<Meaning>();
        }

        /// <summary>
        /// Gets the path of the physical file where phrases are persisted
        /// </summary>
        public static string DataPath
        {
            get { return Path.Combine("..", "..", "..", "Data", "phrases.json"); }
        }

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public List<Meaning> Meanings { get; private set; }
    }
}
