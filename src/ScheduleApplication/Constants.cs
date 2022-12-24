namespace ScheduleApplication
{
    public static class Constants
    {
        public const string GROUPS_API_URL = @"https://umu.sibadi.org/api/raspGrouplist";
        public const string RASP_API_WITH_GROUP_ID_URL = @"https://umu.sibadi.org/api/Rasp?idGroup=";
        public const string RASP_API_DATE_PARAMETER = @"&sdate=";

        public const string NAME_OF_FILE_BASIC =  "Расписание группы";

        public const string ERROR_THERE_IS_NO_THAT_EVENTDATERULES = "Отсутствует реализация работы с правилом EventDateRules";
    }
}
