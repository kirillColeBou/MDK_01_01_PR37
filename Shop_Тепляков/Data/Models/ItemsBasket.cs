namespace Shop_Тепляков.Data.Models
{
    public class ItemsBasket : Items
    {
        public int count { get; set; }

        public ItemsBasket(int Count, Items item) : base(item)
        {
            count = Count;
        }
    }
}
