namespace VGP133_Final_Assignment.Game
{
    public class Inventory
    {
        public void AddItem(Item item)
        {
            int index = _items.IndexOf(item);
            _items[index].Quantity++;
        }

        public void RemoveItem(Item item)
        {
            int index = _items.IndexOf(item);
            _items[index].Quantity--;
        }

        public void SortQuantity()
        {

        }

        public void SortName()
        {

        }

        public void SortType()
        {

        }
        private List<Item> _items = new List<Item>();
    }
}
