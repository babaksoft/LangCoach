using System;

namespace BabakSoft.LangCoach.Model
{
    /// <summary>
    /// Defines a contract for a data item that represents a language element
    /// </summary>
    public interface ILanguageItem : IDataItem
    {
        /// <summary>
        /// Gets or sets the text of this language element in source language (French)
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets a collection of meanings for this language element
        /// </summary>
        List<Meaning> Meanings { get; }
    }
}
