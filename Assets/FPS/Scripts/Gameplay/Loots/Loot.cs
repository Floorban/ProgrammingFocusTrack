using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu]
public class Loot : ScriptableObject
{
    public GameObject lootPrefab;
    public string lootName;
    public int dropChance;
    public Loot(string lootName, int dropChance)
    {
        this.lootName = lootName;
        this.dropChance = dropChance;
    }
}
