/*
// Description: This file uses a stack of type node, a char[][] maze, and integers sugarFound,
//				mHeight, and mWidth. It also calls the node class to know which char is next
//				to it in any direction in order to decide where to go. It goes through the 
//				whole maze looking for sugar but it cannot cross the walls. It then
//				prints the final maze when called. 
*/

using System;
using System.IO;
using System.Collections.Generic;

public class MazeSolver
{
    // Instance variables
    private Stack<Node> stack; // The stack
    private char[][] maze; // The maze
    private int sugarFound; // Sugar found in maze
    private int mHeight; // Height of maze
    private int mWidth; // Width of maze

    // Constructor
    public MazeSolver()
    {
        // Initialize variables
        stack = new Stack<Node>();
        maze = null;
        sugarFound = 0;
        mHeight = 0;
        mWidth = 0;
    } // End of constructor

    // Method to search maze for sugar
    public void DepthFirstSearch()
    {
        Node current = new Node(0, 0); // Get first coordinate
        stack.Push(current); // Push it to the top

        // If statement to make sure the first coordinate is visited
        if (maze[current.GetX()][current.GetY()] == 'B')
        {
            // If visited, change it to 'x' to indicate visitation
            maze[current.GetX()][current.GetY()] = 'x';
        } // End of if statement

        // While loop to run while stack is not empty
        while (stack.Count > 0)
        {
            current = stack.Pop(); // Pop it and get value

            // Save the char of the specific location in maze as variable 'character'
            char character = maze[current.GetX()][current.GetY()];

            // Check if there is sugar
            if (character == 'S') // If character is a sugar
            {
                sugarFound++; // Increase the count of found sugar
                maze[current.GetX()][current.GetY()] = 'x'; // Save it as visited
            }
            else if (character == '.') // If character is an unexplored path
            {
                maze[current.GetX()][current.GetY()] = 'x'; // Save it as visited
            } // End of if-else statement

            // Check west
            // Check if the cell to the left is in bounds
            bool left = ((current.GetX() - 1) < mHeight) && ((current.GetX() - 1) >= 0);

            if (left) // If left is in bounds
            {
                // Get char in cell on the left
                char west = maze[current.GetX() - 1][current.GetY()];

                if ((west != 'x') && (west != '#')) // If west is not visited and not a wall
                {
                    // Create new node with coordinates of west
                    Node new1 = new Node((current.GetX() - 1), (current.GetY()));
                    stack.Push(new1); // Push it to the top
                } // End of inner if statement

            } // End of outer if statement checking west

            // Check east
            // Check if the cell to the right is in bounds
            bool right = ((current.GetX() + 1) < mHeight) && ((current.GetX() + 1) >= 0);

            if (right) // If right is in bounds
            {
                // Get char in cell on the right
                char east = maze[current.GetX() + 1][current.GetY()];

                if ((east != 'x') && (east != '#')) // If east is not visited and not a wall
                {
                    // Create new node with coordinates of east
                    Node new2 = new Node((current.GetX() + 1), (current.GetY()));
                    stack.Push(new2); // Push it to the top
                } // End of inner if statement

            } // End of outer if statement checking east

            // Check north
            // Check if the cell above is in bounds
            bool above = ((current.GetY() + 1) < mWidth) && ((current.GetY() + 1) >= 0);

            if (above) // If above is in bounds
            {
                // Get char in cell above
                char north = maze[current.GetX()][current.GetY() + 1];

                if ((north != 'x') && (north != '#')) // If north is not visited and not a wall
                {
                    // Create new node with coordinates of north
                    Node new3 = new Node((current.GetX()), (current.GetY() + 1));
                    stack.Push(new3); // Push it to the top
                } // End of inner if statement

            } // End of outer if statement checking north

            // Check south
            // Check if the cell below is in bounds
            bool below = ((current.GetY() - 1) < mWidth) && ((current.GetY() - 1) >= 0);

            if (below) // If below is in bounds
            {
                // Get char in cell below
                char south = maze[current.GetX()][current.GetY() - 1];

                if ((south != 'x') && (south != '#')) // If south is not visited and not a wall
                {
                    // Create new node with coordinates of south
                    Node new4 = new Node((current.GetX()), (current.GetY() - 1));
                    stack.Push(new4); // Push it to the top
                } // End of inner if statement

            } // End of outer if statement checking south

        } // End of while loop

    } // End of DepthFirstSearch method

    // GetSugarFound returns the number of found sugar in the maze
    public int GetSugarFound()
    {
        return sugarFound;
    } // End of GetSugarFound method

    // PrintMaze outputs the maze after traversing
    public void PrintMaze()
    {
        // For loop to print maze
        for (int i = 0; i < mHeight; i++) // Outer loop checking height
        {
            for (int j = 0; j < mWidth; j++) // Inner loop checking width
            {
                // Print maze
                Console.Write(maze[i][j]);
            } // End of inner for loop

            Console.WriteLine(); // Print empty line
        } // End of outer for loop

        Console.WriteLine(); // Print empty line
    } // End of PrintMaze method

    // Reads the maze from the user
    public void ReadMaze()
    {
        try
        {
            Console.WriteLine("Height of the maze: ");
            string line = Console.ReadLine();
            mHeight = int.Parse(line);

            Console.WriteLine("Width of the maze: ");
            line = Console.ReadLine();
            mWidth = int.Parse(line);
            maze = new char[mHeight][];

            Console.WriteLine("Enter the maze: ");
            for (int i = 0; i < mHeight; i++)
            {
                line = Console.ReadLine();
                maze[i] = new char[mWidth];
                for (int j = 0; j < mWidth; j++)
                {
                    maze[i][j] = line[j];
                }
            }

        }
        catch (IOException e)
        {
          Console.WriteLine(e.StackTrace);
        }
    } // End of ReadMaze method

} // End of class
