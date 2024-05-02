
using UnityEngine;

public class Automat2D : MonoBehaviour
{
private Automat[,] my2DArray;
private int rows;
private int columns;
private GameObject root;


public Automat2D(GameObject gameObject, int rows, int columns){
    this.rows = rows;
    this.columns = columns;
    this.root = gameObject;
    my2DArray = new Automat[rows,columns];
    SetDefaultState();
}

private void SetDefaultState(){
    int width =1;
    int height =1;
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            my2DArray[i,j] =new Automat(this.root, (float)i, (float)j, (float)width, (float)height, 0);
        }
    }
}

public Automat GetAutomat(int i, int j){
    return my2DArray[i,j];

}

public int CountRows(){
    return this.rows;
}

public int CountColumns(){
    return this.columns;
}

public void DrawAutomat2D(){
     foreach (var item in my2DArray)
        {
            item.Draw();
        }
}
}
