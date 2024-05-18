namespace Coder
{
    public class BarCode: IBarCode
    {

        private string text="";
        public string Bar { get; private set; }
        private readonly BarType.BarcodeType type=BarType.BarcodeType.Full;

        public BarCode(string text)
        {
            code_text = text;
        }
        public string code_text
        {   
           
            get => text;
            set
            {
                if (text == value) return;
                text = value;
                string code = Service.Text_to_Code(text);
                Bar = Service.Code_To_BarCode(code);
            }
        }
        public override string ToString() => Service.Generat_BarCode(Bar, text, BarType.BarcodeType.Full);
    }
}
