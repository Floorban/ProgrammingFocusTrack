using System.Collections.Generic;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;

namespace Unity.FPS.AI
{
    public class EnemyManager : MonoBehaviour
    {
        public List<EnemyController> Enemies { get; private set; }
        public int NumberOfEnemiesTotal { get; private set; }
        public int NumberOfEnemiesRemaining => Enemies.Count;

        [SerializeField] GameObject enemyPrefabs;
        [SerializeField] Vector3 spawnArea;
        [SerializeField] float spawnTimer;
        private float timer;
        public GameObject player;

        void Awake()
        {
            Enemies = new List<EnemyController>();
        }
        private void Update()
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                SpawnEnemy();
                timer = spawnTimer;
            }
        }
        void SpawnEnemy()
        {
            Vector3 position = new Vector3(Random.Range(-spawnArea.x, spawnArea.x), 0, Random.Range(-spawnArea.z, spawnArea.z));

            position += player.transform.position;

            GameObject newEnemy = Instantiate(enemyPrefabs);
            newEnemy.transform.position = position;
        }
        public void RegisterEnemy(EnemyController enemy)
        {
            Enemies.Add(enemy);

            NumberOfEnemiesTotal++;
        }

        public void UnregisterEnemy(EnemyController enemyKilled)
        {
            int enemiesRemainingNotification = NumberOfEnemiesRemaining - 1;

            EnemyKillEvent evt = Events.EnemyKillEvent;
            evt.Enemy = enemyKilled.gameObject;
            evt.RemainingEnemyCount = enemiesRemainingNotification;
            EventManager.Broadcast(evt);

            // removes the enemy from the list, so that we can keep track of how many are left on the map
            Enemies.Remove(enemyKilled);
        }
    }
}