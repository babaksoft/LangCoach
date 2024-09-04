using System.Text;
using BabakSoft.LangCoach.Helper;
using BabakSoft.LangCoach.Model;
using BabakSoft.Platform.Common;

namespace BabakSoft.LangCoach.Persistence
{
    /// <summary>
    /// Provides persistence operations that can be performed on a simple Json data storage
    /// </summary>
    /// <typeparam name="TItem">Type of data item in Json data storage</typeparam>
    /// <remarks>A 'Simple' storage means the root object is a list of data items</remarks>
    public class JsonRepositoryBase<TItem>
        where TItem : class, IDataItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonRepositoryBase{TItem}"/> class
        /// </summary>
        /// <param name="dataPath">Path of physical data file where items are persisted</param>
        /// <param name="webSafe">
        /// Indicates if special characters need to be escaped to improve Web security
        /// </param>
        public JsonRepositoryBase(string dataPath, bool webSafe = true)
        {
            Verify.ArgumentNotNullOrWhitespace(dataPath, nameof(dataPath));
            DataPath = dataPath;
            WebSafe = webSafe;
        }

        /// <summary>
        /// Gets the path of physical data file where items are persisted
        /// </summary>
        public string DataPath { get; }

        /// <summary>
        /// Gets a value that indicates if special characters need to be escaped
        /// to improve Web security
        /// </summary>
        public bool WebSafe { get; }

        /// <summary>
        /// Reads and returns all existing items from data storage
        /// </summary>
        /// <returns>Collection of all existing items</returns>
        public List<TItem> GetAllItems()
        {
            return JsonHelper.To<List<TItem>>(
                File.ReadAllText(DataPath, Encoding.UTF8), WebSafe);
        }

        /// <summary>
        /// Adds or edits a single item in data storage
        /// </summary>
        /// <param name="item">Item to be added or edited</param>
        public void SaveDataItem(TItem item)
        {
            Verify.ArgumentNotNull(item, nameof(item));
            var allItems = GetAllItems();
            if (item.Id == 0)
            {
                var idProvider = new IdentityProvider<TItem>(allItems);
                item.Id = idProvider.NextId();
                allItems.Add(item);
            }
            else
            {
                var existing = allItems.FirstOrDefault(i => i.Id == item.Id);
                if (existing != null)
                {
                    int index = allItems.IndexOf(existing);
                    allItems.Remove(existing);
                    allItems.Insert(index, item);
                }
            }

            ApplyChanges(allItems);
        }

        /// <summary>
        /// Inserts a collection of items into the underlying data storage
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
            foreach (var item in items)
            {
                item.Id = idProvider.NextId();
            }

            allItems.AddRange(items);
            ApplyChanges(allItems);
        }

        /// <summary>
        /// Deletes a single item from data storage
        /// </summary>
        /// <param name="itemId">Unique identifier of the item to be deleted</param>
        public void DeleteDataItem(int itemId)
        {
            var allItems = GetAllItems();
            var item = allItems.FirstOrDefault(i => i.Id == itemId);
            if (item != null)
            {
                allItems.Remove(item);
                ApplyChanges(allItems);
            }
        }

        /// <summary>
        /// Applies all changes in data storage
        /// </summary>
        /// <param name="items">Collection of items to be saved in data storage</param>
        /// <remarks>This methods provides basic transaction support and requires that input
        /// collection contain the whole existing data in physical storage.</remarks>
        public void ApplyChanges(List<TItem> items)
        {
            Verify.ArgumentNotNull(items, nameof(items));
            File.WriteAllText(DataPath, JsonHelper.From(items, WebSafe), Encoding.UTF8);
        }
    }
}
