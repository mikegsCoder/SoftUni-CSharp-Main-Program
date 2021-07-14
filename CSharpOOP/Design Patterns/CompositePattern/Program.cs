using System;

namespace CompisitePattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SingleGift singleGift = new SingleGift("Test", 10);
            Console.WriteLine(singleGift.CalculateTotalPrice());

            Composite compositeGifts = new Composite("RootBox", 0);
            SingleGift singleGiftTwo = new SingleGift("qwerty", 50);
            SingleGift singleGiftThree = new SingleGift("asdfgh", 80);

            compositeGifts.Add(singleGiftTwo);
            compositeGifts.Add(singleGiftThree);

            Console.WriteLine(compositeGifts.CalculateTotalPrice());
        }
    }
}
