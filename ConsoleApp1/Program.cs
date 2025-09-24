using System;
using System.Collections.Generic;

class Avto
{
    public int ID { get; set; }
    public string Marka { get; set; }
    public string nickname { get; set; }
    public int Probeg { get; set; }
}

class Program
{
    static void Show(List<Avto> list, string title)
    {
        Console.WriteLine("\n " + title);
        foreach (var a in list)
        {
            Console.WriteLine($"ID={a.ID}, Марка={a.Marka}, Владелец={a.nickname}, Пробег={a.Probeg}");
        }
    }

    static void Main()
    {
        List<Avto> AvtoPark = new List<Avto>()
        {
            new Avto(){ID=1, Marka="Ford", nickname="Гурьев А.", Probeg=38000},
            new Avto(){ID=2, Marka="Audi", nickname="Сидоров П.", Probeg=45000},
            new Avto(){ID=3, Marka="Bentley", nickname="Петров А.", Probeg=98000},
            new Avto(){ID=4, Marka="Ford", nickname="Иванов Д.", Probeg=47000},
            new Avto(){ID=5, Marka="Audi", nickname="Григорьев И.", Probeg=10000}
        };

        Show(AvtoPark, "Начальный список");

       
        AvtoPark.Insert(2, new Avto() { ID = 6, Marka = "Ferrari", nickname = "Старостин Г.", Probeg = 58000 });
        Show(AvtoPark, "После вставки Ferrari перед ID=3");

        // Удаляем объект с ID=3
        Avto toDelete = AvtoPark.Find(x => x.ID == 3);
        if (toDelete != null) AvtoPark.Remove(toDelete);
        Show(AvtoPark, "После удаления ID=3");

      
        List<Avto> AvtoFords = AvtoPark.FindAll(x => x.Marka == "Ford");
        Show(AvtoFords, "Только автомобили Ford");

      
        AvtoPark.Sort((a1, a2) =>
        {
            int cmp = a1.Probeg.CompareTo(a2.Probeg);
            if (cmp == 0) return a1.nickname.CompareTo(a2.nickname);
            return cmp;
        });
        Show(AvtoPark, "После сортировки (пробег, ФИО)");
        Console.ReadKey();
        Console.WriteLine("Выполнил: Локтев Артем 23ИС ");
    }
}
