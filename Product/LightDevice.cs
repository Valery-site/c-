using Coder;

namespace Product
{
    public abstract class LightDevice: IProduct
    {
        private int _ID = 0;
        //private EventHandler<EventProductArgs> prdEv;
        public event EventHandler<EventProductArgs> PrdEv;

        //{ add { prdEv += value; }
        //  remove { prdEv -= value; }
        //}

        public string Name { get; set; }
        public IBarCode Bar { get; set; }

        protected LightDevice(int id, string name, IBarCode bar = null)
        {
            Bar =bar?? new BarCode(ID_Device.ToString());
            ID_Device = id;
            Name = name;
            //Bar.code_text = ID_Device.ToString();
        }

        public void NewBarCode()
        {
            Bar = new RecordBarCode(ID_Device.ToString());
        }

        public int ID_Device
        {

            get => _ID;
            set
            {
                if (_ID == value) return;
                _ID = value;
                IBarCode Bar_1 = new BarCode(_ID.ToString());
                Bar.code_text = (value.ToString());
                NewBarCode();
                PrdEv?.Invoke(this, new(Bar, Bar_1));
            }

        }
        protected abstract string Info { get; }

        public override string ToString() => Name + "\n" + Info + "\n" + Bar;

    }
}
