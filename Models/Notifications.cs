namespace Malshinon
{
    public class Notification
    {
        public int Id { get; set; }
        public int TargetId { get; set; }
        public string Reason { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;

    }

}