
using System.Collections.Generic;

var funcs = new string[] { "/start", "/help", "/info", "/echo", "/addtask", "/showtasks", "/removetask", "/exit" };
string userName = null;
string result = null;
var myTasks = new List<string>();
const string helpMessage = "Вам доступны следующие команды: ";

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
            Console.WriteLine(string.IsNullOrWhiteSpace(userName) ? helpMessage : $"{userName}: {helpMessage}");
            startProgramm();
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
    if(myTasks.Count == 0)
    {
        Console.WriteLine($"{userName}: В списке нет задач.");
        return;
    }
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
    int index = int.Parse(Console.ReadLine());
    if (index <= 0 || index > myTasks.Count)
    {
        Console.WriteLine($"{userName}: Задачи с таким индексом нет.");
        removetask();
    }
    else
    {
        Console.WriteLine($"{userName}: Задача \"{myTasks[index - 1]}\" удалена.");
        myTasks.RemoveAt(index-1);
    }
        
}