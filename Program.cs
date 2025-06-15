using LAB13;
using WatchLibrary;
using LAB12;

class Program
{
    static void Main(string[] args)
    {
        // 1. Создаём две коллекции
        var collection1 = new MyObservableCollection<Watch>("Коллекция 1");
        var collection2 = new MyObservableCollection<Watch>("Коллекция 2");

        // 2. Создаём два журнала
        var journal1 = new Journal();
        var journal2 = new Journal();

        // 3. Подписываем журналы на события:
        // - journal1: на CollectionCountChanged и CollectionReferenceChanged из collection1
        collection1.CollectionCountChanged += (sender, args) =>
            journal1.AddEntry(collection1.Name, args.ChangeType, args.ChangedItem);
        collection1.CollectionReferenceChanged += (sender, args) =>
            journal1.AddEntry(collection1.Name, args.ChangeType, args.ChangedItem);

        // - journal2: на CollectionReferenceChanged из обеих коллекций
        collection1.CollectionReferenceChanged += (sender, args) =>
            journal2.AddEntry(collection1.Name, args.ChangeType, args.ChangedItem);
        collection2.CollectionReferenceChanged += (sender, args) =>
            journal2.AddEntry(collection2.Name, args.ChangeType, args.ChangedItem);

        // 4. Вносим изменения в коллекции
        Console.WriteLine("=== Добавляем элементы ===");
        collection1.Add(new );
        collection2.Add(new SmartWatch { Brand = "Apple", OS = "WatchOS" });

        Console.WriteLine("=== Заменяем элементы ===");
        collection1[0] = new ElectronicWatch { Brand = "Garmin", BatteryLife = 7 };
        collection2[0] = new AnalogWatch { Brand = "Rolex", HandsCount = 2 };

        Console.WriteLine("=== Удаляем элементы ===");
        collection1.RemoveAt(0);

        // 5. Выводим журналы
        Console.WriteLine("\n=== Журнал 1 (Count + Ref из Collection1) ===");
        journal1.PrintAll();

        Console.WriteLine("\n=== Журнал 2 (Ref из обеих коллекций) ===");
        journal2.PrintAll();
    }
}