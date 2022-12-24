# Schedule-application
Application that parses data about lessons from university API and coverts it in Ical format for importing in calendars (for example Google Calendar)
## Console Example:
```csharp
static void Main(string[] args)
{
    //Shows all groups with their id and name in the current year
    //ShowAllGroups();

    //Creating Ical File using IcalScheduleService
    CreateIcalFile();
}

static void ShowAllGroups()
{
    //Getting all groups and show them in Console
    foreach (var group in ApiCommunicator.GetGroupListForCurrentYear())
    {
        Console.WriteLine($"Группа id:{group.Id} name:{group.Name}");
    }
}

static void CreateIcalFile()
{
    string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    string groupName = null;
    bool isCompleted = false;
    DateTime dateStart = DateTime.Now;
    DateTime dateEnd = DateTime.Now;
    LessonDateRules dataRules = default;

    IcalScheduleService scheduleService = new IcalScheduleService(new DefaultCreateService());

    Console.WriteLine("Введите название вашей группы (регистр не важен)");

    while (true)
    {
        groupName = Console.ReadLine();
        if (ApiCommunicator.GetGroupIfExist(groupName) != null)
            break;
        else
            Console.WriteLine("Неправильно введена группа, попробуйте ещё раз ввести название группы");
    }

    Console.WriteLine("Для текущей недели впишите 1");
    Console.WriteLine("Для следующей недели впишите 2");
    Console.WriteLine("Для выбора из диапазона дат впишите 3");

    while (!isCompleted)
    {
        switch (Console.ReadLine())
        {
            case "1":
                dataRules = LessonDateRules.ThisWeek;
                isCompleted = true;
                break;
            case "2":
                dataRules = LessonDateRules.NextWeek;
                isCompleted = true;
                break;
            case "3":
                dataRules = LessonDateRules.DateRange;
                isCompleted = true;
                Console.WriteLine("Введите дату начала формат: 13/01/2022 - день/месяц/год");
                DateTime.TryParse(Console.ReadLine(), out dateStart);
                Console.WriteLine("Введите дату конца  формат: 13/01/2022 - день/месяц/год");
                DateTime.TryParse(Console.ReadLine(), out dateEnd);
                dateEnd = dateEnd.AddDays(1);
                break;
            default:
                Console.WriteLine("Попробуйте заново!");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Для текущей недели впишите 1");
                Console.WriteLine("Для следующей недели впишите 2");
                Console.WriteLine("Для выбора из диапазона дат впишите 3");
                isCompleted = false;
                break;
        }
    }

    scheduleService.CreateIcalFile(path, groupName, dataRules, DateTime.Now, dateStart, dateEnd);

    Console.WriteLine($"Файл создан! Местоположение файла: {path}");
}
```
