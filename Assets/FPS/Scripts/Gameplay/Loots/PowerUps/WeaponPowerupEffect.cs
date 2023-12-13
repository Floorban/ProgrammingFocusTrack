using UnityEngine;
using Unity.FPS.Game;

public abstract class WeaponPowerupEffect : ScriptableObject
{
    public abstract void ApplyWeapon(GameObject weapon);

}
