using NetCoreDI.IO;
using NetCoreDI.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreDI
{
    public class Engine
    {
        private IWriter writer;
        private IReader reader;

        public Engine(IReader reader, IWriter writer)
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
