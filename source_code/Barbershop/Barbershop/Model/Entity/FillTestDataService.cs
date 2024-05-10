using Barbershop.Model.ViewModel;

namespace Barbershop.Model.Entity;

public class TestData
{
    public static void Fill(DatabaseContext db)
    {
        FillClientsAsync(db).Wait();
        FillServicesAsync(db).Wait();
        FillMastersAsync(db).Wait();
        FillMasterServices(db).Wait();
        FillShifts(db).Wait();
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
            ImageHref = "/static/images/Services/Cut/Bob.jpg",
            Description = "Боб — это классическая и универсальная стрижка, которая подходит для любого типа волос и формы лица. Она может быть выполнена различной длины и формы, от короткого, доходящего до подбородка боба до длинного, доходящего до плеч боба. Боб идеально подходит для тех, кто хочет добавить объем и текстуру своим волосам, а также скрыть недостатки лица и подчеркнуть скулы."
        });
        db.Services.Add(new Service()
        {
            Category = "Стрижка и укладка",
            PriceRubles = 699,
            Sex = "Мужской",
            Name = "Цезарь",
            ImageHref = "/static/images/Services/Cut/Cesar.jpg",
            Description = "Цезарь — это короткая мужская стрижка с ровной челкой и короткими, одинаковой длины волосами по бокам и сзади. Она идеально подходит для мужчин с прямыми или волнистыми волосами и квадратной или круглой формой лица. Стрижка Цезарь — это стильный и универсальный вариант, который легко укладывать и поддерживать."

        });
        db.Services.Add(new Service()
        {
            Category = "Стрижка и укладка",
            PriceRubles = 599,
            Sex = "Женский",
            Name = "Гарсон",
            ImageHref = "/static/images/Services/Cut/Garson.jpg",
            Description = "Гарсон — это короткая, женственная стрижка, которая добавляет образу дерзости и стиля. Она характеризуется короткими, филированными волосами, часто с челкой или асимметрией. Гарсон идеально подходит для тех, кто хочет добавить объем и текстуру тонким волосам, а также скрыть недостатки лица и подчеркнуть скулы."
        });
        db.Services.Add(new Service()
        {
            Category = "Стрижка и укладка",
            PriceRubles = 499,
            Sex = "Мужской",
            Name = "Полубокс",
            ImageHref = "/static/images/Services/Cut/Halfbox.jpg",
            Description= "Полубокс — это короткая, практичная и универсальная мужская стрижка, которая подходит для любого типа волос и формы лица. Она характеризуется короткими волосами на висках и затылке, переходящими в более длинные волосы на макушке. Полубокс — это стильный и неприхотливый вариант, который легко укладывать и поддерживать."
        });
        db.Services.Add(new Service()
        {
            Category = "Стрижка и укладка",
            PriceRubles = 599,
            Sex = "Женский",
            Name = "Шапочка",
            ImageHref = "/static/images/Services/Cut/Hat.jpg",
            Description= "Шапочка — это женственная и элегантная стрижка, которая подходит для любого типа волос и формы лица. Она характеризуется короткими, округлыми волосами, которые плавно обрамляют лицо, создавая эффект шапочки. Шапочка — это универсальный вариант, который легко укладывать и поддерживать, придавая образу утонченность и шарм."
        });
        db.Services.Add(new Service()
        {
            Category = "Стрижка и укладка",
            PriceRubles = 699,
            Sex = "Мужской",
            Name = "Маллет",
            ImageHref = "/static/images/Services/Cut/Garson.jpg",
            Description = "Маллет — это дерзкая и экстравагантная стрижка, которая характеризуется короткими волосами на макушке и длинными волосами на затылке. Маллет — это стильный и необычный вариант, который подходит для тех, кто хочет выделиться и подчеркнуть свой индивидуальный стиль. Она требует особого ухода и укладки, придавая образу неповторимость и притягательность."
        });
        db.Services.Add(new Service()
        {
            Category = "Стрижка и укладка",
            PriceRubles = 799,
            Sex = "Женский",
            Name = "Милитари",
            ImageHref = "/static/images/Services/Cut/Military.jpg",
            Description = "Милитари — это мужественная и практичная стрижка, которая характеризуется короткими волосами по всей голове. Милитари — это универсальный и неприхотливый вариант, который подходит для любого типа волос и формы лица. Она не требует сложной укладки и идеально подходит для тех, кто ценит удобство и аккуратный внешний вид."
        });
        db.Services.Add(new Service()
        {
            Category = "Стрижка и укладка",
            PriceRubles = 999,
            Sex = "Женский",
            Name = "Пикси",
            ImageHref = "/static/images/Services/Cut/Pixie.jpg",
            Description = "Пикси -  это дерзкая и стильная стрижка, которая характеризуется короткими волосами на висках и затылке, переходящими в более длинные волосы на макушке. Пикси — это женственный и многогранный вариант, который подходит для любого типа волос и формы лица. Она позволяет создавать различные укладки, от гладких и элегантных до текстурных и небрежных."
        });
        db.Services.Add(new Service()
        {
            Category = "Стрижка и укладка",
            PriceRubles = 899,
            Sex = "Женский",
            Name = "Короткое Каре",
            ImageHref = "/static/images/Services/Cut/ShortKare.jpg",
            Description = "Короткое Каре — это элегантная и стильная стрижка, которая характеризуется прямыми волосами, подстриженными до уровня подбородка или чуть выше. Короткое каре — это универсальный и практичный вариант, который подходит для любого типа волос и формы лица. Оно легко укладывается и позволяет создавать различные образы, от классических и сдержанных до современных и авангардных."
        });
        db.Services.Add(new Service()
        {
            Category = "Стрижка и укладка",
            PriceRubles = 1199,
            Sex = "Женский",
            Name = "Звезда",
            ImageHref = "/static/images/Services/Cut/Star.jpg",
            Description = "Звезда — это смелая и дерзкая стрижка, которая характеризуется выбритыми висками и затылком в форме звезды. Звезда — это авангардный и экстравагантный вариант, который подходит для тех, кто не боится выделяться из толпы. Она требует особого ухода и укладки, но придает образу неповторимый и притягательный вид."
        });
        db.Services.Add(new Service()
        {
            Category = "Стрижка и укладка",
            PriceRubles = 599,
            Sex = "Мужской",
            Name = "Теннис",
            ImageHref = "/static/images/Services/Cut/Tennis.jpg",
            Description = "Теннис — это спортивная и практичная стрижка, которая характеризуется короткими волосами по всей голове, подстриженными машинкой. Теннис — это универсальный и неприхотливый вариант, который подходит для любого типа волос и формы лица. Она не требует сложной укладки и идеально подходит для тех, кто ценит удобство и аккуратный внешний вид."
        });
        db.Services.Add(new Service()
        {
            Category = "Окрашивание",
            PriceRubles = 999,
            Sex = "Женский",
            Name = "Цветное",
            ImageHref = "/static/images/Services/Coloring/Coloring.jpg",
            Description = "Цветное окрашивание — это смелый и креативный способ выразить свой индивидуальный стиль. Оно предусматривает окрашивание волос в яркие, необычные цвета, такие как розовый, синий, зеленый и фиолетовый. Цветное окрашивание подходит для тех, кто хочет выделиться из толпы и подчеркнуть свою уникальность. Оно требует особого ухода и регулярного обновления, но позволяет создавать неповторимые и притягательные образы."
        });
        db.Services.Add(new Service()
        {
            Category = "Завивка",
            PriceRubles = 1499,
            Sex = "Женский",
            Name = "Химическая",
            ImageHref = "/static/images/Services/Hairdressing/Chemical.jpg",
            Description = "Химическая завивка — это способ придать волосам стойкие локоны или волны. Она подходит для тех, кто хочет добавить объем тонким волосам или создать роскошные кудри на прямых волосах. Химическая завивка позволяет создавать различные типы локонов, от мелких и упругих до крупных и волнистых. Она требует особого ухода и регулярной коррекции, но позволяет добиться желаемой прически на длительное время."
        });
        db.Services.Add(new Service()
        {
            Category = "Борода",
            PriceRubles = 299,
            Sex = "Мужской",
            Name = "Эспаньолка",
            ImageHref = "/static/images/Services/Beard/Espanol.jpg",
            Description = "Борода-эспаньолка — это разновидность бороды, при которой волосы растут на подбородке и соединяются с усами, образуя перевернутую букву “Т”. Она характеризуется аккуратными линиями и подходит для тех, кто хочет подчеркнуть волевые черты лица. Борода эспаньолка требует регулярного ухода и подравнивания, но придает образу мужественность, стиль и харизму."
        });
        db.Services.Add(new Service()
        {
            Category = "Борода",
            PriceRubles = 199,
            Sex = "Мужской",
            Name = "Короткая",
            ImageHref = "/static/images/Services/Beard/Short.jpg",
            Description = "Короткая борода — это аккуратный и опрятный вариант для тех, кто хочет подчеркнуть черты лица, не перегружая образ. Она отличается небольшой длиной и равномерной формой, которая легко поддерживается. Короткая борода универсальна и подходит для большинства типов лица, придавая им ухоженный и мужественный вид. Для поддержания формы требуется регулярное подравнивание и легкое расчесывание."
        });
        await db.SaveChangesAsync();
    } 
    static async Task FillMastersAsync(DatabaseContext db)
    {
        await db.AddUserMaster(new ()
        {
            Name = "Олег",
            Surname = "Васильев",
            Lastname = "Данилович",
            Skill = "Junior",
            Password = "12345678",
            Email = "oleg@barbershop.com",
            PhoneNumber = "1234567890",
        });
        await db.AddUserMaster(new()
        {
            Name = "Ольга",
            Surname = "Васильева",
            Lastname = "Даниловна",
            Skill = "Senior",
            Password = "12345678",
            Email = "olga@barbershop.com",
            PhoneNumber = "1234567890",
        });
    }
    static async Task FillMasterServices(DatabaseContext db)
    {
        var Services = db.Services.ToList();
        var Masters = db.Masters.ToList();
        foreach (var service in Services)
        {
            db.MasterServices.Add(new()
            {
                Master = Masters[1],
                Service = service
            });
        }
        foreach (var service in Services.Slice(0, 5))
        {
            db.MasterServices.Add(new()
            {
                Master = Masters[0],
                Service = service
            });
        }
        await db.SaveChangesAsync();
    }
    static async Task FillShifts(DatabaseContext db)
    {
        var Masters = db.Masters.ToList();
        db.Shifts.Add(new()
        {
            Master = Masters[0],
            Timestamp = DateTime.SpecifyKind(DateTime.Parse("2024-06-01").ToUniversalTime(), DateTimeKind.Utc),
        });
        db.Shifts.Add(new()
        {
            Master = Masters[0],
            Timestamp = DateTime.SpecifyKind(DateTime.Parse("2024-06-02").ToUniversalTime(), DateTimeKind.Utc),
        });
        db.Shifts.Add(new()
        {
            Master = Masters[1],
            Timestamp = DateTime.SpecifyKind(DateTime.Parse("2024-06-01").ToUniversalTime(), DateTimeKind.Utc),
        });
        db.Shifts.Add(new()
        {
            Master = Masters[1],
            Timestamp = DateTime.SpecifyKind(DateTime.Parse("2024-05-02").ToUniversalTime(), DateTimeKind.Utc),
        });
        db.SaveChanges();
    }
}
