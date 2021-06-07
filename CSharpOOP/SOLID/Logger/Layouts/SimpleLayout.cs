using Logger.Interfaces;

namespace Logger.Models
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
