using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coder
{
    internal class Service
    {

        /// <summary>
        ///  Высота штрихкода (в строках)
        /// </summary>
        private const int Height = 5;

        /// <summary>
        ///    Допустимые варианты штрихов
        /// </summary>
        public static readonly char[] Bars = { '█', '▌', '▐', ' ' };

        /// <summary>
        ///     Начальный паттерн для текстовой строки
        /// </summary>
        private const string StartText = "00000011010010000";

        /// <summary>
        ///     Начальный паттерн для числовой строки
        /// </summary>
        private const string StartNumbers = "00000011010011100";

        /// <summary>
        ///     Переключить в текстовый режим кодирования
        /// </summary>
        private const string SwitchToText = "10111101110";


        /// <summary>
        ///     Переключить в числовой режим кодирования
        /// </summary>
        private const string SwitchToNumbers = "10111011110";

        /// <summary>
        ///     Паттерн завершения
        /// </summary>
        private const string Stop = "1100011101011000000";

        /// <summary>
        ///     Доступные паттерны
        /// </summary>
        private static readonly string[] Patterns = {
        "11011001100", "11001101100", "11001100110", "10010011000", "10010001100",
        "10001001100", "10011001000", "10011000100", "10001100100", "11001001000",
        "11001000100", "11000100100", "10110011100", "10011011100", "10011001110",
        "10111001100", "10011101100", "10011100110", "11001110010", "11001011100",
        "11001001110", "11011100100", "11001110100", "11101101110", "11101001100",
        "11100101100", "11100100110", "11101100100", "11100110100", "11100110010",
        "11011011000", "11011000110", "11000110110", "10100011000", "10001011000",
        "10001000110", "10110001000", "10001101000", "10001100010", "11010001000",
        "11000101000", "11000100010", "10110111000", "10110001110", "10001101110",
        "10111011000", "10111000110", "10001110110", "11101110110", "11010001110",
        "11000101110", "11011101000", "11011100010", "11011101110", "11101011000",
        "11101000110", "11100010110", "11101101000", "11101100010", "11100011010",
        "11101111010", "11001000010", "11110001010", "10100110000", "10100001100",
        "10010110000", "10010000110", "10000101100", "10000100110", "10110010000",
        "10110000100", "10011010000", "10011000010", "10000110100", "10000110010",
        "11000010010", "11001010000", "11110111010", "11000010100", "10001111010",
        "10100111100", "10010111100", "10010011110", "10111100100", "10011110100",
        "10011110010", "11110100100", "11110010100", "11110010010", "11011011110",
        "11011110110", "11110110110", "10101111000", "10100011110", "10001011110",
        "10111101000", "10111100010", "11110101000", "11110100010", "10111011110",
        "10111101110", "11101011110", "11110101110", "11010000100", "11010010000",
        "11010011100", "11000111010", "11010111000", "1100011101011"};

        /// <summary>
        ///     Разрешенные символы
        /// </summary>
        private static readonly string[] TextSymbols = {
        " ","!","\"","#","$","%","&","'","(",")",
        "*","+",",","-",".","/","0","1","2","3",
        "4","5","6","7","8","9",":",";","<","=",
        ">","?","@","A","B","C","D","E","F","G",
        "H","I","J","K","L","M","N","O","P","Q",
        "R","S","T","U","V","W","X","Y","Z","[",
        "\\","]","^","_","`","a","b","c","d","e",
        "f","g","h","i","j","k","l","m","n","o",
        "p","q","r","s","t","u","v","w","x","y",
        "z","{","|","|","~"
    };

        /// <summary>
        ///     Разрешенные пары числовых строк
        /// </summary>
        private static readonly string[] NumberSymbols = {
        "00","01","02","03","04","05","06","07","08","09",
        "10","11","12","13","14","15","16","17","18","19",
        "20","21","22","23","24","25","26","27","28","29",
        "30","31","32","33","34","35","36","37","38","39",
        "40","41","42","43","44","45","46","47","48","49",
        "50","51","52","53","54","55","56","57","58","59",
        "60","61","62","63","64","65","66","67","68","69",
        "70","71","72","73","74","75","76","77","78","79",
        "80","81","82","83","84","85","86","87","88","89",
        "90","91","92","93","94","95","96","97","98","99"
    };

        private static readonly char[] numbers = {'0','1','2','3','4','5', '6','7','8','9'};

        public static string TextNumberCode(string[] text)
        {
            string s="";
            return s;
        }

        public static string TextCode(string[] text)
        {
            string code="";
            code += StartText;
            int price = text.Length;
            int key = 104;
            int index;
            
            for (int i = 0; i < text.Length; i++)
            {
                index=Array.IndexOf(TextSymbols, text[i]);
                if (index != -1)
                {
                    code += Patterns[index];
                    key += (i + 1) * (index);
                }
                
            }
            key = key % 103;
            code += Patterns[key];
            code += Stop;
            return code;
        }
        public static string NumberCode(string[] text)
        {
            string code = "";
            code += StartNumbers;
            int price = text.Length;
            int key = 105;
            int index;
            
            for (int i = 0; i < text.Length; i++)
            {
                index = Array.IndexOf(NumberSymbols, text[i]);
                if (index != -1)
                {
                    code += Patterns[index];
                    key += (i + 1) * (index);
                }
            }
            key = key % 103;
            code += Patterns[key];
            code += Stop;
            return code;
        }
        public static string Text_to_Code(string text)
        {   
            int index = 0;
            int col_number = 0;
            string[] _text = new string[text.Length];
            for (int i = 0; i < text.Length; i++)
            {

                if (numbers.Contains(text[i]))
                {
                    if (i+1< text.Length && numbers.Contains(text[i + 1]))
                    {
                        col_number++;
                    }
                    _text[index++] = text[i].ToString();
                }
                else _text[index++] = text[i].ToString();
            }


            string _Code ="";
            if (col_number == _text.Length / 2) _Code = NumberCode(_text);
            else _Code = TextCode(_text);

            return _Code;
        }
        public static char GetBar(string code) => Bars[Convert.ToInt32(code, 2)];
        public static string Code_To_BarCode(string code)
        {
            string BarCode = "";
            for (int i = 0; i < code.Length-1; i+=2)
            {
                string part = code[i].ToString() + code[i + 1].ToString();
                BarCode+=GetBar(part);
            }
            return BarCode;
        }

        public static string Generat_BarCode(string code,string text, BarType.BarcodeType type)
        {
            string s="";
            switch (type)
            {
                case BarType.BarcodeType.Text:
                    s += text;
                    break;
                case BarType.BarcodeType.Barcode:
                    for (int i = 0; i < code.Length; i++) s += '█';
                    s += "\n";
                    for (int i = 0; i < 5; i++) s = s + code + "\n";
                    for (int i = 0; i < code.Length; i++) s += '█';
                    break;
                case BarType.BarcodeType.Full:
                    for (int i = 0; i < code.Length; i++) s += '█';
                    s += "\n";
                    for (int i = 0; i < 5; i++) s = s + code + "\n";
                    for (int i = 0; i < code.Length; i++) s += '█';
                    s+="\n";
                    for (int i = 0; i < (code.Length-text.Length) / 2; i++) s += " ";
                    s += text;
                    break;


            }
            return s;
        }
    }
}
