﻿using MyShop_MVC.DZ;

namespace MyShop_MVC;

public class DB_Seed
{
    public static void Seed(ApplicationContext Context)
    {
        if (Context.Categories.Any() || Context.Products.Any()) return;
        Category cat1 = new Category();
        cat1.Name = "Компьютеры";
        Product comp1 = new Product
        {
            Name = "Компьютер Artline Gaming X51 v07 (X51v07) + Мышь Asus TUF M3 USB (90MP01J0-B0UA00) в подарок!",
            Price = 30999,
            Description = "Персональные компьютеры серии Artline Gaming – это компьютеры для тех, кто любит и хочет отдыхать! Это тот инструмент, благодаря которому вы сможете полностью раскрыть свое мастерство в любимых играх.\r\n\r\nПри подборе комплектующих для игровой серии Gaming компания Artline в первую очередь ориентируется на возможности каждой детали компьютера, анализирует их производительность в составе готового устройства, и самое главное – умение четко и слаженно работать как одно целое, без сбоев. Совсем не в последнюю очередь уделяется внимание балансу цены/возможностей компонентов компьютера, что совершенно необходимо при текущей стоимости последних.\r\n\r\nБольшое разнообразие конфигураций модельного ряда Gaming X51 позволит выбрать вам подходящий вариант.\r\n\r\nМодель Artline Gaming X51v07 включает:\r\n\r\nЧип девятого поколения Intel Core i5-10400F семейства Comet Lake – шестиядерный кристалл среднего ценового сегмента, выполненный по 14-нм техническим нормам, который может похвастаться дополнительными 6 потоками обработки, базовой частотой 2.9 ГГц с разгоном (технология Turbo Boost) до 4.3 ГГц. Отличный выбор экономного геймера!\r\nВ современном ПК для игр самая дорогостоящая часть – это видеокарта. ARTLINE Gaming X51v07 оснащен новоиспеченным представителем среднего ценового диапазона, построенного на базе самой продвинутой архитектуры NVIDIA Turing – видеоакселератором Palit Nvidia GeForce GTX 1660 StormX 6GB GDDR5 (NE51660018J9-165F) с 6 ГБ собственной памяти. Данная графическая архитектура открывает возможности для нового поколения приложений, которые будут моделировать физический мир с небывалой скоростью. Особенно порадуются новинке пользователи стриминг-платформ Twitch и YouTube: встроенный в ядро аппаратный блок кодирования видео теперь на 15 % эффективнее, а также оптимизирован для Open Broadcaster Software (OBS). Благодаря производительности, превосходящей возможности предтопа прошлого поколения GTX 1070, новинка представляет собой невероятно мощную платформу для популярных игр, которая обеспечивает еще более высокую скорость в играх. Без преувеличения, nVidia GeForce GTX 1660 можно будет назвать самой «народной» видеокартой последних лет.\r\nОсновой в Gaming X51v07 выступает материнская плата Gigabyte H310M S2 на базе совершенно новой логики, которую так ждали многие экономные пользователи в 2018 году. Компания Gigabyte сегодня занимает лидирующие позиции на рынке материнских плат, её продукция прошла проверку временем и компьютерами тысяч пользователей.\r\n«Реактивная» по скорости доступа ОЗУ форм-фактора DDR4 обеспечит новый уровень комфорта работы за ПК.\r\nЖесткий диск объемом 1 ТБ и производительный SSD накопитель на 240 ГБ обеспечат хранение больших массивов информации и быстрый доступ к ним.\r\nЗа электропитание силовых цепей всей начинки модели Artline Gaming X51v07 отвечает блок мощностью 600 Вт\r\n\r\nВсе персональные компьютеры Artline проходят поэтапную сборку и проверку профессионалами. Аккуратный монтаж обеспечивает оптимальный воздушный поток внутри корпуса Qube Breeze и, как следствие, отличное охлаждение всех компонентов ПК. А длительный этап предпродажного тестирования сводит на нет возможные технические нюансы, влияющие на бесперебойную работу компьютера при его эксплуатации после покупки.",
            Image = "https://content2.rozetka.com.ua/goods/images/big/244859893.jpg",
            Category = cat1,
            Discount = 32
        };
        Product comp2 = new Product
        {
            Name = "Компьютер ASUS U500MA-R5300G0060 (90PF02F2-M008C0) AMD Ryzen 3 5300G/RAM 8 ГБ/SSD 256 ГБ/AMD Radeon Vega 6 Graphics/Wi-Fi/500W 80+ Bronze",
            Price = 13999,
            Description = "Asus U500MA – это стильный компьютер для всей семьи, который прекрасно подходит для развлекательных приложений и продуктивной творческой работы.",
            Image = "https://content1.rozetka.com.ua/goods/images/big/247918756.jpg",
            Category = cat1,
            Discount = 10
        };
        Product comp3 = new Product
        {
            Name = "Компьютер Asus ROG Strix G15CE-71170F0360 (90PF02P1-M002K0) Intel Core i7-11700F/RAM 16ГБ/SSD 1ТБ/GeForce RTX 3080 10ГБ/Wi-Fi",
            Price = 70999,
            Description = "ROG Strix G15 – это игровая станция, которая станет весомым преимуществом в киберспортивных состязаниях. Разработанная специально для того, чтобы обеспечить максимально плавную игровую картинку, она обладает мощной конфигурацией, включающей видеокарту NVIDIA GeForce RTX 3080 и процессор Intel Core i7-11700F.\r\nЕе конструкция отличается продуманным охлаждением и практичностью в деталях, таких как ручка для переноски и крючок для наушников, а ее внешний вид можно персонализировать по своему вкусу с помощью настраиваемой подсветки Aura с технологией синхронизации Aura Sync.",
            Image = "https://content.rozetka.com.ua/goods/images/big/241808332.jpg",
            Category = cat1
        };
        Context.Categories.Add(cat1);
        Context.Products.AddRange(comp1, comp2, comp3);
        Category cat2 = new Category();
        cat2.Name = "Ноутбуки";
        Product lap1 = new Product
        {
            Name = "Ноутбук Lenovo V14 G2 ITL (Intel i3-1115G4/8/128F/int/W10Pro) Black",
            Price = 16999,
            Description = "Lenovo V14 идеально сочетает в себе стиль, мощность и компактность. Работайте быстро и эффективно, расслабьтесь и наслаждайтесь яркими цветами на 14-дюймовом дисплее благодаря мощному центральному процессору Intel. Тонкий корпус и длительная работа от батареи позволяют всегда носить это устройство с собой, где бы вы ни были.",
            Image = "https://content.rozetka.com.ua/goods/images/big/274406559.jpg",
            Category = cat2,
            Discount = 47
        };
        Product lap2 = new Product
        {
            Name = "Ноутбук ASUS TUF Gaming F15 FX506HC-HN023 (90NR0723-M00HU0) Eclipse Gray / Intel Core i5-11400H / RAM 8 ГБ / SSD 512 ГБ / nVidia GeForce RTX 3050 + мышь ASUS TUF GAMING M5 V2",
            Price = 39999,
            Description = "Мощный арсенал для любых задач\r\nСовременная конфигурация делает TUF Gaming F15 универсальным устройством, которое готово обеспечить отличную скорость в широком спектре приложений, будь то игры, стриминг или что-то иное.",
            Image = "https://content2.rozetka.com.ua/goods/images/big/274267981.jpg",
            Category = cat2
        };
        Product lap3 = new Product
        {
            Name = "Ноутбук ASUS ZenBook 14 UX425EA-KI852 (90NB0SM1-M007M0) Pine Grey / Intel Core i3-1115G4 / RAM 8 ГБ / SSD 512 ГБ",
            Price = 27999,
            Description = "Путешествуйте налегке, путешествуйте с умом\r\nКомпактный, тонкий и сверхлегкий цельнометаллический корпус ZenBook 14 делает его идеальным спутником в путешествии. Кроме того, это самый тонкий в мире 14-дюймовый ноутбук с полным набором портов ввода-вывода, включая HDMI и USB Type-A, поэтому вы можете наслаждаться универсальными возможностями подключения, где бы вы ни находились.",
            Image = "https://content.rozetka.com.ua/goods/images/big/247180846.jpg",
            Category = cat2
        };
        Context.Categories.Add(cat1);
        Context.Products.AddRange(lap1, lap2, lap3);
        Category cat3 = new Category();
        cat3.Name = "Игровые приставки";
        Product pl1 = new Product
        {
            Name = "Игровая консоль Microsoft Xbox Series X (889842640809) + Игровой диск Mafia Definitive Edition",
            Price = 27999,
            Description = "Microsoft Xbox Series X — это огромный скачок вперёд! Самая быстрая и самая мощная консоль Xbox за всю историю.",
            Image = "https://content.rozetka.com.ua/goods/images/big/276682665.jpg",
            Category = cat3,
            Discount = 15
        };
        Product pl2 = new Product
        {
            Name = "Игровая консоль XoKo Hey Boy 2 Черно-красная (XOKO НB-2-BKRD)",
            Price = 769,
            Description = "hПредставляем новую версию портативной Ретро приставки XoKo Hey Boy 2 со встроенным эмулятором 8 и 16 битных игр для разных платформ.  Данный «гаджет» представляет собой небольшое устройство, совмещающее в себе 8/16 битную игровую приставку, геймпад и экран. ",
            Image = "https://content2.rozetka.com.ua/goods/images/big/215502340.jpg",
            Category = cat3,
            Discount = 56
        };
        Product pl3 = new Product
        {
            Name = "Sony PlayStation 5 White 825Gb + DualSense (White)",
            Price = 35809,
            Image = "https://content.rozetka.com.ua/goods/images/big/267652540.jpg",
            Category = cat3
        };
        Context.Categories.Add(cat1);
        Context.Products.AddRange(pl1, pl2, pl3);
        Context.SaveChanges();
    }
}