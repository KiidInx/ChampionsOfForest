﻿using ChampionsOfForest.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheForest.Save;

namespace ChampionsOfForest.Player
{
    public class PlayerRespawnMod : PlayerRespawnMP
    {
        protected override void Respawn()
        {
            base.Respawn();
            try
            {
            ModdedPlayer.ResetAllStats();
                CustomBowBase.baseBow = null;
                CustomBowBase.baseBowC = null;
                GreatBow.instance = null;
            }
            catch (Exception e)
            {

                ModAPI.Log.Write(e.ToString());
            }

            ModReferences.rightHandTransform = null;

            ModdedPlayer.instance.ExpCurrent = 0;
            ModdedPlayer.instance.NewlyGainedExp = 0;
            ModdedPlayer.instance.MassacreKills = 0;
            ModdedPlayer.instance.MassacreMultipier = 1;
            ModdedPlayer.instance.TimeUntillMassacreReset = 0;
            ModdedPlayer.instance.InitializeHandHeld();
              BlackFlame.instance.Start();
        }



    }
}
