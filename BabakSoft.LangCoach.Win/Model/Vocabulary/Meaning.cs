using System;

namespace BabakSoft.LangCoach.Model
{
    public class Meaning
    {
        /// <summary>
        /// Expected to always have value. However, because it models an indirect relationship,
        /// might be null in special cases.
        /// </summary>
        public int? TopicId { get; set; }

        /// <summary>
        /// Localized meaning in current language
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Short language code; e.g. en, fa, etc.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Any special context applicable to this meaning, if any
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        /// Situation applicable to this meaning; e.g. formal, friendly, familiar, vulgar, etc.
        /// Default is null (Not Applicable or N/A)
        /// </summary>
        public string Usage { get; set; }
    }
}
