using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace IslandSurvivalGUI
{
    public enum SoundEffects
    {
        Build,
        ChopWood,
        FireCrack,
        StoneCollect
    }

    public static class SoundController
    {
        public static void PlayEffect(SoundEffects effectType)
        {
            string sfxPath = string.Empty;

            switch (effectType)
            {
                case SoundEffects.Build:
                    sfxPath = "Resources/Audio/Effects/buildingHammer.wav"; break;
                case SoundEffects.ChopWood:
                    sfxPath = "Resources/Audio/Effects/woodChop.wav"; break;
                case SoundEffects.FireCrack:
                    sfxPath = "Resources/Audio/Effects/fireCrackle.wav"; break;
                case SoundEffects.StoneCollect:
                    sfxPath = "Resources/Audio/Effects/stoneCollect.wav"; break;
                default:
                    break;
            }

            if (string.IsNullOrEmpty(sfxPath))
            {
                return;
            }

            var soundPlayer = new SoundPlayer(sfxPath);
            soundPlayer.Play();
        }
    }

}
