using BabakSoft.LangCoach.Model;
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
        public JsonRepository(string dataPath)
            : base(dataPath)
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

        /// <summary>
        /// Inserts a collection of language items into the underlying data storage
        /// </summary>
        /// <param name="items">Collection of items to insert</param>
        public void SaveDataItems(IEnumerable<TItem> items)
        {
            Verify.ArgumentNotNull(items, nameof(items));
            if (!items.Any())
            {
                return;
            }

            var allItems = GetAllItems();
            var idProvider = new IdentityProvider<TItem>(allItems);
            foreach (var item in allItems)
            {
                item.Id = idProvider.NextId();
            }

            allItems.AddRange(items);
            ApplyChanges(allItems);
        }
    }
}
