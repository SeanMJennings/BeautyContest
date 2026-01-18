namespace BeautyContest.Domain;

using Exceptions;

public readonly record struct Score : IComparable<Score>
{
    private int Value { get; }

    public Score(int value)
    {
        if (value is < 0 or > 100) throw new ScoreOutOfBoundsException();
        Value = value;
    }

    public static implicit operator Score(int value) => new(value);
    public static implicit operator int(Score score) => score.Value;

    public int CompareTo(Score other) => Value.CompareTo(other.Value);
}