namespace Application.Logging;

public class LogDetail
{
    public string? Date { get; set; }
    public string? MethodName { get; set; }
    public List<LogParameter>? LogParameters { get; set; }
}