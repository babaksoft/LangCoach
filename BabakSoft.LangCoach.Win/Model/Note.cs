using System;

namespace BabakSoft.LangCoach.Model
{
    /// <summary>
    /// Represents a free-form text or article in source language (French)
    /// </summary>
    public class Note : IDataItem
    {
        /// <summary>
        /// Gets the path of the physical file where notes are persisted
        /// </summary>
        public static string DataPath
        {
            get { return Path.Combine("..", "..", "..", "Data", "notes.json"); }
        }

        /// <summary>
        /// Gets or sets the unique identifier for this note
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the note title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the date and time when this note was first created
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the date and time when this note was last modified
        /// </summary>
        public DateTime LastModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the number of times this note has been modified
        /// </summary>
        public int RevisionCount { get; set; }

        /// <summary>
        /// Gets or sets the main content of this note
        /// </summary>
        public string Text { get; set; }
    }
}
