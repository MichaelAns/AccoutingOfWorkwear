using AoW.EntityFramework.Date;
using AoW.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

List<Staff> staff = new();
/*staff.Add(new Staff()
{
    FirstName = "Ivan",
    SecondName = "Ivanov",
    LastName = "Ivaniich",
    Post = "Serjant",
    Profession = "Operator"
}) ;
staff.Add(new Staff()
{
    FirstName = "Ivan",
    SecondName = "Ivanov",
    LastName = "Ivaniich",
    Post = "Serjant",
    Profession = "Operator"
});
staff.Add(new Staff()
{
    FirstName = "Ivan",
    SecondName = "Ivanov",
    LastName = "Ivaniich",
    Post = "Serjant",
    Profession = "Operator"
});*/

/*using (var dbContext = new AowDbContextFactory().CreateDbContext())
{
    *//*dbContext.AddRange(staff);
    dbContext.SaveChanges();*//*
    
    staff = new(dbContext.Staff);
    Console.WriteLine("Succesfully");    
    
}*/
Load();
Console.WriteLine("-----OUT FROM LOAD");
Console.WriteLine("////BEGIN WAITING");
Thread.Sleep(5000);
Console.WriteLine("////END WAITING");
Console.WriteLine($"{staff[0].FirstName}\n{staff[1].FirstName}\n{staff[2].FirstName}");

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
    staff = new(dbContext.Staff);
    Console.WriteLine("\nFIKALIS ARBEITEN\n");
}