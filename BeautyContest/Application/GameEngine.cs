namespace BeautyContest.Application;

using System.Collections.ObjectModel;
using Domain;
using Domain.Exceptions;
using RuleSets;
using RuleSets.Factory;

public class GameEngine(IAmARuleSetFactory ruleSetFactory)
{
    private const int NumberOfPlayers = 5;
    private readonly List<Player> players = [.. Enumerable.Range(0, NumberOfPlayers).Select(_ => new Player())];

    public void Play(params ReadOnlySpan<int> scores)
    {
        var alivePlayers = players.FindAll(p => p.IsAlive);
        ValidateScores(scores, alivePlayers.Count);

        ruleSetFactory.GetRuleSet((RuleSet)(NumberOfPlayers - alivePlayers.Count + 1)).Play(scores, alivePlayers);
    }

    private static void ValidateScores(ReadOnlySpan<int> scores, int numberOfPlayersAlive)
    {
        if (scores.Length != numberOfPlayersAlive) throw new IncorrectNumberOfScoresException();
    }

    public ReadOnlyCollection<Player> GetPlayers()
    {
        return players.AsReadOnly();
    }
}