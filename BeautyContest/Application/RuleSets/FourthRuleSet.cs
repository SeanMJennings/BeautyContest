namespace BeautyContest.Application.RuleSets;

using Domain;

public class FourthRuleSet : ThirdRuleSet
{
    public override void Play(ReadOnlySpan<int> scores, List<Player> players)
    {
        SetScores(scores, players);
        if (OnePlayerChoseZeroAndAnotherChoseOneHundred(players)) return;
        base.Play(scores, players);
    }

    private static bool OnePlayerChoseZeroAndAnotherChoseOneHundred(List<Player> players)
    {
        if (players.Exists(p => p.Score == 0) && players.Exists(p => p.Score == 100))
        {
            foreach (var player in players.Where(p => p.Score != 100))
            {
                player.DeductPoint();
            }

            ResetChecks();
            return true;
        }

        return false;
    }
}