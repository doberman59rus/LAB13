using LAB12;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchLibrary;

namespace LAB13
{
    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);
    public class MyObservableCollection<T> : MyCollection<T> where T : Watch
    {
        public string Name { get; set; }

        public MyObservableCollection(string name) : base()
        {
            Name = name;
        }

        /// <summary>
        /// Событие с делегатом.
        /// </summary>
        public event CollectionHandler CollectionChanged;

        /// <summary>
        /// Событие, которое происходит при добавлении нового элемента в коллекцию или при удалении элемента
        /// из коллекции; через объект CollectionHandlerEventArgs cобытие передает строку с информацией о том, 
        /// что в коллекцию был добавлен новый элемент или из нее был удален элемент, ссылку на добавленный или удаленный элемент.
        /// </summary>
        public event CollectionHandler CollectionCountChanged;

        /// <summary>
        /// Событие, которое происходит, когда одной из ссылок, входящих в коллекцию, присваивается новое значение;
        /// через объект CollectionHandlerEventArgs событие передает строку с информацией о том, что был заменен элемент в коллекции,
        /// и ссылку на новый элемент. 
        /// </summary>
        public event CollectionHandler CollectionReferenceChanged;

        /// <summary>
        /// Переопределение метода Add
        /// </summary>
        /// <param name="item"></param>
        public override void Add(T item)
        {
            base.Add(item);
            OnCollectionChanged("Добавление элемента", item);
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs("Добавление элемента", item));
        }
        /// <summary>
        /// Переопределение метода Remove
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override bool Remove(T item)
        {
            bool removed = base.Remove(item);
            if (removed)
            {
                OnCollectionChanged("Удаление первого совпадающего элемента", item);
                OnCollectionCountChanged(this, new CollectionHandlerEventArgs("Удаление элемента", item));
            }
            return removed;
        }
        /// <summary>
        /// Переопределение метода RemoveAt
        /// </summary>
        /// <param name="index"></param>
        //public override void RemoveAt(int index)
        //{
        //    T removedItem = this[index];
        //    base.RemoveAt(index);
        //    OnCollectionChanged("Удаление элемента по индексу", removedItem);
        //    OnCollectionCountChanged(this, new CollectionHandlerEventArgs("Удаление элемента по индексу", removedItem));
        //}
        /// <summary>
        /// Переопределение метода Clear
        /// </summary>
        public override void Clear()
        {
            base.Clear();
            OnCollectionChanged("Очистка коллекции");
        }
        /// <summary>
        /// Переопределение метода замены элементов
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public override T this[int index]
        {
            get => base[index];
            set
            {
                T oldItem = base[index];
                base[index] = value;
                OnCollectionChanged("Замена элемента", oldItem, value);
                OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs("Замена элемента", oldItem, value));
            }
        }

        public override Watch GenerateRandomWatch(Random rnd) => base.GenerateRandomWatch(rnd);

        /// <summary>
        /// Метод для вызова события.
        /// </summary>
        /// <param name="changeType">Тип изменения, которое будет проведено с элементами коллекции</param>
        /// <param name="item">Элемент, используемый при всех операциях (кроме очистки всей коллекции)</param>
        /// <param name="newItem">Элемент, используемый при операции замены элементов</param>
        public virtual void OnCollectionChanged(string changeType, object item = null, object newItem = null)
        {
            CollectionHandlerEventArgs args;
            
            //Изменение типа "ЗАМЕНА"
            if (changeType == "Замена элемента")
                args = new CollectionHandlerEventArgs(changeType, item, newItem);
            //Изменения типа "ДОБАВЛЕНИЕ" / "УДАЛЕНИЕ" / "УДАЛЕНИЕ ПО ИНДЕКСУ"
            else if (item != null)
                args = new CollectionHandlerEventArgs(changeType, item);
            //Изменение типа "ОЧИСТКА КОЛЛЕКЦИИ"
            else
                args = new CollectionHandlerEventArgs(changeType);
            if(CollectionChanged != null)
            {
                CollectionChanged(this, args);
            }
        }
        /// <summary>
        /// Метод для вызова события, которое происходит при добавлении нового элемента в коллекцию или при удалении элемента из коллекции.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public virtual void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            CollectionCountChanged?.Invoke(this, args);
        }
        /// <summary>
        /// Метод для вызова события, которое происходит при добавлении нового элемента в коллекцию или при удалении элемента из коллекции.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public virtual void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            CollectionReferenceChanged?.Invoke(this, args);
        }
    }
}
