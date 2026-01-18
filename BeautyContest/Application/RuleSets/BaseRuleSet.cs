namespace BeautyContest.Application.RuleSets;

using Domain;

public abstract class BaseRuleSet : IAmARuleSet
{
    protected static int Goal;
    protected int Penalty = 1;
    private static bool scoresAreSet;
    private static bool playersAreRanked;
    private static bool differencesAreSet;

    public virtual void Play(ReadOnlySpan<int> scores, List<Player> players)
    {
        ResetChecks();
    }

    protected static void ResetChecks()
    {
        scoresAreSet = false;
        playersAreRanked = false;
        differencesAreSet = false;
    }

    protected static void SetScores(ReadOnlySpan<int> scores, List<Player> players)
    {
        if (scoresAreSet) return;

        var playerIndex = 0;
        foreach (var score in scores)
        {
            players[playerIndex++].Score = score;
        }

        scoresAreSet = true;
    }

    protected void DeductPoints(List<Player> rankedPlayers)
    {
        for (var i = 0; i < Penalty; i++)
        {
            foreach (var player in rankedPlayers.Where(p => p.Rank != 0))
            {
                player.DeductPoint();
            }
        }
    }

    protected static void RankPlayers(List<Player> players)
    {
        if (playersAreRanked) return;
        players = [.. players.OrderBy(p => p.Difference).ThenByDescending(p => p.Score)];
        var rank = 0;
        var playerCounter = 0;

        foreach (var player in players)
        {
            player.Rank = rank;
            if (players.Count > playerCounter + 1 &&
                (players[playerCounter].Difference < players[playerCounter + 1].Difference ||
                 (players[playerCounter].Difference == players[playerCounter + 1].Difference &&
                  players[playerCounter].Score > players[playerCounter + 1].Score)))
            {
                rank++;
            }

            playerCounter++;
        }

        playersAreRanked = true;
    }

    protected static void SetDifferences(ReadOnlySpan<int> scores, List<Player> players)
    {
        if (differencesAreSet) return;

        var sum = 0;
        foreach (var score in scores) sum += score;

        Goal = (int)Math.Round(sum / (double)scores.Length * 0.8);

        foreach (var player in players)
        {
            player.SetDifference(Goal);
        }

        differencesAreSet = true;
    }
}