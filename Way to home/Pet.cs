namespace Way_to_home
{
    public class Pet
    {
        public string Name { get; set; }
        public string Type { get; set; }       // Вид (Пёс, Кошка)
        public string Gender { get; set; }     // ПОЛ (Мальчик/Девочка)
        public string Age { get; set; }        // Возраст
        public string Size { get; set; }       // Размер
        public string ImagePath { get; set; }

        public string Tag1 { get; set; }
        public string Tag2 { get; set; }
        public string Tag3 { get; set; }

        public string History { get; set; }
        public string Character { get; set; }
        public string Requirements { get; set; }
    }
}