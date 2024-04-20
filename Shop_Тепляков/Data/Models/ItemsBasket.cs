namespace Shop_Тепляков.Data.Models
{
    public class ItemsBasket : Items
    {
        public Items items;
        public int Count { get; set; }

        public ItemsBasket(int Count, Items item) : base(item)
        {
            this.Count = Count;
            items = item;
        }
    }
}
