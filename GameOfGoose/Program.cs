// See https://aka.ms/new-console-template for more information
using GameOfGoose;
using GameOfGoose.GameRules;
using System.Data;

Console.WriteLine("Game Of Goose");

var numberOfPlayers = 5;
var dice = new Dice(6, 2);
var gameOverPosition = 63;
var gameRulesList = new List<GameRule>
{
    new FirstDiceRollGameRule("", new int[] { 6, 3 }, 26),
    new FirstDiceRollGameRule("", new int[] { 5, 4 }, 53),
    new OccupiedSpaceGameRule(""),
    new GooseSpaceGameRule("", new int[] { 5, 9, 14, 18, 23, 27, 32, 36, 41, 45, 50, 54, 59 }),
    new GoToHazardSpaceGameRule("", "The Bridge", 6, 12),
    new SkipTurnHazardSpaceGameRule("", "The Hotel", 19),
    new StuckHazardSpaceGameRule("", "The Well", 31),
    new GoToHazardSpaceGameRule("", "The Maze", 42, 39),
    new StuckHazardSpaceGameRule("", "The Prison", 52),
    new GoToHazardSpaceGameRule("", "Death", 58, 0),
    new MessageOnlyHazardSpaceGameRule("", "Drink", 61),
};

GameLoop gameLoop = new GameLoop(numberOfPlayers, dice, gameRulesList, gameOverPosition);
gameLoop.Play();
