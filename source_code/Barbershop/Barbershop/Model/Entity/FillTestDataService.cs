using Barbershop.Model.ViewModel;

namespace Barbershop.Model.Entity;

public class TestData
{
    public static void Fill(DatabaseContext db)
    {
        FillClientsAsync(db).Wait();
        FillServicesAsync(db).Wait();
        db.SaveChanges();
    }
    static async Task FillClientsAsync(DatabaseContext db)
    {
        List<RegisterViewModel> users = [
    new()
    {
        Name = "Иван",
        Surname = "Васильев",
        Lastname = "Петрович",
        Sex = "Мужской",
        Password = "12345678",
        Email = "test@example.com",
        PhoneNumber = "1234567890",

    },
    new()
    {
        Name = "Петр",
        Surname = "Иванов",
        Lastname = "Сидорович",
        Sex = "Мужской",
        Password = "12345678",
        Email = "test1@example.com",
        PhoneNumber = "1234567891"
    },
    new()
    {
        Name = "Ольга",
        Surname = "Петрова",
        Lastname = "Александровна",
        Sex = "Женский",
        Password = "12345678",
        Email = "test2@example.com",
        PhoneNumber = "1234567892"
    },
    new()
    {
        Name = "Алексей",
        Surname = "Смирнов",
        Lastname = "Васильевич",
        Sex = "Мужской",
        Password = "12345678",
        Email = "test3@example.com",
        PhoneNumber = "1234567893"
    },
    new()
    {
        Name = "Елена",
        Surname = "Попова",
        Lastname = "Николаевна",
        Sex = "Женский",
        Password = "12345678",
        Email = "test4@example.com",
        PhoneNumber = "1234567894"
    },
    new()
    {
        Name = "Андрей",
        Surname = "Козлов",
        Lastname = "Сергеевич",
        Sex = "Мужской",
        Password = "12345678",
        Email = "test5@example.com",
        PhoneNumber = "1234567895"
    },
    new()
    {
        Name = "Юлия",
        Surname = "Соколова",
        Lastname = "Ивановна",
        Sex = "Женский",
        Password = "12345678",
        Email = "test6@example.com",
        PhoneNumber = "1234567896"
    },
    new()
    {
        Name = "Дмитрий",
        Surname = "Кузнецов",
        Lastname = "Петрович",
        Sex = "Мужской",
        Password = "12345678",
        Email = "test7@example.com",
        PhoneNumber = "1234567897"
    },
    new()
    {
        Name = "Ирина",
        Surname = "Новикова",
        Lastname = "Александровна",
        Sex = "Женский",
        Password = "12345678",
        Email = "test8@example.com",
        PhoneNumber = "1234567898"
    },
    new()
    {
        Name = "Александр",
        Surname = "Морозов",
        Lastname = "Иванович",
        Sex = "Мужской",
        Password = "12345678",
        Email = "test9@example.com",
        PhoneNumber = "1234567899"
    }];
        foreach (var user in users)
        {
            await db.AddUserClient(user);
        }    
    }
    static async Task FillServicesAsync(DatabaseContext db)
    {
        db.Services.Add(new Service()
        {
            Category = "Стрижка и укладка",
            PriceRubles = 799,
            Sex = "Женский",
            Name = "Боб",
            ImageHref = "/static/images/Services/Cut/Bob.jpg"
        });
        db.Services.Add(new Service()
        {
            Category = "Стрижка и укладка",
            PriceRubles = 699,
            Sex = "Мужской",
            Name = "Цезарь",
            ImageHref = "/static/images/Services/Cut/Cesar.jpg"
        });
        db.Services.Add(new Service()
        {
            Category = "Стрижка и укладка",
            PriceRubles = 599,
            Sex = "Женский",
            Name = "Гарсон",
            ImageHref = "/static/images/Services/Cut/Garson.jpg"
        });
        db.Services.Add(new Service()
        {
            Category = "Стрижка и укладка",
            PriceRubles = 499,
            Sex = "Мужской",
            Name = "Полубокс",
            ImageHref = "/static/images/Services/Cut/Halfbox.jpg"
        });
        db.Services.Add(new Service()
        {
            Category = "Стрижка и укладка",
            PriceRubles = 599,
            Sex = "Женский",
            Name = "Шапочка",
            ImageHref = "/static/images/Services/Cut/Hat.jpg"
        });
        db.Services.Add(new Service()
        {
            Category = "Стрижка и укладка",
            PriceRubles = 699,
            Sex = "Мужской",
            Name = "Маллет",
            ImageHref = "/static/images/Services/Cut/Garson.jpg"
        });
        db.Services.Add(new Service()
        {
            Category = "Стрижка и укладка",
            PriceRubles = 799,
            Sex = "Женский",
            Name = "Милитари",
            ImageHref = "/static/images/Services/Cut/Military.jpg"
        });
        db.Services.Add(new Service()
        {
            Category = "Стрижка и укладка",
            PriceRubles = 999,
            Sex = "Женский",
            Name = "Пикси",
            ImageHref = "/static/images/Services/Cut/Pixie.jpg"
        });
        db.Services.Add(new Service()
        {
            Category = "Стрижка и укладка",
            PriceRubles = 899,
            Sex = "Женский",
            Name = "Короткое Каре",
            ImageHref = "/static/images/Services/Cut/ShortKare.jpg"
        });
        db.Services.Add(new Service()
        {
            Category = "Стрижка и укладка",
            PriceRubles = 1199,
            Sex = "Женский",
            Name = "Звезда",
            ImageHref = "/static/images/Services/Cut/Star.jpg"
        });
        db.Services.Add(new Service()
        {
            Category = "Стрижка и укладка",
            PriceRubles = 599,
            Sex = "Мужской",
            Name = "Теннис",
            ImageHref = "/static/images/Services/Cut/Tennis.jpg"
        });
        db.Services.Add(new Service()
        {
            Category = "Окрашивание",
            PriceRubles = 999,
            Sex = "Женский",
            Name = "Цветное",
            ImageHref = "/static/images/Services/Coloring/Coloring.jpg"
        });
        db.Services.Add(new Service()
        {
            Category = "Завивка",
            PriceRubles = 1499,
            Sex = "Женский",
            Name = "Химическая",
            ImageHref = "/static/images/Services/Hairdressing/Chemical.jpg"
        });
        db.Services.Add(new Service()
        {
            Category = "Борода",
            PriceRubles = 299,
            Sex = "Мужской",
            Name = "Эспаньолка",
            ImageHref = "/static/images/Services/Beard/Espanol.jpg"
        });
        db.Services.Add(new Service()
        {
            Category = "Борода",
            PriceRubles = 199,
            Sex = "Мужской",
            Name = "Короткая",
            ImageHref = "/static/images/Services/Beard/Short.jpg"
        });
        await db.SaveChangesAsync();
    } 
}
