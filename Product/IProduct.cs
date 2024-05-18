using Coder;

namespace Product
{
    public interface IProduct
    {
        string Name { get; set; }
        IBarCode Bar { get; set; }

        int ID_Device { get; set; }

        void NewBarCode();

        event EventHandler<EventProductArgs> PrdEv;
        
    }
}
