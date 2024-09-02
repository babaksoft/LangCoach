using System;

namespace BabakSoft.LangCoach.Model
{
    /// <summary>
    /// Defines a contract for simple data items
    /// </summary>
    public interface IDataItem
    {
        /// <summary>
        /// Gets or sets the unique identifier for this data item instance
        /// </summary>
        int Id { get; set; }
    }
}
