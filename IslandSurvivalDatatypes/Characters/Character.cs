namespace IslandSurvivalDatatypes.Characters
{
    public enum CharacterType
    {
        Player,
        Ally,
        Enemy,
        Neutral
    }
    public class Character : Entity
    {
        public CharacterType Type { get; set; }
        public double Health { get; set; }
        public double MaxHealth { get; protected set; }
    }
}
