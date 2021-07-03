using DIContainer.Attributes;
using SillyGame.IO;
using SillyGame.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SillyGame
{
    public class Engine
    {
        private IWriter writer;
        private IReader reader;

        [Inject]
        public Engine(IReader reader, [Named(typeof(MyConsoleWriter))]IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            while (true)
            {
                writer.Write("working");
            }
        }
    }
}
