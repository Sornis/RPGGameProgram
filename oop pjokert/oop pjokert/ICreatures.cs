namespace Timer_and_Keyboard_MOO_ICT
{
    public abstract class Creatures
    {
        public string Name { get; set; } = "creature";
        public int health { get; set; } = 0;

        public Creatures(string race, int height, int width, int health, int damage)

        {
            Race = race;
            Height = height;
            Width = width;
            Health = health;
            Damage = damage;
        }
        string Race { get; set; }
        int Height { get; set; }
        int Width { get; set; }
        int Health { get; set; }
        int Damage { get; set; }
    }
}
