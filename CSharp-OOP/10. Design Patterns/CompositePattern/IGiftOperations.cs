using System;
using System.Collections.Generic;
using System.Text;

namespace CompisitePattern
{
    public interface IGiftOperations
    {
        void Add(GiftBase giftBase);

        bool Remove(GiftBase giftBase);
    }
}
