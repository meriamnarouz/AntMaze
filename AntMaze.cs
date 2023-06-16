/*
// Description: This file takes in user input such as the width and height of the maze
//				and the maze itself. It calls methods from other classes. It is also   
//				responsible for outputting the maze before and after it is traversed 
//				well as if any pieces of sugar were found and how many. 
*/

using System;

public class AntMaze
{
    public static void Main(string[] args)
    {
        MazeSolver mazeSolver = new MazeSolver();
        mazeSolver.ReadMaze();

        Console.WriteLine("Original maze: ");
        mazeSolver.PrintMaze();

        mazeSolver.DepthFirstSearch();

        Console.WriteLine("Maze after the ant traversed it: ");
        mazeSolver.PrintMaze();

        if (mazeSolver.GetSugarFound() == 0)
            Console.WriteLine("The ant is hungry because it found no sugar!");
        else
            Console.WriteLine("The ant found " + mazeSolver.GetSugarFound() + " piece(s) of sugar!");
    }
}
