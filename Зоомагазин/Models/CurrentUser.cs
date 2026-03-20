namespace Зоомагазин.Models
{
    /// <summary>
    /// текущий пользователь
    /// </summary>
    public static class CurrentUser
    {
        public static int Id { get; set; }
        public static string Username { get; set; }
        public static string Role { get; set; }
    }
}