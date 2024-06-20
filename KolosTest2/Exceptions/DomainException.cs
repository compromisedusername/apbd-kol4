namespace KolosTest2;

public class DomainException : Exception
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
}