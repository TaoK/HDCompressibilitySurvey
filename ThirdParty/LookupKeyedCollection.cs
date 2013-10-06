using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace HDSurvey
{
    //Another utility class from stackoverflow:
    //http://stackoverflow.com/a/3297478/74296
    public class LookupKeyedCollection<TKey, TItem> : KeyedCollection<TKey, TItem>
    {
        private Func<TItem, TKey> _getKeyFunc;

        public LookupKeyedCollection(Func<TItem, TKey> getKeyFunc)
        {
            _getKeyFunc = getKeyFunc;
        }

        public LookupKeyedCollection(Func<TItem, TKey> getKeyFunc, IEqualityComparer<TKey> comparer) : base(comparer)
        {
            _getKeyFunc = getKeyFunc;
        }

        protected override TKey GetKeyForItem(TItem item)
        {
            return _getKeyFunc(item);
        }

        public bool TryGetValue(TKey key, out TItem item)
        {
            if (Dictionary == null)
            {
                item = default(TItem);
                return false;
            }

            return Dictionary.TryGetValue(key, out item);
        }

        public void AddOrUpdate(TItem item)
        {
            Remove(_getKeyFunc(item));
            Add(item);
        }

        public new bool Contains(TItem item)
        {
            return base.Contains(_getKeyFunc(item));
        }
    }
}
