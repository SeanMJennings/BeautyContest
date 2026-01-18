namespace BeautyContest.Application.RuleSets;

using Domain;

public class FirstRuleSet : BaseRuleSet
{
    public override void Play(ReadOnlySpan<int> scores, List<Player> players)
    {
        SetScores(scores, players);
        SetDifferences(scores, players);
        RankPlayers(players);
        DeductPoints(players);
        base.Play(scores, players);
    }
}