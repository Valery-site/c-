using Product;

namespace window
{
    public interface IShowCase <T> where T : class, IProduct
    {

        int ID { get; set; }
        T this[int index] { get; }

        void Add(T element);
        void Add(T element, int index);
        void Del();
        void Del(int index);
        T SerchIndex(int index);
        int SerchName(string name);
        int SerchId(int id);
        void SortId();
        void SortName();
        void Swap(int i1, int i2);
        void Show();


    }
}
