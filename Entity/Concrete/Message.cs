namespace Entity.Concrete;

public class Message
{
    public Guid Id { get; set; }
    public string? Sender { get; set; }
    public string? Receiver { get; set; }
    public string? Subject { get; set; }
    public string? Content { get; set; }
    public DateTime Date { get; set; }
    public bool status { get; set; }
    

}