namespace Coder

{
    public interface IBarCode
    {
        string code_text { get; set; }
        string Bar { get;}
        string ToString();
    }
}
