using Product;



namespace window

{
  
    public class ShowСase<T> : IShowCase<T> where T : class, IProduct
    {
        private Action <IShowCase<T>> IdChanged;
        private readonly T[] vit;
        private int _id=0;
        
        
        public int ID
        {

            get => _id;
            set
            {
                if (_id == value) return;
                _id = value;
                //SetAllBarcode();
                IdChanged?.Invoke(this);
            }

        }
 


        private ShowСase(int size,int id)
        {
            vit = new T[size];
            ID = id;        

        }

        /// <summary>
        /// неявное преобразование типа
        /// </summary>
        public static implicit operator ShowСase<T>((int x, int y) z)
        {
            return new ShowСase<T>(z.x, z.y);
        }

        //Добавление элемента в первую пустую ячейку
        public void Add(T element)
        {
            int i;
            for (i = 0; i < vit.Length; i++)
            {
                if (vit[i] == null)
                {
                    Add(element, i);
                    break;
                }
            }
            if (i == vit.Length) { Console.WriteLine("Витрина полностью заполненна"); }
        }
        
        //Добавление элемента на определенное место
        public void Add(T element, int index)
        {
            this[index] = element;
        }

        //перегрузка оператора[]

        public T this[int index]
        {
            get
            {
                if (!(index < 0 || index >= vit.Length)) {
                    var v = vit[index];
                    vit[index] = null;
                    if (v != null) 
                    {
                        IdChanged -= v.UpdateBarCode; 
                        v.PrdEv -= NewBarCode_SW;
                    }
                return v; 
                }
                else return null;
                
            }
            set
            {
                if (!(index < 0 || index >= vit.Length))
                {
                    if (vit[index] == null) 
                    { 
                        vit[index] = value;
                        if (value != null) 
                        { 
                            IdChanged += value.UpdateBarCode; 
                            value.PrdEv += NewBarCode_SW; 
                        }
                        //SetBarcode(index); 
                    }
                    else { Console.WriteLine("Данная позиция уже занята"); }
                }
                else { Console.WriteLine("Такой позиции нет!"); }
            }
        }
        //удаление первого элемента
        public void Del()
        {
            for (int i = 0; i < vit.Length; i++)
            {
                if (vit[i] != null) { this[i]=null; break; }
            }
        }
        //удаление определенного элемента
        public void Del(int index)
        {
            var v=this[index];
        }

        //поиск по индефикатору
        public T SerchIndex(int index)
        {
            return vit[index];
        }

        //поиск по имени
        public int SerchName(string name)
        {
            
            for (int i=0; i < vit.Length; i++)
            {
                if (vit[i].Name == name) { return i;  }
            }
            return 0;
            
        }

        public int SerchId(int id)
        {

            for (int i = 0; i < vit.Length; i++)
            {
                if (vit[i].ID_Device == id) { return i; }
            }
            return 0;

        }

        //сортировка по id
        public void SortId()
        {
            List<T> temp = new();
            for (int i = 0; i < vit.Length; i++)
            {
                if (vit[i] != null)
                    temp.Add(this[i]);

            }
            foreach (var item in temp.OrderBy(x => x.ID_Device).ToList())
            {
                Add(item);
            }
        }

        //сортировка по имени
        public void SortName()
        {
            List<T> temp = new();
            for (int i = 0; i < vit.Length; i++)
            {
                if (vit[i] != null)
                    temp.Add(this[i]);

            }
            foreach (var item in temp.OrderBy(x => x.Name).ToList())
            {
                Add(item);
            }
        }

        //поменять места
        public void Swap(int i1,int i2)
        {
            var v = this[i1];
            this[i1] = this[i2];
            this[i2] = v;
        }

        //заменить товар по id

        public void NewProduct(T element, int id) 
        {
            for (int i = 0; i < vit.Length; i++)
            {
                if (vit[i].ID_Device == id) { this[i] = element; break; }
            }
        }

        //заменить товар по имени

        public void NewProduct(T element, string name)
        {
            for (int i = 0; i < vit.Length; i++)
            {
                if (vit[i].Name == name) { this[i] = element; break; }
            }
        }

        //перестановка товара по позициям
        public void Perestanovka(int index1, int index2)
        {
            Add(this[index1],index2);
        }


        private void SetBarcode(int index)
        {
            if (vit[index] == null)
                return;
            vit[index].Bar.code_text = $"{vit[index].ID_Device} {ID} {index}";

        }
        private void SetAllBarcode()
        {
            for (int i = 0; i < vit.Length; i++)
            {
                SetBarcode(i);
            }
        }

        private void NewBarCode_SW(object? sender, Product.EventProductArgs e)
        {
            if (sender is T good)
            {
                good.NewBarCode();
            }
        }

        //вывод содержимого витрины
        public void Show()
        {
            Console.WriteLine("Витрина: ");
            for (int i = 0; i < vit.Length; i++)
            {
                var v = vit[i];
                if (v != null)
                {
                    Console.WriteLine(v);
                }
                vit[i] = v;
            }
        }


    }
}
