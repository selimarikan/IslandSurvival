using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandSurvivalDatatypes.Characters
{
    public class Population : Entity
    {
        public uint Capacity { get; set; }
        public List<Character> Characters { get; set; }

        public Population()
        {
            Characters = new List<Character>((int)Capacity);
        }

        public uint GetCharacterCount<T>()
        {
            return (uint)Characters.Count(item => item is T);
        }

        public void RemoveCharacter<T>(int removeCount = 1)
        {
            var tCharacters = Characters.OfType<T>().ToList();
            if (tCharacters.Count() < removeCount)
            {
                return;
            }

            while (removeCount > 0)
            {
                Characters.Remove(tCharacters.ElementAt(0) as Character);
                removeCount--;
            }
        }

        public void AddCharacter<T>(int addCount = 1) where T : new()
        {
            if (!typeof(T).IsSubclassOf(typeof(Character)))
            {
                return;
            }

            for (var iCharacter = 0; iCharacter < addCount; iCharacter++)
            {
                Characters.Add((new T()) as Character);
            }
        }
    }
}
