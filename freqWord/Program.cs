namespace freqWord
{
    public class Program
    {
        public static string? text ;
        public static void Main(string[] args)
        {
            Console.WriteLine("Загрузить текст для анализа? (y/n)");
            string yn = Console.ReadLine().Trim().ToLower();
            if (yn == "y")
            {
                Console.Write("Укажите путь к файлу:");
                string filename = Console.ReadLine();
                if (System.IO.File.Exists(filename) == false)
                {
                    Console.WriteLine("Вы ввели несуществующий путь к файлу. ");
                    Console.WriteLine("Введите текст для анализа: ");
                    text = Console.ReadLine().ToLower();
                    words();
                }
                else
                {
                    text = System.IO.File.ReadAllText(filename);
                    words();
                }
            }
            else if (yn == "n")
            {
                Console.WriteLine("Введите текст для анализа: ");
                text = Console.ReadLine().ToLower();
                words();
            }
            else
            {
                Console.WriteLine("Что-то вы не то ввели.");
            }
        }
            public static void words()
            { 
            string[] words = text.Split(new char[] { '-', '.', '?', '!', ')', '(', ',', ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length > 0) { Console.WriteLine("Общее количество слов :" + words.Length); }
            var result = words.GroupBy(x => x) // Группировка слов-элементов массива с помощью Языка Интегрированных Запросов
                .Select(x => new { Word = x.Key, Repeating = x.Count() }); // Представление результатов в виде перечисления анонимного типа.
            foreach (var item in result)
            {
                Console.WriteLine("Слово: {0}\tКоличество повторов: {1}", item.Word, item.Repeating);
            }
        }
        }
    }