using System.Collections.Generic;
// Если Pet лежит в пространстве имен Way_to_home, эта строка не нужна.
// Если вы перенесли Pet в Models, раскомментируйте: using Way_to_home.Models;

namespace Way_to_home
{
    public static class PetData
    {
        // Здесь хранится список всех животных
        public static List<Pet> Pets { get; } = new List<Pet>
        {
            new Pet
            {
                Name = "Рикки",
                ImagePath = "rikki.jpg", // Убедитесь, что такой файл есть в Resources/Images
                Type = "Пёс",
                Gender = "Мальчик",
                Age = "2 года",
                Size = "Средний",
                Tag1 = "Спокойный",
                Tag2 = "Ласковый",
                Tag3 = "Ладит с детьми",
                History = "Рикки попал в приют после того, как его хозяева переехали в другую страну.",
                Character = "Очень спокойный и уравновешенный. Любит есть морковь и когда ему чешут за ушком.",
                Requirements = "Идеально подойдет для семьи с детьми."
            },
            new Pet
            {
                Name = "Рыжий",
                ImagePath = "rygiy.jpg", // Убедитесь, что такой файл есть в Resources/Images
                Type = "Кот",
                Gender = "Мальчик",
                Age = "4 года",
                Size = "Средний",
                Tag1 = "Ласковый",
                Tag2 = "Пугливый",
                Tag3 = "Ленивый",
                History = "Рыжий нашли на улице зимой. После лечения он превратилсь в пушистую красавца.",
                Character = "Ласковый и ненавязчивый. Любит сидеть на плече.",
                Requirements = "Тихий дом без других животных."
            },
            new Pet
            {
                Name = "Реджи",
                ImagePath = "redgu.jpg", // Убедитесь, что такой файл есть в Resources/Images
                Type = "Пёс",
                Gender = "Мальчик",
                Age = "3 года.",
                Size = "Крупный",
                Tag1 = "Спокойный",
                Tag2 = "Послушный",
                Tag3 = "Дружилюбный",
                History = "Реджи — щенок из трущеб.",
                Character = "Спокойный и послушный. Дружит с кошками",
                Requirements = "Активная семья, готовая уделять время дрессировке."
            }
        };
    }
}