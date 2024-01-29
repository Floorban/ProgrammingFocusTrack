using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeChoice : MonoBehaviour
{
    public float maxHp, speed, jumpHeight, reloadSpeed, reloadDuration, attackSpeed;
    [SerializeField]
    private float increasedMaxHp, increasedSpeed, increasedJumpHeight, increasedReloadSpeed, increasedReloadDuration, increasedAttackSpeed;
    public int ammoCapacity;
    [SerializeField]
    private int increasedAmmoCapacity;
    void IncreaseMaxHealth()
    {
        maxHp += increasedMaxHp;
    }
    void IncreaseSpeed()
    {
        speed += increasedSpeed;
    }
    void IncreaseJumpforce()
    {
        jumpHeight += increasedJumpHeight;
    }
    void IncreaseReloadSpeed()
    {
        reloadSpeed += increasedReloadSpeed;
    }
    void IncreaseReloadDuration()
    {
        reloadDuration += increasedReloadDuration;
    }
    void IncreaseAttackSpeed()
    {
        attackSpeed += increasedAttackSpeed;
    }
    void IncreaseAmmoCapacity()
    {
        ammoCapacity += increasedAmmoCapacity;
    }
}
