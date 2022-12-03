using RockPaperScissors;

Console.WriteLine("Advent of Code - Day 2");

var score = 0;
var strategyGuideParser = new StrategyGuideParser();
var tournament = new Tournament();

foreach (string line in File.ReadLines(@"input.txt"))
{
    var gameRoundStrategy = strategyGuideParser.ParseRoundStrategy(line);
    var wantedHandShape = tournament.GameEngine.CalculateHandShapeNeeded(gameRoundStrategy);
    var gameRound = new GameRound(gameRoundStrategy.OpponentHandShape, wantedHandShape);

    var roundScore = tournament.CalculateRoundScore(gameRound);
    score += roundScore;
}

Console.WriteLine($"If you were to follow the strategy guide, you would get a total score of {score}");