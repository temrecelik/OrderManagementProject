using Serilog.Events;

namespace Application.Logging.Serilog
{
    [Serializable]
    public class SerializableLogEvent
    {
        private readonly LogEvent _logEvent;

        public SerializableLogEvent(LogEvent logEvent)
        {
            _logEvent = logEvent ?? throw new ArgumentNullException(nameof(logEvent));
        }

        public object Message => _logEvent.RenderMessage();
        public LogEventLevel Level => _logEvent.Level;
        public DateTimeOffset Timestamp => _logEvent.Timestamp;
        public string? Exception => _logEvent.Exception?.ToString();
    }
}