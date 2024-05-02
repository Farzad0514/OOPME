using UnityEngine;

public class main : MonoBehaviour
{
  // Start is called before the first frame update

  void Start()
  {

    //  PatternCount is the pattern number, choose from 1,2,3
    // GenerationSize is 50 and listOfGenerations has 50 elements from 0 to 49
    var listOfGenerations = ListOfGenerations(rows: 40, columns:40, generationsSize:50, patternCount:3);
    // DrawGeneration(listOfGenerations.GetElement(0));
    // DrawGeneration(listOfGenerations.GetElement(4));
    // DrawGeneration(listOfGenerations.GetElement(9));
    // DrawGeneration(listOfGenerations.GetElement(19));
    DrawGeneration(listOfGenerations.GetElement(49));


  }

  Automat2D OriginalAutomatArray(int rows, int columns, int patternCount)
  {
    Automat2D automat_array = new Automat2D(gameObject, rows, columns);
    Pattern(automat_array, patternCount, rows, columns);

    return automat_array;
  }

  static void Pattern(Automat2D array, int patternCount, int rows, int columns)
  {
    Pattern pattern = new Pattern(array, rows, columns);
    pattern.CreatePattern(patternCount);
  }

int CountAliveNeighbours(Automat2D automat2D, int row, int column)
{
    int count = 0;
    int rows_length = automat2D.CountRows();
    int columns_length = automat2D.CountColumns();

    for (int i = -1; i <= 1; i++) 
    {
        for (int j = -1; j <= 1; j++) 
        {
            // Skip the center cell (i=0, j=0)
            if (i == 0 && j == 0) 
            {
                continue;
            }

            

            int new_row = row + i; 
            int new_column = column + j; 

               if (new_row < 0)
                {
                    count += 0;
                }

                else if(new_row >= rows_length){
                    count += 0;
                }
                 else if(new_column < 0){
                     count += 0;
                }
                 else if(new_column >= columns_length){
                     count += 0;
                }
                else
                {
                count += automat2D.GetAutomat(new_row, new_column).IsAlive();
                }
        }
    }

    return count;
}




  Automat2D NextGeneration(Automat2D automat2D)
  {
    int rows = automat2D.CountRows();
    int columns = automat2D.CountColumns();
    
    Automat2D newAutomat2D = new Automat2D(gameObject, rows, rows);

    for (int i = 0; i < rows; i++) {
      for (int j = 0; j < columns; j++) {
        int alive_neighbours = CountAliveNeighbours(automat2D, i, j);
        if (automat2D.GetAutomat(i, j).IsAlive() == 0 &&
            alive_neighbours == 3) {
          newAutomat2D.GetAutomat(i, j).SetAlive();
        } else if (automat2D.GetAutomat(i, j).IsAlive() == 0 &&
            alive_neighbours != 3) {
          newAutomat2D.GetAutomat(i, j).SetDead();
        }
        
        else if (automat2D.GetAutomat(i, j).IsAlive() == 1 &&
                   (alive_neighbours < 2 || alive_neighbours > 3)) {
          newAutomat2D.GetAutomat(i, j).SetDead();
        } else if (automat2D.GetAutomat(i, j).IsAlive() == 1 &&
                   (alive_neighbours == 2 || alive_neighbours == 3)) {
          newAutomat2D.GetAutomat(i, j).SetAlive();
        }
      }
    }
    return newAutomat2D;
  }

  void DrawGeneration(Automat2D automat2D) { automat2D.DrawAutomat2D(); }

  ListOf2DArrays ListOfGenerations(int rows, int columns, int generationsSize, int patternCount)
  {
    ListOf2DArrays listOfGenerations = new ListOf2DArrays();
    listOfGenerations.AddElement(OriginalAutomatArray(rows, columns, patternCount));
    for (int i = 1; i < generationsSize; i++) {
      listOfGenerations.AddElement(
        NextGeneration(listOfGenerations.GetElement(i - 1)));
    }

    return listOfGenerations;
  }

}
