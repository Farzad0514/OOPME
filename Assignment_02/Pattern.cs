using UnityEngine;

public class Pattern 
{

private Automat2D array;
private int rows;
private int columns;


public Pattern (Automat2D array, int rows, int columns)  {
    this.array = array;
    this.rows = rows;
    this.columns = columns;
}

public void CreatePattern(int pattern){

    if (pattern == 1)
    {
        int i = (this.rows / 2)-1; 
        int j = (this.columns / 2)-1;

        this.array.GetAutomat(i, j).SetAlive();
        this.array.GetAutomat(i+1, j).SetAlive();
        this.array.GetAutomat(i+1, j+1).SetAlive();
        this.array.GetAutomat(i, j+1).SetAlive();
        Debug.Log("This is Pattern 1");
    }
    else if (pattern == 2)
    {

        int i = (this.rows / 2)-3; 
        int j = (this.columns / 2)-2;

        this.array.GetAutomat(i, j).SetAlive();
        this.array.GetAutomat(i+3, j).SetAlive();
        this.array.GetAutomat(i+4, j+1).SetAlive();
        this.array.GetAutomat(i+4, j+2).SetAlive();
        this.array.GetAutomat(i+4, j+3).SetAlive();
        this.array.GetAutomat(i+3, j+3).SetAlive();
        this.array.GetAutomat(i+2, j+3).SetAlive();
        this.array.GetAutomat(i+1, j+3).SetAlive();
        this.array.GetAutomat(i, j+2).SetAlive();
        Debug.Log("This is Pattern 2");
    }
    else   if (pattern == 3)
    {
        int i = (this.rows / 2)-4; 
        int j = (this.columns / 2)-2;

        this.array.GetAutomat(i, j).SetAlive();
        this.array.GetAutomat(i+1, j).SetAlive();
        this.array.GetAutomat(i+1, j+1).SetAlive();
        this.array.GetAutomat(i, j+1).SetAlive();
        this.array.GetAutomat(i+1, j+5).SetAlive();
        this.array.GetAutomat(i+2, j+5).SetAlive();
        this.array.GetAutomat(i+3, j+5).SetAlive();
        this.array.GetAutomat(i+1, j+6).SetAlive();
        this.array.GetAutomat(i+2, j+7).SetAlive();
        Debug.Log("This is Pattern 3");
    }
    else {
        this.array.GetAutomat(0, 4).SetAlive();
        this.array.GetAutomat(1, 4).SetAlive();
        this.array.GetAutomat(2, 4).SetAlive();
        this.array.GetAutomat(2, 5).SetAlive();
        this.array.GetAutomat(1, 6).SetAlive();
        Debug.Log("This is default pattern");
    }


}



}
