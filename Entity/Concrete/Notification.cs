namespace Entity.Concrete;

public class Notification
{
    public Guid Id { get; set; }
    public string Details { get; set; }
    public string Type { get; set; }
    public string Symbol { get; set; }
    public string Color { get; set; }
    public DateTime Date { get; set; }
    public bool Status { get; set; }
}