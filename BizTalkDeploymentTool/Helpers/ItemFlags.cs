using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizTalkDeploymentTool.Helpers
{
    public class ItemFlags<T, U>
    {
        private Dictionary<T, U> _itemFlagDictionary = new Dictionary<T, U>();
        private Object _syncLock = new Object();
        public void Create(T item, U value)
        {
            lock (_syncLock)
            {
                _itemFlagDictionary.Add(item, value);
            }
        }

        public void Remove(T item)
        {
            lock (_syncLock)
            {
                _itemFlagDictionary.Remove(item);
            }
        }
        public U this[T item]
        {
            get
            {
                lock (_syncLock)
                {
                    return _itemFlagDictionary[item];
                }
            }
        }
        public bool Exists(T item)
        {
            return _itemFlagDictionary.ContainsKey(item);
        }
    }
}
