namespace BeautyContest.Application.RuleSets;

using Domain;

public class SecondRuleSet : FirstRuleSet
{
    public override void Play(ReadOnlySpan<int> scores, List<Player> players)
    {
        SetScores(scores, players);
        if (PointsAreDeductedForMatchingScores(players)) return;
        base.Play(scores, players);
    }

    private static bool PointsAreDeductedForMatchingScores(List<Player> players)
    {
        var matchingPlayerGroups = players.GroupBy(p => p.Score).Where(g => g.Count() > 1).ToList();
        if (matchingPlayerGroups.Count > 0)
        {
            foreach (var matchingPlayer in matchingPlayerGroups.SelectMany(g => g))
            {
                matchingPlayer.DeductPoint();
            }
            ResetChecks();
            return true;
        }

        return false;
    }
}