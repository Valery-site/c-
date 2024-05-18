using Coder;

namespace Product
{
    public class Lamp : LightDevice
    {
        public float power { get; set; }
        public float wb { get; set; }
        public string color { get; set; }

        public Lamp(int iD_Device, string name, float power, float wb, string color, IBarCode bar = null)
            : base(iD_Device,name, bar)
        {
            this.power = power;
            this.wb = wb;
            this.color = color;

        }

        protected override string Info => "\nМощность: "+power+"\nБаланс белого: "+wb+"\nЦвет: "+color ;
    }
}
