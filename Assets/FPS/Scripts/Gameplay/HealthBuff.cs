using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/HealthBuff")]
public class HealthBuff : PowerUpEffect
{
    public float healAmount;

    public GameObject lootPrefab;
    public string lootName;
    public int dropChance;
    public override void Apply(GameObject player)
    {
        player.GetComponent<Health>().CurrentHealth += healAmount;
    }
    public HealthBuff (string lootName, int dropChance)
    {
        this.lootName = lootName;
        this.dropChance = dropChance;
    }
}
