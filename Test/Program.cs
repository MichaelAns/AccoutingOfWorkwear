using AoW.EntityFramework.Date;
using AoW.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

List<Staff> staff = new()
{
    new Staff()
    {
        FirstName = "Игорь",
        SecondName = "Стрелков",
        LastName = "Иванович",
        Post = "Командир",
        Profession = "Наводчик"
    },
    new Staff()
    {
        FirstName = "Евгений",
        SecondName = "Пригожин",
        LastName = "Викторович",
        Post = "Главный",
        Profession = "Предприниматель"
    },
    new Staff()
    {
        FirstName = "Антон",
        SecondName = "Фикалис",
        LastName = "Палыч",
        Post = "Директор",
        Profession = "Упалнамоченый"
    }
};

Provider provider = new()
{
    Name = "БТК групп",
    Country = "Россия",
    City = "Москва",
    Street = "Чкаловская",
    Home = 1,
    Phone = "849951337"
};

WorkWear workwear = new()
{
    Name = "Комлпект ВКПО",
    Type = "Костюм",
    Price = 50000   
};
WorkWear workwear2 = new()
{
    Name = "Комлпект Ратник",
    Type = "Костюм",
    Price = 150000
};

ReceiptInfo receiptInfo = new()
{
    Provider = provider,
    Workwear = workwear,
    Count = 3,
    Date = new DateOnly(2022, 11, 30),
    Remains = 3
};
ReceiptInfo receiptInfo2 = new()
{
    Provider = provider,
    Workwear = workwear2,
    Count = 3,
    Date = new DateOnly(2022, 11, 30),
    Remains = 3
};

using (var dbContext = new AowDbContextFactory().CreateDbContext())
{
    dbContext.AddRange(staff);
    dbContext.Add(receiptInfo);
    dbContext.Add(receiptInfo2);
    /*dbContext.Add(provider);
    dbContext.Add(workwear);*/


    /*ExtraditionInfo _extraditionInfo = new()
    {
        Date = new DateOnly(2022, 12, 1),
        Staff = dbContext.Staff.FirstOrDefault(s => s.FirstName == staff.FirstName),
        Term = 3,
        WorkWear = dbContext.Workwear.FirstOrDefault(s => s.Name == workwear.Name)
    };

    dbContext.Add(_extraditionInfo);*/
    dbContext.SaveChanges();



    Console.WriteLine("Succesfully");

}

async void Load()
{
    System.Console.WriteLine("\t_BEGIN LOAD_\t");
    System.Console.WriteLine("|||||||BEGIN ASYNC METHOD");
    await Task.Run(() =>
    {
        using (var dbContext = new AowDbContextFactory().CreateDbContext())
        {
            //staff = new(dbContext.Staff);
            Fikalis(dbContext);
        }
        System.Console.WriteLine("||||||||END ASYNC METHOD");
    });
    System.Console.WriteLine("\t_END LOAD_\t");
}

void Fikalis(AowDbContext dbContext)
{
    Console.WriteLine("\nFIKALIS ARBEITEN\n");
    //staff = new(dbContext.Staff);
    Console.WriteLine("\nFIKALIS ARBEITEN\n");
}
void Test1()
{
    Load();
    Console.WriteLine("-----OUT FROM LOAD");
    Console.WriteLine("////BEGIN WAITING");
    Thread.Sleep(5000);
    Console.WriteLine("////END WAITING");
    //Console.WriteLine($"{staff[0].FirstName}\n{staff[1].FirstName}\n{staff[2].FirstName}");
}
void Test2()
{

}