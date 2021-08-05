namespace BorderControl.Interfaces
{
    public interface ICitizen : IMember, IBuyer
    {
        public int Age { get; }
    }
}
