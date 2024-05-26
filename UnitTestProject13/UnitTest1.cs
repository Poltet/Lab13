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
        public void TestMethod_AddItem_CollectionCountChange__Add()
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
        public void TestMethod_AddItem_CollectionCountChange_Remove()
        {
            MyObservableCollection<CelestialBody> collection = new MyObservableCollection<CelestialBody>("Numbers");
            Journal<CelestialBody> journal1 = new Journal<CelestialBody>();
            collection.CollectionCountChange += journal1.WriteRecord; 
            collection.Add(new CelestialBody("1",1,1,1));
            collection.Add(new CelestialBody("2", 1, 1, 1));
            collection.Add(new CelestialBody("3", 1, 1, 1));
            int count = journal1.Count;
            collection.Remove(new CelestialBody());
            collection.Remove(new CelestialBody("1", 1, 1, 1));
            count++;
            Assert.AreEqual(count, journal1.Count);
        }
    }
    
}
