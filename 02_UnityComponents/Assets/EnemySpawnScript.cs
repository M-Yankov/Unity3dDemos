using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public int maxEnemiesCount = 4; 
    public GameObject enemy;
    public float playerOffsetX = 50;
    public float respawnAfterSeconds = 3;

    private float currentTime = 0;
    private GameObject player;
    private GameObject respawnPosition;
    private float playerOffsetPostion = 10;
    private float hight = 1.5f;

    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag(CustomTags.Player);
        this.respawnPosition = GameObject.FindGameObjectWithTag(CustomTags.EnemySpawnPosition);
    }

    void Update()
    {
        this.currentTime += Time.deltaTime;
        ICollection<GameObject> enemies = GameObject.FindGameObjectsWithTag(CustomTags.Enemy);
        if (this.currentTime > respawnAfterSeconds && enemies.Count < maxEnemiesCount)
        {
            float x = Random.Range(this.player.transform.position.x - playerOffsetPostion, this.player.transform.position.x + playerOffsetPostion);
            Vector3 newPosition = new Vector3(x, hight, this.respawnPosition.transform.position.z);
            Instantiate(this.enemy, newPosition, this.respawnPosition.transform.rotation);
            this.currentTime = 0;
        }
    }
}
