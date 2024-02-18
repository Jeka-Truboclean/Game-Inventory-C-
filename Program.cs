using System.Net;

namespace Game_Inventory
{
    class Program
    {
        static void Main()
        {
            Player player = new Player();
            player.AddItem(new Item
            {
                Name = "Sword",
                Lvl = 3,
                Value = 50,
                Weight = 160.5f
            });

            player.AddItem(new Item
            {
                Name = "Poison",
                Lvl = 4,
                Value = 15,
                Weight = 50.9f
            });

            player.AddItem(new Item
            {
                Name = "Halmet",
                Lvl = 6,
                Value = 75,
                Weight = 450.9f
            });

            foreach (Item item in player.Inventory)
            {
                Console.WriteLine(item.Info());
            }

            player.RemoveItem(0);

            Console.WriteLine(new string('-', 50));

            foreach (Item item in player.Inventory)
            {
                Console.WriteLine(item.Info());
            }

            Console.WriteLine(player.TotalWeight);
            Console.WriteLine(player.TotalPrice);
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public int Lvl { get; set; }
        public decimal Value { get; set; }
        public float Weight { get; set; }

        public string Info()
        {
            return $"Name: {Name} | Lvl: {Lvl} | Value: {Value} | Weight: {Weight}";
        }
    }
    public class Player
    {
        public string Name { get; set; }
        private Item[] inventory;
        public Item[] Inventory { get { return inventory; } private set { inventory = value; } }
        public Player() { inventory = new Item[0]; }

        public void AddItem(Item item)
        {
            Item[] items = new Item[inventory.Length + 1];
            for (int i = 0; i < inventory.Length; i++) { items[i] = inventory[i]; }
            items[items.Length - 1] = item;
            inventory = items;
        }
        public void RemoveItem(int index) 
        {
            Item[] items = new Item[inventory.Length - 1];
            for (int i = 0, j = 0;i < inventory.Length;i++) { if (i == index) { continue; } items[j++] = inventory[i]; }
            inventory = items;
        }
        public float TotalWeight
        {
            get
            {
                float totalWeight = 0f;
                for (int i = 0; i < inventory.Length; i++) { totalWeight += inventory[i].Weight; } return totalWeight;
            }
        }
        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                for (int i = 0; i < inventory.Length; i++) { totalPrice += inventory[i].Value; }
                return totalPrice;
            }
        }
    }
}
