using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{
    public Text scoreLabel;
    private float score;

    public void AddScore(float score)
    {
        this.score += score;
        this.VisualizateScore();
    }

    private void VisualizateScore()
    {
        float roundedScore = Mathf.Round(this.score);
        if (this.scoreLabel != null)
        {
            this.scoreLabel.text = string.Format("Score: {0}", roundedScore);
        }
    }
}
