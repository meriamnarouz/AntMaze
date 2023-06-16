
// Description: This file keeps track of the location of the nodes and returns location if called. 

public class Node
{
    // Instance variables
    private int x;
    private int y;

    // Constructor
    public Node(int x, int y)
    {
        this.x = x; // x equals x
        this.y = y; // y equals y
    } // End of constructor

    // Method to return the x coordinate of the node
    public int GetX()
    {
        return x;
    } // End of GetX

    // Method to return the y coordinate of the node
    public int GetY()
    {
        return y;
    } // End of GetY

} // End of class
