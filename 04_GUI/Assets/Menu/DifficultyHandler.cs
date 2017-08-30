using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DifficultyHandler : MonoBehaviour
{
    public Dropdown theDropdown;

    private GameObject player;

    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.theDropdown.value = (int)this.player.GetComponent<PlayerController>().difficulty - 1;
    }

    void Update()
    {

    }

    public void ValueChange(Dropdown dropDown)
    {
        this.player.GetComponent<PlayerController>().difficulty = (Difficulty)dropDown.value + 1;
    }
}
