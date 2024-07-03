using System;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Manages the bingo balls and provides functionality to pick random balls, shuffle balls, reset balls, and retrieve information about drawn and remaining balls.
/// </summary>
public class BingoBallManager
{
    private List<int>? balls; // Nullable list to store the remaining bingo balls
    private List<int>? drawnBalls; // Nullable list to store the drawn bingo balls
    private Random random; // Random number generator for shuffling
    private List<string> disabledRows = new List<string>();

    public List<string> DisabledRows
    {
        get { 
            return new List<string>(disabledRows); 
        }
        set
        {
            disabledRows = new List<string>(value);
            InitializeBalls(); 
        }
    }


    /// <summary>
    /// Initializes a new instance of the <see cref="BingoBallManager"/> class.
    /// </summary>
    public BingoBallManager()
    {
        balls = null; // Initialize balls as null
        drawnBalls = null; // Initialize drawnBalls as null
        InitializeBalls(); // Initialize the balls
        random = new Random(Guid.NewGuid().GetHashCode()); // Initialize the random number generator with a unique seed
    }

    /// <summary>
    /// Initializes the bingo balls from 1 to 75.
    /// </summary>
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
    }


    /// <summary>
    /// Shuffles the bingo balls using the Fisher-Yates shuffle algorithm.
    /// </summary>
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

    /// <summary>
    /// Picks a random ball from the remaining balls.
    /// </summary>
    /// <returns>The randomly picked ball number.</returns>
    public int PickRandomBall()
    {
        if (balls == null || balls.Count == 0) throw new InvalidOperationException("All bingo balls have been drawn."); // Check if there are any remaining balls 
        int index = balls.Count - 1; // Get the index of the last ball
        int pickedBall = balls[index]; // Get the picked ball
        drawnBalls!.Add(pickedBall); // Add the picked ball to the drawn balls list
        balls.RemoveAt(index); // Remove the picked ball from the remaining balls list
        return pickedBall; // Return the picked ball number
    }

    /// <summary>
    /// Resets the bingo balls back to the default state.
    /// </summary>
    public void ResetBalls()
    {
        InitializeBalls(); // Reinitialize the balls
        ShuffleBalls();
    }

    /// <summary>
    /// Gets the list of drawn balls.
    /// </summary>
    /// <returns>The list of drawn ball numbers.</returns>
    public List<int> GetDrawnBalls()
    {
        return drawnBalls ?? new List<int>(); // Return an empty list if drawnBalls is null
    }

    /// <summary>
    /// Gets the list of remaining balls.
    /// </summary>
    /// <returns>The list of remaining ball numbers.</returns>
    public List<int> GetRemainingBalls()
    {
        return balls ?? new List<int>(); // Return an empty list if balls is null
    }

    /// <summary>
    /// Gets the letter associated with the bingo ball number.
    /// </summary>
    /// <param name="ballNumber">The bingo ball number.</param>
    /// <returns>The letter associated with the bingo ball number.</returns>
    public char GetBallLetter(int ballNumber)
    {
        if (ballNumber >= 1 && ballNumber <= 15) return 'B'; // Return 'B' for ball numbers 1-15
        if (ballNumber >= 16 && ballNumber <= 30) return 'I'; // Return 'I' for ball numbers 16-30
        if (ballNumber >= 31 && ballNumber <= 45) return 'N'; // Return 'N' for ball numbers 31-45
        if (ballNumber >= 46 && ballNumber <= 60) return 'G'; // Return 'G' for ball numbers 46-60
        if (ballNumber >= 61 && ballNumber <= 75) return 'O'; // Return 'O' for ball numbers 61-75
        throw new ArgumentOutOfRangeException("ballNumber", "Ball number must be between 1 and 75."); // Throw an exception for invalid ball numbers
    }

    /// <summary>
    /// Gets the number of balls that have been drawn.
    /// </summary>
    /// <returns>The number of drawn balls.</returns>
    public int GetDrawnBallsCount()
    {
        return drawnBalls?.Count + 1 ?? 0; // Return 0 if drawnBalls is null
    }

    public int GetBallsLeft() {
        return balls?.Count - 1 ?? 0; // Return 0 if balls.Count is null 
    }

    public int PeekNextBall()
    {
        if (balls == null || balls.Count == 0)
        {
            throw new InvalidOperationException("All bingo balls have been drawn.");
        }
        else
        {
            if (balls.Count > 1) ShuffleBalls(); // Shuffle the balls if more than one ball is remaining
            return balls[balls.Count - 1]; // Return the topmost ball without removing it
        }
    }

}
