using System;
using System.Reflection.Emit;

class Program
{
    // кол-во денег, лимит вопросов
    static int money = 0;
    static int limit = 8;
    // Капец
    static void MakeQuestion(string question, string answer1, string correctAnswer, int additionScore)
    {
       Start:

        Console.Write($" Вопрос на {additionScore} рублей.\n ");
        Console.Write(question);
        Console.Write(answer1);
        string answer = Console.ReadLine();

        if (answer == correctAnswer)
        {
            money += additionScore;
            Console.WriteLine($"Вы выйграли {money} рублей. Следующий вопрос.");
            Thread.Sleep(2500);
            Console.Clear();
        }
        else if (answer == "Звонок другу")
        {
            Console.Write(" Вы выбрали подсказку звонок другу.\n");
            Random rand = new Random();
            int random1 = rand.Next(1, 4);
            Console.Write(" Друг выбрал ответ:" + random1 + "\n");
            goto Start;
        }
        else if (answer == "Вопрос аудитории")
        {
            Console.Write(" Вы выбрали задать вопрос аудитории.\n");
            Random rand = new Random();
            int random1 = rand.Next(1, 4);
            Console.Write(" Аудитория выбрала ответ:" + random1 + "\n");
            goto Start;
        }
        else if (Convert.ToInt32(additionScore) >= limit)
        {
            Console.WriteLine("Поздравляю вас!!!\nВы выйграли денежный приз, он составляет:" + additionScore);
            Thread.Sleep(2500);
        }
        else
        {
            Console.Write($"Вы проиграли. Ваш счёт: {money}\n Давайте начнем сначала :3");
            Thread.Sleep(2500);
            Environment.Exit(-1);
        }
    }

    static class Game
    {
        static void Main(string[] args)
        {
        // Вопросы, Ответы, Правильные ответы, $$$.
        string[] question = {
        "Как зовут Гейтса?\n\t",
        "Назовите число, символизирующее «День программиста»\n",
        "Назовите язык программирования, созвучный музыкальной ноте.\n",
        "Родитель, который находится в компьютере, это?\n",
        "Первая фраза программиста?\n",
        "Любимая плюшевая игрушка программиста?\n",
        "Переменная – это?\n",
        "Грызун, который помогает нам работать с компьютером\n"
        };

        string[] fullanswer = { // " 1. \n 2. \n 3. \n 4. \n
        " 1. Гейтс\n 2. Билл\n 3. Артемий\n 4. Геннадий\n или напишите подсказку\n Ответ:",
        " 1. 128\n 2. 256\n 3. 64\n 4. 365\n или напишите подсказку\n Ответ:",
        " 1. Ми\n 2. Ре \n 3. До \n 4. Си\n или напишите подсказку\n Ответ:",
        " 1. Мать\n 2. Батя\n 3. Бабушка\n 4. Дед\n или напишите подсказку\n Ответ:",
        " 1. Я мобилизирован!\n 2. Привет мир!\n 3. Привет программистам\n 4. Программирование!\n или напишите подсказку\n Ответ:",
        " 1. Кот\n 2. Мишка\n 3. Пингвин\n 4. Потребитель\n или напишите подсказку\n Ответ:",
        " 1. Место в оперативной памяти\n 2. Обозначение чего-либо\n 3. Обьект\n 4. Обозначение обьекта\n или напишите подсказку\n Ответ:",
        " 1. Хомяк\n 2. Шиншилла \n 3. Крыса\n 4. Мышь\n или напишите подсказку\n Ответ:",
        };

        string[] trueanswer = {
        "1", "2", "4", "1", "2", "3", "1", "4"
        };

        int[] cash = {
        100, 200, 300, 500, 1000, 2000, 4000, 8000, 16000, 32000, 64000, 125000, 250000, 500000, 10000000
        };
            // Код игры
            Start1:
                Console.Clear();
                Console.WriteLine("Добро пожаловать в игру 'Кто хочет стать миллионером' на C#!");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("Выбирите пункт: \n\t1 - Начать игру\n\t2 - Правила\n\t3 - Выйти");
                int startChoice = int.Parse(Console.ReadLine());

                if (startChoice == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Тогда приступим");
                    Thread.Sleep(2000);
                    Console.Clear();
                    for (int i = 1; i < question.Count() && i < fullanswer.Count() && i < trueanswer.Count() && i < cash.Count(); i++)
                    {
                        MakeQuestion(question[i], fullanswer[i], trueanswer[i], cash[i]);
                    }
                Console.WriteLine("Поздравляю вас!!!\nВы выйграли денежный приз.");
                Console.WriteLine("Нажмите ENTER для продолжения...");
                string me = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(me)) Environment.Exit(-1);
                ;

            }
                else if (startChoice == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Кто хочет стать миллионером? - это викторина, в которой нужно выбрать правильный вариант ответа для получение денежного выйгрыша.\nС каждым правильным ответом, сумма выйгрыша повышается.\nУ вас есть в доступе подсказки:\n1. Звонок другу\n2. Вопрос аудитории\nДля того, чтобы воспользоваться подсказкой нужно ввести ее название вместо ответа на вопрос название подсказки\nНапример:\nВопрос на 100 рублей\nКак вас зовут?\n1. Артём\n2. Тумбочка\n3. Артемий\n4. Георгий\n Вы пишите: 'Звонок другу'");
                    Console.WriteLine("Нажмите ENTER для продолжения...");
                    string me = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(me)) goto Start1;
            }
                else if (startChoice == 3)
                {
                    Environment.Exit(-1);
                }
            }

            }
    } // Чтоб эту игру...