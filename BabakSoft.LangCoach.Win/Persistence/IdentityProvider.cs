using BabakSoft.LangCoach.Model;
using BabakSoft.Platform.Common;

namespace BabakSoft.LangCoach.Persistence
{
    /// <summary>
    /// Provides auto-incrementing identity values based on existing data
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public class IdentityProvider<TItem>
        where TItem : class, IDataItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityProvider{TItem}"/> class
        /// </summary>
        /// <param name="items">Collection of existing items in the storage</param>
        public IdentityProvider(IEnumerable<TItem> items)
        {
            Verify.ArgumentNotNull(items, nameof(items));
            _lastId = items.Any()
                ? items.Max(i => i.Id)
                : 0;
        }

        /// <summary>
        /// Returns next unique identity value
        /// </summary>
        /// <returns>Next identity value</returns>
        public int NextId()
        {
            _lastId++;
            return _lastId;
        }

        private int _lastId;
    }
}
