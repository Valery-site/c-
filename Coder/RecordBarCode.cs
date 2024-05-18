using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coder
{
    public record RecordBarCode: IBarCode
    {

        private string text = "";
        public string Bar { get; private set; }
        private BarType.BarcodeType type = BarType.BarcodeType.Full;


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
        public override string ToString() => Service.Generat_BarCode(Bar, "* " + text + " *", BarType.BarcodeType.Full);
        public RecordBarCode(string text)
        {
            code_text = text;
        }
    }

}
