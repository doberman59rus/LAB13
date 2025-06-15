using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB13
{
    public class CollectionHandlerEventArgs : EventArgs
    {
        public string ChangeType { get; set; }
        public object ChangedItem { get; set; }
        public object OldItem { get; set; }

        /// <summary>
        /// Конструктор для изменения одного элемента
        /// </summary>
        /// <param name="changeType"><summary>Тип изменения, которое проводится над элементом</summary></param>
        /// <param name="changedItem"><summary>Элемент, над которым производится изменение</summary></param>
        public CollectionHandlerEventArgs(string changeType, object changedItem)
        {
            ChangeType = changeType;
            ChangedItem = changedItem;
        }
        /// <summary>
        /// Конструктор для события Clear (очищение коллекции)
        /// </summary>
        /// <param name="changeType"><summary>Изменение, которое будет проводиться</summary></param>
        public CollectionHandlerEventArgs(string changeType)
        {
            ChangeType = changeType;
            ChangedItem = null;
        }
        /// <summary>
        /// Конструктор для Replace из старого и нового элемента
        /// </summary>
        /// <param name="changeType"><summary>Тип изменения, которое проводится над элементом</summary></param>
        /// <param name="oldItem"><summary>Старый элемент, который будет заменен</summary></param>
        /// <param name="newItem"><summary>Новый элемент, который заменит старый</summary></param>
        public CollectionHandlerEventArgs(string changeType, object oldItem, object newItem)
        {
            ChangeType = changeType;
            OldItem = oldItem;
            ChangedItem = newItem;
        }
    }
}
