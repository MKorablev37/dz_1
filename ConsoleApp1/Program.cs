
var funcs = new string[] { "/start", "/help", "/info", "/exit", "/echo" };
string userName = null;
var pattern = $"Вам доступны следующие команды {funcs[0]}, {funcs[1]}, {funcs[2]}, {funcs[3]}";

Console.WriteLine($"Здравствуйте! \n {pattern}");

string result = null;

while (result != funcs[3])
{
    result = Console.ReadLine().Trim();
    if (result.StartsWith("/echo") && userName != null)
    {
        Console.WriteLine($"{userName}: Hello");
        continue;
    }
    switch (result)
    {
        case "/start":
            if (userName ==null)
            {
                Console.WriteLine("Введите свое имя ");
                userName = Console.ReadLine();
            }
            Console.WriteLine($"{(string.IsNullOrWhiteSpace(userName) ? pattern : userName)}: {pattern}, {funcs[4]}");
            break;
        case "/help":
            Console.WriteLine($"{(string.IsNullOrWhiteSpace(userName) ? "Предоставляю информацию" : userName)}: Предоставляю информацию");
            break;
        case "/info":
            Console.WriteLine($"{(string.IsNullOrWhiteSpace(userName) ? "Версия 1.0.0.1 от 09/09/2026" : userName)}: Версия 1.0.0.1 от 09/09/2026");
            break;
        default:
            Console.WriteLine($"{userName}: Такой команды нет");
            break;

    }
}


