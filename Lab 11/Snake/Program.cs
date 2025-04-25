using System;
using System.Collections.Generic;

Exception? exception = null;
int speedInput;
string prompt = $"Select speed [1], [2] (default), or [3]: ";
string? input;
Console.Write(prompt);
while (!int.TryParse(input = Console.ReadLine(), out speedInput) || speedInput < 1 || 3 < speedInput)
{
	if (string.IsNullOrWhiteSpace(input))
	{
		speedInput = 2;
		break;
	}
	else
	{
		Console.WriteLine("Invalid Input. Try Again...");
		Console.Write(prompt);
	}
}
int[] velocities = [100, 70, 50];
int velocity = velocities[speedInput - 1];
char[] DirectionChars = ['^', 'v', '<', '>',];
TimeSpan sleep = TimeSpan.FromMilliseconds(velocity);
int width = Console.WindowWidth;
int height = Console.WindowHeight;
Tile[,] map = new Tile[width, height];
Direction? direction = null;
Queue<(int X, int Y)> snake = new();
(int X, int Y) = (width / 2, height / 2);
bool closeRequested = false;

try
{
	Console.CursorVisible = false;
	Console.Clear();
	snake.Enqueue((X, Y));
	map[X, Y] = Tile.Snake;
	PositionFood();
	Console.SetCursorPosition(X, Y);
	Console.Write('@');
	while (!direction.HasValue && !closeRequested)
	{
		GetDirection();
	}
	while (!closeRequested)
	{
		if (Console.WindowWidth != width || Console.WindowHeight != height)
		{
			Console.Clear();
			Console.Write("Console was resized. Snake game has ended.");
			return;
		}
		switch (direction)
		{
			case Direction.Up: Y--; break;
			case Direction.Down: Y++; break;
			case Direction.Left: X--; break;
			case Direction.Right: X++; break;
		}
		if (X < 0 || X >= width ||
			Y < 0 || Y >= height ||
			map[X, Y] is Tile.Snake)
		{
			Console.Clear();
			Console.Write("Game Over. Score: " + (snake.Count - 1) + ".");
			return;
		}
		Console.SetCursorPosition(X, Y);
		Console.Write(DirectionChars[(int)direction!]);
		snake.Enqueue((X, Y));
		if (map[X, Y] is Tile.Food)
		{
			PositionFood();
		}
		else
		{
			(int x, int y) = snake.Dequeue();
			map[x, y] = Tile.Open;
			Console.SetCursorPosition(x, y);
			Console.Write(' ');
		}
		map[X, Y] = Tile.Snake;
		if (Console.KeyAvailable)
		{
			GetDirection();
		}
		System.Threading.Thread.Sleep(sleep);
	}
}
catch (Exception e)
{
	exception = e;
	throw;
}
finally
{
	Console.CursorVisible = true;
	Console.Clear();
	Console.WriteLine(exception?.ToString() ?? "Snake was closed.");
}

bool IsOpposite(Direction newDir, Direction currentDir)
{
	return (newDir == Direction.Up && currentDir == Direction.Down) ||
		   (newDir == Direction.Down && currentDir == Direction.Up) ||
		   (newDir == Direction.Left && currentDir == Direction.Right) ||
		   (newDir == Direction.Right && currentDir == Direction.Left);
}

void GetDirection()
{
	var key = Console.ReadKey(true).Key;
	Direction tempDir = direction ?? Direction.Right;  // fallback

	switch (key)
	{
		case ConsoleKey.UpArrow:
			tempDir = Direction.Up;
			break;
		case ConsoleKey.DownArrow:
			tempDir = Direction.Down;
			break;
		case ConsoleKey.LeftArrow:
			tempDir = Direction.Left;
			break;
		case ConsoleKey.RightArrow:
			tempDir = Direction.Right;
			break;
		case ConsoleKey.Escape:
			closeRequested = true;
			return;
	}

	// **Ignore** if reversing
	if (direction.HasValue && IsOpposite(tempDir, direction.Value))
		return;

	direction = tempDir;
}


void PositionFood()
{
	List<(int X, int Y)> possibleCoordinates = new();
	for (int i = 0; i < width; i++)
	{
		for (int j = 0; j < height; j++)
		{
			if (map[i, j] is Tile.Open)
			{
				possibleCoordinates.Add((i, j));
			}
		}
	}
	int index = Random.Shared.Next(possibleCoordinates.Count);
	(int X, int Y) = possibleCoordinates[index];
	map[X, Y] = Tile.Food;
	Console.SetCursorPosition(X, Y);
	Console.Write('+');
}

enum Direction
{
	Up = 0,
	Down = 1,
	Left = 2,
	Right = 3,
}

enum Tile
{
	Open = 0,
	Snake,
	Food,
}