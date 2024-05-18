using Coder;
using Product;

namespace window
{
    internal static class UpShowCase
    {
        public static void UpdateBarCode<T>(this T prod, IShowCase<T> showcase) where T : class, IProduct
        {
            int index = showcase.SerchName(prod.Name);
            prod.Bar = new RecordBarCode(prod.ID_Device.ToString() + " " + showcase.ID.ToString() + " " + index.ToString());
        }

    }
}
