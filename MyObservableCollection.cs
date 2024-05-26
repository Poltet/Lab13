using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using ClassLibrary12;

namespace Lab13
{
    public delegate void CollectionHandler<T>(object source, CollectionHandlerEventArgs args);  //Делегат
    public class MyObservableCollection<T> : MyCollection<T> where T : IInit, ICloneable, new()
    {
        public string CollectionName { get; set; } //Имя коллекции
        public MyObservableCollection(string name)  //Конструктор с параметром - имя коллекции
        {
            CollectionName = name;
        }
        public event CollectionHandler<T> CollectionCountChange;      //Событие при изменении количества элементов
        public event CollectionHandler<T> CollectionReferenceChange;  //Событие при изменении ссылки
        public void OnCollectionCountChange(object source, CollectionHandlerEventArgs args) //Генерация события изменения количества элементов
        {
            CollectionCountChange?.Invoke(this, args);  //Вызов события
        }
        public void OnCCollectionReferenceChange(object source, CollectionHandlerEventArgs args) //Генерация события изменения ссылки
        {
            CollectionReferenceChange?.Invoke(this, args);  //Вызов события
        }
        public void Add(T item)  //Добавление элемента
        { 
            base.Add(item);     //Добавление элемента в коллекцию 
            OnCollectionCountChange(this, new CollectionHandlerEventArgs("добавлен элемент", new Point<T>(item)));  
        }
        public bool Remove(T item)           //Удаление элемента
        {
            bool remove = base.Remove(item); //Удаление элемента из коллекции
            if (remove)
                OnCollectionCountChange(this, new CollectionHandlerEventArgs("удален элемент", new Point<T>(item)));
            return remove;
        }
        public T this[int index]
        {
            set
            {
                if (! value.Equals(base[index]))
                {
                    base[index] = value;
                    OnCCollectionReferenceChange(this, new CollectionHandlerEventArgs("изменена ссылка на обьект", value));
                }                              
            }
        }
    }
}


