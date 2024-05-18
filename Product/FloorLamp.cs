using Coder;

namespace Product
{
    public sealed class FloorLamp : Lamp, IProduct
    {
        public float Hight { get; set; }

        public new IBarCode Bar { get; set; }

        public FloorLamp(int iD_Device, string name, float power, float wb, string color, float hight)
            : base(iD_Device, name, power, wb, color, new RecordBarCode((iD_Device).ToString()))
        {
            Hight = hight;
            Bar = new RecordBarCode((ID_Device).ToString());
        }

        
        protected override string Info => "\nМощность: " + power + "\nБаланс белого: " + wb + "\nЦвет: " + color + "\nВысота: " + Hight;

    }
}
