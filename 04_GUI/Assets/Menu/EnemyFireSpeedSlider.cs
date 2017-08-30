using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyFireSpeedSlider : MonoBehaviour
{
    public Text enemyAimLabel;
    public GameObject enemyTemplate;
    public Slider theSlider;

    private const string TextFormat = "Enemy fire speed: {0:F2}";

    void Start()
    {
        this.theSlider.minValue = 0;
        this.theSlider.maxValue = 5;

        float fireSpeed = this.enemyTemplate.GetComponentInChildren<EnemyfireScript>().fireTimeInSeconds;
        this.enemyAimLabel.text = string.Format(TextFormat, fireSpeed);
        this.theSlider.value = fireSpeed;
    }

    void Update()
    {

    }

    public void OnValueChanged(Slider slider)
    {
        this.enemyTemplate.GetComponentInChildren<EnemyfireScript>().fireTimeInSeconds = slider.value;
        this.enemyAimLabel.text = string.Format(TextFormat, slider.value);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponentInChildren<EnemyfireScript>().fireTimeInSeconds = slider.value;
        }
    }
}
