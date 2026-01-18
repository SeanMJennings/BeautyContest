namespace BeautyContest.Application.RuleSets;

using Domain;

public interface IAmARuleSet
{
    void Play(ReadOnlySpan<int> scores, List<Player> players);
}