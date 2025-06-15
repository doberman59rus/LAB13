using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB13
{
    public class Journal
    {
        private List<JournalEntry> entries = new List<JournalEntry>();
        public string Name { get; set; }

        /// <summary>
        /// Метод добавления записи в журнал.
        /// </summary>
        /// <param name="collectionName">Имя коллекции.</param>
        /// <param name="changeType">Тип изменения, которое проводится с коллекцией.</param>
        /// <param name="changedItem">Измененный элемент.</param>
        public void AddEntry(string collectionName, string changeType, object changedItem)
        {
            entries.Add(new JournalEntry(collectionName, changeType, changedItem));
        }

        /// <summary>
        /// Метод вывода всех записей журнала.
        /// </summary>
        public void PrintAll()
        {
            foreach (var entry in entries)
            {
                Console.WriteLine(entry);
            }
        }

        // Получение всех записей (для тестов или сериализации)
        public IReadOnlyList<JournalEntry> Entries => entries.AsReadOnly();
    }
}
