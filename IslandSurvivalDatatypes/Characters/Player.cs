using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandSurvivalDatatypes.Characters
{
    public class Player : Character
    {
        public double Energy { get; set; }
        public double MaxEnergy { get; private set; }

        public Player()
        {
            Type = CharacterType.Player;
            Health = 45;
            MaxHealth = 100;
            Energy = 50;
            MaxEnergy = 100;
        }

        public void Tick()
        {
            if (Health + m_HealthRegenerationPerTick <= MaxHealth)
            {
                Health += m_HealthRegenerationPerTick;
            }

            if (Energy + m_EnergyRegenerationPerTick <= MaxEnergy)
            {
                Energy += m_EnergyRegenerationPerTick;
            }
        }

        private double m_HealthRegenerationPerTick = 0.4;
        private double m_EnergyRegenerationPerTick = 1;
    }
}
