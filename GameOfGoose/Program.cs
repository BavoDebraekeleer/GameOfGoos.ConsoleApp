// See https://aka.ms/new-console-template for more information
using GameOfGoose;
using GameOfGoose.GameRules;
using GameOfGoose.Messengers;
using System.Data;

Console.WriteLine("Game Of Goose");

var numberOfPlayers = 5;
var dice = new Dice(6, 2);

var gameRulesSetForAdults = new List<GameRule>
{
    new FirstDiceRollGameRule("Yes! First dice roll is a 6 and a 3! Move to space 26.", new int[] { 6, 3 }, 26),
    new FirstDiceRollGameRule("Wow! First dice roll is a 5 and a 4! Move to space 53!", new int[] { 5, 4 }, 53),
    new OccupiedSpaceGameRule("Space is already occupied by another goose."),
    new GooseSpaceGameRule("The goose landed on a Goose Space!", new int[] { 5, 9, 14, 18, 23, 27, 32, 36, 41, 45, 50, 54, 59 }),
    new GoToHazardSpaceGameRule("Take the bridge to space 12.", "The Bridge", 6, 12),
    new SkipTurnHazardSpaceGameRule("Stay for a turn, for a good night's sleep.", "The Hotel", 19),
    new StuckHazardSpaceGameRule("Fell into the well. Wait until someone comes to pull you out – they then take your place.", "The Well", 31),
    new GoToHazardSpaceGameRule("Oh no! The goose got lost in a maze. Go back to space 39.", "The Maze", 42, 39),
    new StuckHazardSpaceGameRule("The goose got locked up! Wait until someone comes to release you – they then take your place.", "The Prison", 52),
    new GoToHazardSpaceGameRule("You Died! Return to the beginning – start the game again.", "Death", 58, 0),
    new MessageOnlyHazardSpaceGameRule("Ad fundum! Drink up your drink!", "Drink", 61),
};

var gameOverPosition = 63;
var messenger = new ConsoleMessenger();

GameLoop gameLoop = new GameLoop(numberOfPlayers, dice, gameRulesSetForAdults, gameOverPosition, messenger);
gameLoop.Play();
