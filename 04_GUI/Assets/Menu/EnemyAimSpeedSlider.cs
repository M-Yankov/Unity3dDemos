using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyAimSpeedSlider : MonoBehaviour
{
    public Text enemyAimLabel;
    public GameObject enemyTemplate;
    public Slider theSlider;

    private const string TextFormat = "Enemy aim speed: {0:F2}";

    void Start()
    {
        float aimSpeed = this.enemyTemplate.GetComponent<EnemyScript>().aimSpeed;
        this.enemyAimLabel.text = string.Format(TextFormat, aimSpeed);
        this.theSlider.value = aimSpeed;
    }

    void Update()
    {

    }

    public void OnValueChanged(Slider slider)
    {
        this.enemyTemplate.GetComponent<EnemyScript>().aimSpeed = slider.value;
        this.enemyAimLabel.text = string.Format(TextFormat, slider.value);
    }
}
