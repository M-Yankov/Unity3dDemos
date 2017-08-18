public class ScoreContainer
{
    public ScoreContainer()
    {
        this.Score = 0;
    }

    public float Score { get; private set; }

    public void AddScore(float score)
    {
        this.Score += score;
    }
}
