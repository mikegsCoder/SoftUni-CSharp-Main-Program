namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        private int fireRate = 1;

        public Pistol(string name, int buletsCount) 
            : base(name, buletsCount)
        {
        }

        public override int Fire()
        {
            if (this.BulletsCount - this.fireRate >= 0)
            {
                this.BulletsCount -= this.fireRate;
                return this.fireRate;
            }

            return 0;
        }
    }
}
