using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    public float takeDamangePeriodSeconds;

    private float currentTime = 0;
    private EnemyMovemnetScript movementScript;
    private ConfigurationScript configScript;
    private bool playerReached = false;

    void Start()
    {
        this.movementScript = this.gameObject.GetComponent<EnemyMovemnetScript>();
        this.configScript = GameObject.FindObjectOfType<ConfigurationScript>();
        this.movementScript.targetReached += MovementScript_targetReached;
    }

    void Update()
    {
        this.currentTime += Time.deltaTime;
        if (currentTime > takeDamangePeriodSeconds && this.playerReached)
        {
            this.configScript.UpdateScore(-this.configScript.damageTaken);
            this.currentTime = 0;
        }
    }

    private void MovementScript_targetReached(object sender, System.EventArgs e)
    {
        playerReached = true;
    }
}
