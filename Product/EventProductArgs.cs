using Coder;

namespace Product
{
    public sealed class EventProductArgs: EventArgs
    {

        public IBarCode OldBarcode { get; init; }
        public IBarCode NewBarcode { get; init; }

        public EventProductArgs(IBarCode oldBarcode, IBarCode newBarcode)
        {
            OldBarcode = oldBarcode;
            NewBarcode = newBarcode;

            Console.WriteLine("ID был изменен");


        }


    }
}
