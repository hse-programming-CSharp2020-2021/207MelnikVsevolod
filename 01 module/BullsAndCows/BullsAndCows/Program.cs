using System;


//Игра "Быки и коровы"
//Правила описаны в методе Rules
//Запускать метод Main
namespace BullsAndCows
{
    class Program
    {
        static void Greet()
        {
            Console.WriteLine("         --- Быки и коровы ---        ");
            Console.WriteLine("                                      ");
            Console.WriteLine("                   (     Привет!    ) ");
            Console.WriteLine("           ^___^   ( Я хочу сыграть ) ");
            Console.WriteLine("   _______ (o o)   (   с тобой в    ) ");
            Console.WriteLine(" /(       )(-_-)  <(   одну игру.   ) ");
            Console.WriteLine("   ||---||                            ");
            Console.WriteLine("   ||   ||                            ");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("         Нажмите любую клавишу        ");
            Console.ReadKey();
        }

        static void Win()
        {
            Console.WriteLine("                                      ");
            Console.WriteLine("                      ( Вы победили! )");
            Console.WriteLine("              ^___^   |/              ");
            Console.WriteLine("      _______ (o o)                   ");
            Console.WriteLine("    /(       )(-_-)                   ");
            Console.WriteLine("      ||---||                         ");
            Console.WriteLine("      ||   ||                         ");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("         Нажмите любую клавишу        ");
            Console.ReadKey();
        }

        static void Goodbye()
        {
            Console.WriteLine("                                      ");
            Console.WriteLine("   ( Пока! )                          ");
            Console.WriteLine("          \\|  ^___^                   ");
            Console.WriteLine("              (o o) _______           ");
            Console.WriteLine("              (-_-)(       )\\         ");
            Console.WriteLine("                    ||---||           ");
            Console.WriteLine("                    ||   ||           ");
            Console.WriteLine("--------------------------------------");
        }

        static void Rules()
        {
            Console.WriteLine("Правила:");
            Console.WriteLine("Задумывается n-значное число с неповторяющимися цифрами");
            Console.WriteLine("Игрок вводит число и игра выводит сообщение о том, сколько цифр (коров) угадано, но не на своих местах, и сколько цифр (быков) угадано и они стоят на своих местах");
            Console.WriteLine("Игра заканчивается, когда игрок угадывает число полностью");
            Console.WriteLine("Чтобы выйти, наберите exit");
            Console.WriteLine("Рекомендуется открыть окно пошире, чтобы корова влезала в экран");
            Console.WriteLine("         Нажмите любую клавишу        ");
            Console.ReadKey();
        }

        static void NewGame()
        {
            Console.WriteLine("");
            Console.WriteLine("                  Новая игра                 ");
            Console.Write("Введите количество цифр в числе (от 1 до 10): ");
        }

        //Перевод строки в число с проверкой на то, хочет ли пользователь выйти
        //Возвращает false если строка не число
        static bool StringToInt(string str, out int n, ref bool wantToExit)
        {
            n = 0;
            if (str == "exit")
                wantToExit = true;
            if (!int.TryParse(str, out n))
                return false;
            else
                return true;
        }

        //Генерация числа с digits цифрами
        static string Generate(int digits)
        {
            //Генератор случайных чисел
            Random rand = new Random();
            //Генерируемое число
            string number = "";
            //Использованные цифры
            bool[] used = new bool[10];
            //Инициализация
            for (int i = 0; i < 10; ++i)
                used[i] = false;

            for (int i = 0; i < digits; ++i)
            {
                int next_digit = rand.Next(0, 10);
                while (used[next_digit])
                    next_digit = rand.Next(0, 10);
                used[next_digit] = true;
                number += (char)(next_digit + '0');
            }

            return number;
        }

        //Проверка корректности введённого числа
        static bool ValidateNumber(string playerNumber, int digits)
        {
            //Не та длина
            if (playerNumber.Length != digits)
                return false;

            //Каждый символ - цифра
            bool everyCharIsDigit = true;

            for (int i = 0; i < digits; ++i)
                if (playerNumber[i] < '0' || playerNumber[i] > '9')
                    everyCharIsDigit = false;

            if (!everyCharIsDigit)
                return false;
            return true;
        }

        //Угадывание числа
        //Возвращает true если число угадано или игрок захотел выйти
        static bool Guess(string number, int digits, ref bool wantToExit)
        {
            //Число, которое вводит игрок
            string playerNumber = "";
            while (!ValidateNumber(playerNumber, digits))
            {
                Console.Write("Введите число с " + digits.ToString() + " цифрами: ");
                playerNumber = Console.ReadLine();
                if (playerNumber == "exit")
                {
                    //Игрок решил уйти
                    wantToExit = true;
                    return true;
                }
            }

            //Использованные в number цифры
            bool[] used = new bool[10];
            int bulls = 0;
            int cows = 0;
            for (int i = 0; i < digits; ++i)
                used[number[i] - '0'] = true;

            //Подсчёт коров (цифры не на своих местах)
            for (int i = 0; i < digits; ++i)
                if (used[playerNumber[i] - '0'] && number[i] != playerNumber[i])
                    ++cows;

            //Подсчёт быков (цифры на своих местах)
            for (int i = 0; i < digits; ++i)
                if (number[i] == playerNumber[i])
                    ++bulls;

            Console.WriteLine("Коров: " + cows.ToString());
            Console.WriteLine("Быков: " + bulls.ToString());
            return (bulls == digits);
        }

        static void Main(string[] args)
        {
            Greet();
            Rules();
            bool wantToExit = false;
            //Флаг равен true, если игрок хочет выйти

            while (!wantToExit)
            {
                //Очистка консоли
                Console.Clear();
                //Начало новой игры
                //Количество цифр в числе
                int digits = 0;
                NewGame();

                //Ввод количества цифр в числа
                while ((!StringToInt(Console.ReadLine(), out digits, ref wantToExit) || digits < 1 || digits > 9) && !wantToExit)
                    Console.Write("Введите число от 1 до 10: ");
                if (wantToExit)
                    break;

                //Генерация числа
                string number = Generate(digits);

                //Количество попыток
                int cnt = 0;

                //Угадывание числа и подсчёт попыток
                while (!Guess(number, digits, ref wantToExit))
                    ++cnt;

                Console.Clear();
                if (!wantToExit)
                {
                    Console.WriteLine("Количество попыток: " + cnt.ToString());
                    Win();
                }
            }
            Console.Clear();
            Goodbye();
        }
    }
}
