using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab13;
using ClassLibrary1;
using System.Collections;
using System.IO;

namespace UnitTestProject13
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_JournalEntry_Constructor_()
        {
            string collectionName = "Name";
            string changeType = "Add";
            string data = "Data";
            JournalEntry journalEntry = new JournalEntry(collectionName, changeType, data);
            Assert.AreEqual(collectionName, journalEntry.CollectionName);
            Assert.AreEqual(changeType, journalEntry.ChangeType);
            Assert.AreEqual(data, journalEntry.Data);
        }
        [TestMethod]
        public void TestMethod_JournalEntry_ToString()
        {
            string CollectionName = "Name";
            string ChangeType = "Add";
            string Data = "Data";
            JournalEntry journalEntry = new JournalEntry(CollectionName, ChangeType, Data);
            string str = journalEntry.ToString();
            Assert.AreEqual($"В коллекции {CollectionName} {ChangeType}. Обьект: {Data}", str);
        }
        [TestMethod]
        public void TestMethod_Journal_WriteRecord() //Добавление записи в журнал
        {
            Journal<CelestialBody> journal = new Journal<CelestialBody>();
            MyObservableCollection<CelestialBody> collection = new MyObservableCollection<CelestialBody>("TestCollection");
            CelestialBody celbody = new CelestialBody();
            journal.WriteRecord(collection, new CollectionHandlerEventArgs("добавлен элемент", celbody));
            Assert.AreEqual(1, journal.Count);
        }
        [TestMethod]
        public void TestMethod_CollectionHandlerEventArgs_Constructor()  //Конструктор CollectionHandlerEventArgs
        {
            string changeType = "Add";
            object item = new object();
            CollectionHandlerEventArgs eventArgs = new CollectionHandlerEventArgs(changeType, item);
            Assert.AreEqual(changeType, eventArgs.ChangeType);
            Assert.AreEqual(item, eventArgs.Item);
        }
        [TestMethod]
        public void TestMethod_CollectionHandlerEventArgs_GetSet() //Свойства CollectionHandlerEventArgs
        {
            string changeType = "Add";
            object item = new object();
            CollectionHandlerEventArgs eventArgs = new CollectionHandlerEventArgs(changeType, item);
            eventArgs.ChangeType = "Remove";
            eventArgs.Item = null;
            Assert.AreEqual("Remove", eventArgs.ChangeType);
            Assert.IsNull(eventArgs.Item);
        }
        [TestMethod]
        public void TestMethod_AddItem_CollectionCountChange_Add() //Обработчик события добавления 
        {
            MyObservableCollection<CelestialBody> collection = new MyObservableCollection<CelestialBody>("Numbers");
            Journal<CelestialBody> journal1 = new Journal<CelestialBody>();
            int count = journal1.Count;
            collection.CollectionCountChange += journal1.WriteRecord; ;
            collection.Add(new CelestialBody());
            count++;
            Assert.AreEqual(count, journal1.Count);
        }
        [TestMethod]
        public void TestMethod_AddItem_CollectionCountChange_Remove() //Обработчик события удаления
        {
            MyObservableCollection<CelestialBody> collection = new MyObservableCollection<CelestialBody>("Numbers");
            Journal<CelestialBody> journal1 = new Journal<CelestialBody>();
            collection.CollectionCountChange += journal1.WriteRecord;
            collection.Add(new CelestialBody("1", 1, 1, 1));
            collection.Add(new CelestialBody("2", 1, 1, 1));
            collection.Add(new CelestialBody("3", 1, 1, 1));
            int count = journal1.Count;
            collection.Remove(new CelestialBody());
            collection.Remove(new CelestialBody("1", 1, 1, 1));
            count++;
            Assert.AreEqual(count, journal1.Count);
        }
        [TestMethod]
        public void TestMethod_Index() //Обработчик события индексатор
        {
            MyObservableCollection<CelestialBody> collection = new MyObservableCollection<CelestialBody>("Numbers");
            Journal<CelestialBody> journal1 = new Journal<CelestialBody>();
            collection.CollectionReferenceChange += journal1.WriteRecord;
            CelestialBody item1 = new CelestialBody("1", 1, 1, 1);
            CelestialBody item2 = new CelestialBody("2", 1, 1, 1);
            CelestialBody item3 = new CelestialBody("3", 1, 1, 1);
            collection.Add(item1);
            collection.Add(item2);
            int count = journal1.Count;
            collection[item2] = item3;
            count++;
            Assert.AreEqual(count, journal1.Count);
            Assert.IsTrue(collection.Contains(item3));
            Assert.IsFalse(collection.Contains(item2));
        }
        [TestMethod]
        public void TestMethod_CollectionCountChange() //Генерация события
        {
            MyObservableCollection<CelestialBody> collection = new MyObservableCollection<CelestialBody>("Numbers");
            bool Event = false;
            collection.CollectionCountChange += (source, args) => Event = true;
            collection.OnCollectionCountChange(this, new CollectionHandlerEventArgs("А", new CelestialBody()));
            Assert.IsTrue(Event);
        }
        [TestMethod]
        public void TestMethod_CollectionReferenceChange()   //Генерация события
        {
            MyObservableCollection<CelestialBody> collection = new MyObservableCollection<CelestialBody>("Numbers");
            bool Event = false;
            collection.CollectionReferenceChange += (source, args) => Event = true;
            collection.OnCollectionReferenceChange(this, new CollectionHandlerEventArgs("А", new CelestialBody()));
            Assert.IsTrue(Event);
        }
        [TestMethod]
        public void TestMethod_PrintEmptyJournal()   //Печать пустого журнала
        {
            Journal<CelestialBody> journal = new Journal<CelestialBody>();
            StringWriter sw = new StringWriter();  //для записи вывода в консоль
            Console.SetOut(sw);                    //Запись вывода консоли в sw
            journal.PrintJournal();
            string message = $"Журнал пустой{Environment.NewLine}";  //Environment.NewLine  для обозначения конца строки "\n"
            Assert.AreEqual(message, sw.ToString());
        }
    }
}
