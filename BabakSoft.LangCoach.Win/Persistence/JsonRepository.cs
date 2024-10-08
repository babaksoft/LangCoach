﻿using BabakSoft.LangCoach.Model;
using BabakSoft.Platform.Common;

namespace BabakSoft.LangCoach.Persistence
{
    /// <summary>
    /// Provides persistence operations required for manipulating language items
    /// </summary>
    /// <typeparam name="TItem">Type of language item in Json data storage</typeparam>
    public class JsonRepository<TItem> : JsonRepositoryBase<TItem>
        where TItem : class, ILanguageItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonRepository{TItem}"/> class
        /// </summary>
        /// <param name="dataPath">Path of physical data file where items are persisted</param>
        /// <param name="webSafe">
        /// Indicates if special characters need to be escaped to improve Web security
        /// </param>
        public JsonRepository(string dataPath, bool webSafe = true)
            : base(dataPath, webSafe)
        {
        }

        /// <summary>
        /// Reads and returns all items related to the given topic
        /// </summary>
        /// <param name="topicId">Unique identifier of the topic of interest</param>
        /// <returns>Collection of all items related to the given topic</returns>
        public List<TItem> GetItemsByTopic(int topicId)
        {
            var allItems = GetAllItems();
            var byTopicIds = allItems
                .SelectMany(item => item.Meanings)
                .Where(meaning => meaning.TopicId.HasValue
                    && meaning.TopicId.Value == topicId)
                .Select(meaning => meaning.ParentId);
            return allItems
                .Where(item => byTopicIds.Contains(item.Id))
                .ToList();
        }
    }
}
