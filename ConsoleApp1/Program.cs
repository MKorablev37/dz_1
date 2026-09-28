
var funcs = new string[] { "/start", "/help", "/info", "/echo", "/addtask", "/showtasks", "/removetask", "/exit" };
string userName = null;
string result = null;
var myTasks = new List<string>();

Console.Write("Добро пожаловать! Доступны команды: ");
startProgramm();


while (result != funcs[3])
{
    result = Console.ReadLine().Trim();
    if (result.StartsWith("/echo") && userName != null)
    {
        Console.WriteLine($"{userName}: {result.Substring(6)}");
        continue;
    }
    switch (result)
    {
        case "/start":
            if (userName ==null)
            {
                Console.WriteLine("Пожалуйста, введите ваше имя: ");
                userName = Console.ReadLine();
            }
            Console.WriteLine($"Привет, {userName}! Чем могу помочь?");
            break;
        case "/help":
            Console.WriteLine(string.IsNullOrWhiteSpace(userName) ? "Предоставляю информацию" : $"{userName}: Предоставляю информацию");
            break;
        case "/info":
            Console.WriteLine(string.IsNullOrWhiteSpace(userName) ? "Версия 1.0.0.1 от 09/09/2026" : $"{userName}: Версия 1.0.0.1 от 09/09/2026");
            break;
        case "/exit":
            break;
        case "/addtask":
            addTaks();
            break;
        case "/showtasks":
            showtasks();
            break;
        case "/removetask":
            removetask();
            break;
        default:
            Console.WriteLine($"{userName}: Такой команды нет");
            break;

    }
}


void startProgramm()
{
    if (userName == null)
    {
        foreach (var item in funcs)
        {
            if (item == "/echo")
            {
                continue;
            }
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }
    if (userName != null)
    {
        foreach (var item in funcs)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }
}

void addTaks()
{
    Console.Write($"Пожалуйста, введите описание задачи: ");
    string task = Console.ReadLine();
    myTasks.Add(task);
    Console.WriteLine($"Задача \"{task}\" добавлена");
}

void showtasks()
{
    int index = 1;
    foreach (var item in myTasks){ 
        Console.WriteLine($"{index}. {item}");
        index++;
    }
}

void removetask()
{
    Console.WriteLine("Вот ваш список задач:");
    showtasks();
    Console.Write("Введите номер задачи для удаления: ");
    int index = int.Parse(Console.ReadLine()) - 1;
    Console.WriteLine($"Задача \"{myTasks[index]}\" удалена.");
    myTasks.RemoveAt(index);
}