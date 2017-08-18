using UnityEngine;
using UnityEngine.UI;

public class ConfigurationScript : MonoBehaviour
{
    public float damageTaken = 2;
    public float scorePerKill = 20;

    private ScoreContainer scoreContainer;
    private GameObject scoreText;

    void Start()
    {
        this.scoreContainer = new ScoreContainer();
        
        Cursor.visible = false;
        Screen.fullScreen = true;
        //Screen.SetResolution(1600, 800, true);

        scoreText = GameObject.FindGameObjectWithTag(CustomTags.Score);
        Text textCompoent = scoreText.GetComponent<Text>();
        textCompoent.text = "Score: 0";
    }

    void Update()
    {
    }

    public void UpdateScore(float score)
    {
        this.scoreContainer.AddScore(score);
        string message = string.Format("Score: {0}", this.scoreContainer.Score);
        Text textCompoent = scoreText.GetComponent<Text>();
        textCompoent.text = message;
        if (score < 0 || this.scoreContainer.Score < 0)
        {
            textCompoent.color = Color.red;
            // Debug.LogError(message);
        }
        else
        {
            textCompoent.color = Color.white;
            // Debug.Log(message);
        }
    }
}
