using System.Collections.Generic;
using UnityEngine;


public class ListOf2DArrays
{
    private readonly List<Automat2D> listOfGenerations;

    public ListOf2DArrays()
    {
        listOfGenerations = new List<Automat2D>();
    }

    public void AddElement(Automat2D element)
    {
        listOfGenerations.Add(element);
    }

    public Automat2D GetElement(int i)
    {
        if (i >= 0 && i < listOfGenerations.Count)
        {
            return listOfGenerations[i];
        }
        else
        {
            // Handle the case when the index is out of bounds
            Debug.LogError($"Index {i} is out of bounds.");
            return null;
        }
    }

}
