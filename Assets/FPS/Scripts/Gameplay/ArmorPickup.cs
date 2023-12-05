using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.FPS.Gameplay;

namespace Assets.FPS.Scripts.Gameplay
{
  public  class ArmorPickup : Pickup
  {
    protected override void OnPicked(PlayerCharacterController playerController)
    {
      base.OnPicked(playerController);

      // Do things with Armor here.
    }
  }
}
