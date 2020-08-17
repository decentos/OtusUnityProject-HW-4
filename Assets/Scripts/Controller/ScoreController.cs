using MVCExample;

public sealed class ScoreController : IExecute
{
    private int _score;
    public int Score => _score;

    public ScoreController(int startScore)
    {
        _score = startScore;
    }

    public void AddScore(int _value)
    {
        _score += _value;
    }

    public void Execute(float deltaTime)
    {
        
    }
}
