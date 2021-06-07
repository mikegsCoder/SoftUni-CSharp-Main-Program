using System;
using Logger.Interfaces;
using Logger.Layouts;
using Logger.Loggers;
using Logger.Models;


namespace Logger.Factory
{
   public static class LayoutCreator
    {
        public static ILayout Create(string type)
        {
            switch (type)
            {
                case "SimpleLayout":
                    return new SimpleLayout();
                case "XmlLayout":
                return new XmlLayout();
                case "JsonLayout":
                    return new JsonLayout();
                default:
                    throw new ArgumentException("Invalid Layout!");
            }
        }
    }
}
