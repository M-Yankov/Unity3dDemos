using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerSpeedSlider : MonoBehaviour
{
    public Text playerSpeedLabel;
    public Slider theSlider;

    private GameObject player;
    private const string TextFormat = "Player speed: {0:F2}";

    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
        float speed = this.player.GetComponent<PlayerController>().speed;
        this.playerSpeedLabel.text = string.Format(TextFormat, speed);
        this.theSlider.value = speed;
        
    }

    void Update()
    {

    }

    public void OnValueChange(Slider slider)
    {
        this.player.GetComponent<PlayerController>().speed = slider.value;
        this.playerSpeedLabel.text = string.Format(TextFormat, slider.value);
    }
}
