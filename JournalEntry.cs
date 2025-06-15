using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB13
{
    public class JournalEntry
    {
        /// <summary>
        /// Запись имени коллекции.
        /// </summary>
        public string CollectionName { get; set; }

        /// <summary>
        /// Запись типа изменения. (Add, Remove, Clear, Replace)
        /// </summary>
        public string ChangeType { get; set; }

        /// <summary>
        /// Информация об элементе.
        /// </summary>
        public string ChangedItemData { get; set; }

        public JournalEntry(string collectionName, string changeType, object changedItem)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            if (changedItem != null)
            {
                ChangedItemData = changedItem.ToString();
            }
        }

        public override string ToString()
        {
            return $"Коллекция: {CollectionName}\nТип изменения:{ChangeType}\nОбъект: {ChangedItemData}";
        }
    }
}
