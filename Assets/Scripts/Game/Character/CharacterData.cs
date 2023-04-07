namespace TapTest
{
    public class CharacterData
    {
        public string Name { get; }
        public int CountCoins { get; }

        public CharacterData(string name, int countCoins)
        {
            Name = name;
            CountCoins = countCoins;
        }
    }
}