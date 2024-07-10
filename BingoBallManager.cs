using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

public class GameState
{
    public List<int>? RemainingBalls { get; set; }
    public List<int>? DrawnBalls { get; set; }
    public int? PeekedBall { get; set; }
    public string? CurrentDate { get; set; }
    public string? CurrentTime { get; set; }
}

public class BingoBallManager
{
    private List<int>? balls; // Nullable list to store the remaining bingo balls
    private List<int>? drawnBalls; // Nullable list to store the drawn bingo balls
    private Random random; // Random number generator for shuffling
    private List<string> disabledRows = new List<string>();
    private List<int> ballsToRemove = new List<int>();
    private string fileName = "logs/state.txt"; // Name of the file to store the game state
    private string directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) ?? Environment.CurrentDirectory;
    private int? peekedBall = null;
    private Boolean isRecovered = false; 

    public List<string> DisabledRows
    {
        get
        {
            return new List<string>(disabledRows);
        }
        set
        {
            disabledRows = new List<string>(value);
            InitializeBalls();
        }
    }

    public List<int> BallsToRemove
    {
        get { return ballsToRemove; }
        set { ballsToRemove = value; }
    }

    public BingoBallManager()
    {
        balls = null; // Initialize balls as null
        drawnBalls = null; // Initialize drawnBalls as null
        InitializeBalls(); // Initialize the balls
        random = new Random(Guid.NewGuid().GetHashCode()); // Initialize the random number generator with a unique seed
    }

    private void InitializeBalls()
    {
        balls = new List<int>(); // Create a new list for balls

        if (disabledRows.Count == 0)
        {
            Debug.WriteLine("No rows disabled!");

            // If no rows are disabled, add all numbers from 1 to 75
            for (int i = 1; i <= 75; i++)
            {
                balls.Add(i); // Add each number from 1 to 75 to the list
            }
        }
        else
        {
            Debug.WriteLine("Some rows are disable!");
            // Define row ranges
            var rowRanges = new Dictionary<string, Tuple<int, int>>
        {
            { "B", Tuple.Create(1, 15) },
            { "I", Tuple.Create(16, 30) },
            { "N", Tuple.Create(31, 45) },
            { "G", Tuple.Create(46, 60) },
            { "O", Tuple.Create(61, 75) }
        };

            // Add numbers to the balls list, excluding those in the disabled rows
            for (int i = 1; i <= 75; i++)
            {
                bool isDisabled = false;
                foreach (var row in disabledRows)
                {
                    if (rowRanges.ContainsKey(row) && i >= rowRanges[row].Item1 && i <= rowRanges[row].Item2)
                    {
                        isDisabled = true;
                        break;
                    }
                }

                if (!isDisabled)
                {
                    balls.Add(i); // Add number to the list if not in a disabled row
                }

            }
        }


        Console.WriteLine(balls);
        drawnBalls = new List<int>(); // Create a new list for drawn balls


        foreach (int ballToRemove in ballsToRemove)
        {
            balls.Remove(ballToRemove);
            drawnBalls.Add(ballToRemove);
        }

    }

    private void ShuffleBalls()
    {
        for (int shuffle = 0; shuffle < random.Next(1, 51); shuffle++) // Perform a random number of shuffles between 1 and 50
        {
            for (int i = balls!.Count - 1; i > 0; i--) // Loop through the balls list
            {
                int j = random.Next(i + 1); // Generate a random index j
                int temp = balls[j]; // Swap the elements at indices i and j
                balls[j] = balls[i];
                balls[i] = temp;
            }
        }
    }

    public int PickRandomBall()
    {
        if (balls == null || balls.Count == 0) throw new InvalidOperationException("All bingo balls have been drawn."); // Check if there are any remaining balls 
        int index = balls.Count - 1; // Get the index of the last ball
        int pickedBall = balls[index]; // Get the picked ball
        drawnBalls!.Add(pickedBall); // Add the picked ball to the drawn balls list
        balls.RemoveAt(index); // Remove the picked ball from the remaining balls list
        return pickedBall; // Return the picked ball number
    }

    public void ResetBalls()
    {        
        InitializeBalls(); // Reinitialize the balls
        ShuffleBalls();
    }

    public List<int> GetDrawnBalls()
    {
        return drawnBalls ?? new List<int>(); // Return an empty list if drawnBalls is null
    }

    public List<int> GetRemainingBalls()
    {
        return balls ?? new List<int>(); // Return an empty list if balls is null
    }

    public char GetBallLetter(int ballNumber)
    {
        if (ballNumber >= 1 && ballNumber <= 15) return 'B'; // Return 'B' for ball numbers 1-15
        if (ballNumber >= 16 && ballNumber <= 30) return 'I'; // Return 'I' for ball numbers 16-30
        if (ballNumber >= 31 && ballNumber <= 45) return 'N'; // Return 'N' for ball numbers 31-45
        if (ballNumber >= 46 && ballNumber <= 60) return 'G'; // Return 'G' for ball numbers 46-60
        if (ballNumber >= 61 && ballNumber <= 75) return 'O'; // Return 'O' for ball numbers 61-75
        throw new ArgumentOutOfRangeException("ballNumber", "Ball number must be between 1 and 75."); // Throw an exception for invalid ball numbers
    }

    public int GetDrawnBallsCount()
    {
        return drawnBalls?.Count + 1 ?? 0; // Return 0 if drawnBalls is null
    }

    public int GetBallsLeft()
    {
        return balls?.Count - 1 ?? 0; // Return 0 if balls.Count is null 
    }

    public int PeekNextBall()
    {
        if (isRecovered == true)
        {
            isRecovered = false; 
            return (int)peekedBall;
        }

        if (balls == null || balls.Count == 0)
        {
            throw new InvalidOperationException("All bingo balls have been drawn.");
        }
        else
        {
            if (balls.Count > 1) ShuffleBalls(); // Shuffle the balls if more than one ball is remaining
            int ball = balls[balls.Count - 1];
            peekedBall = ball; // Store the peeked ball's value
            WriteGameStateToFile();
            return ball;
        }
    }

    // Method to write the current game state to a file
    private void WriteGameStateToFile()
    {
        string filePath = Path.Combine(directory, fileName); // Create the file path

        // Create a new file or overwrite the existing file
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Create a JSON string containing the game state and the current date and time
            var gameData = new
            {
                RemainingBalls = balls,
                DrawnBalls = drawnBalls,
                PeekedBall = peekedBall,
                CurrentDate = (DateTime.Now.Date.ToString("d")).ToString(),
                CurrentTime = (DateTime.Now.TimeOfDay.ToString("hh\\:mm\\:ss")).ToString()
            };

            string jsonString = System.Text.Json.JsonSerializer.Serialize(gameData);

            writer.WriteLine(jsonString); // Write the JSON string to the file
        }
    }

    public void LoadGameStateFromFile()
    {
        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException("The specified game state file does not exist!");
        }

        using (var reader = new StreamReader(fileName))
        {
            string json = reader.ReadToEnd(); // Read the entire JSON string from the file

            // Deserialize the JSON string to retrieve the game state
            var gameData = System.Text.Json.JsonSerializer.Deserialize<GameState>(json);

            if (gameData == null)
            {
                throw new Exception("Invalid game state file format!");
            }

            // Reset the values of RemainingBalls, DrawnBalls, and PeekedBall
            balls = gameData.RemainingBalls;
            drawnBalls = gameData.DrawnBalls;
            peekedBall = gameData.PeekedBall;
            isRecovered = true;
        }
    }

    public void RenameSaveFile()
    {
        string filePath = Path.Combine(directory, fileName); // Create the file path
        string json;

        using (var reader = new StreamReader(filePath))
        {
            json = reader.ReadToEnd(); // Read the entire JSON string from the file
        }

        // Deserialize the JSON string to retrieve the game state
        var gameData = System.Text.Json.JsonSerializer.Deserialize<GameState>(json);

        if (gameData == null)
        {
            throw new Exception("Invalid game state file format!");
        }

        // Format the current date and time according to the BINGO_YYYYMMDD_HHMMSS.log template
        string formattedDate = gameData.CurrentDate.Replace("-", "").Replace("/", "");
        string formattedTime = gameData.CurrentTime.Replace(":", "");

        // Create a new file name using the formatted date and time
        string newFileName = $"BINGO_{formattedDate}_{formattedTime}.log";
        newFileName = "logs/" + newFileName;
        // Create the new file path
        string newFilePath = Path.Combine(directory, newFileName);

        // Rename the save file
        File.Move(filePath, newFilePath);
    }
}