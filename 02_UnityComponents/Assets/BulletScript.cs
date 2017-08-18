using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 5;

    private float collisionOffsetDistance = 1f;
    private ConfigurationScript configScript;
    
    void Start()
    {
        this.configScript = GameObject.FindObjectOfType<ConfigurationScript>();
    }
    
    void Update()
    {
        // Kill Enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(CustomTags.Enemy);

        for (int i = 0; i < enemies.Length; i++)
        {
            float distance = Vector3.Distance(enemies[i].transform.position, this.transform.position);
            if (distance < collisionOffsetDistance)
            {
                GameObject enemyToDestroy = enemies[i];
                enemies[i] = null;
                Destroy(enemyToDestroy);
                Destroy(this.gameObject);

                this.configScript.UpdateScore(this.configScript.scorePerKill);
                return;
            }
        }

        this.transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
