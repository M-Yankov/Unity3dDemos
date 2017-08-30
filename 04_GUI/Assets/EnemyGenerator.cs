using UnityEngine;
using UnityEngine.UI;

public class EnemyGenerator : MonoBehaviour
{
    public int enemyCount;
    public float distanceStartGenerator = 10f;
    public GameObject enemyTemplate;
    public GameObject respawnArea;
    public float enemyYPosition = 30;
    public int maxEnemiesAtOnce = 4;
    public Text missionText;

    private GameObject player;
    private bool generatorStarted = false;
    private int reswpanedEnemies = 0;

    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (!this.generatorStarted)
        {
            float distance = Vector3.Distance(this.transform.position, this.player.transform.position);
            if (distance <= this.distanceStartGenerator)
            {
                this.generatorStarted = true;
            }
        }
        else
        {
            int enemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (this.reswpanedEnemies >= this.enemyCount && enemiesCount == 0)
            {
                this.missionText.text = "Mission completed. Press [Esc] to exit.";
                return;
            }
            else
            {
                this.missionText.text = "Mission: Kill all enemies." + System.Environment.NewLine + "Remains:" + (this.enemyCount - this.reswpanedEnemies + enemiesCount).ToString();
            }

            bool isAlive = this.player.GetComponent<PlayerController>().IsAlive();
            if (!isAlive || enemiesCount >= this.maxEnemiesAtOnce || this.reswpanedEnemies >= this.enemyCount)
            {
                return;
            }

            const float wallOffset = 2f;
            float minx = this.respawnArea.transform.position.x - (this.respawnArea.transform.localScale.x / 2);
            float maxx = this.respawnArea.transform.position.x + (this.respawnArea.transform.localScale.x / 2);

            float minZ = this.respawnArea.transform.position.z - (this.respawnArea.transform.localScale.y / 2); // y is correct not Z
            float maxZ = this.respawnArea.transform.position.z + (this.respawnArea.transform.localScale.y / 2);

            float respawnX = Random.Range(minx + wallOffset, maxx - wallOffset);
            float respawnZ = Random.Range(minZ + wallOffset, maxZ - wallOffset);

            Vector3 position = new Vector3(respawnX, this.enemyYPosition, respawnZ);
            Instantiate(this.enemyTemplate, position, Quaternion.identity);
            this.reswpanedEnemies++;
        }
    }

    public int RemainingEnemies
    {
        get
        {
            return this.enemyCount;
        }
    }
}
