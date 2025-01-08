using Newtonsoft.Json;
using Serilog.Events;
using Serilog.Formatting;

namespace Application.Logging.Serilog.Layouts;

public class JsonLayout : ITextFormatter
{
    public void Format(LogEvent logEvent, TextWriter output)
    {
        if (logEvent == null)
            throw new ArgumentNullException(nameof(logEvent));
        if (output == null)
            throw new ArgumentNullException(nameof(output));

        SerializableLogEvent serializableLogEvent = new SerializableLogEvent(logEvent);
        string json = JsonConvert.SerializeObject(serializableLogEvent, Formatting.Indented);
        output.WriteLine(json);
    }
}