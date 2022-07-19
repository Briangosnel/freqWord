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
                    StartGame();
                }
                else
                {
                    text = System.IO.File.ReadAllText(filename);
                    StartGame();
                }
            }
            else if (yn == "n")
            {
                Console.WriteLine("Введите текст для анализа: ");
                text = Console.ReadLine().ToLower();
                StartGame();
            }
            else
            {
                Console.WriteLine("Что-то вы не то ввели.");
                Console.WriteLine("Введите текст для анализа: ");
                text = Console.ReadLine().ToLower();
                StartGame();
            }
        }
            public static void StartGame()
        {
            Console.Clear();
            string[] words = GetStringList();
            if (words.Length > 0)
            {
                Console.WriteLine("Общее количество слов :" + words.Length);
            }
            CountWords(words);
            Console.ReadLine();
        }

        public static string[] GetStringList()
        {
            string[] words = text.Split(new char[] { '-', '.', '?', '!', ')', '(', ',', ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }

        public static void CountWords(string[] words)
        {
            var result = words.GroupBy(x => x).Select(x => new { Word = x.Key, Repeating = x.Count() });
            foreach (var item in result)
            {
                Console.WriteLine("Слово: {0}\tКоличество повторов: {1}", item.Word, item.Repeating);
            }
        }
    }
}
    