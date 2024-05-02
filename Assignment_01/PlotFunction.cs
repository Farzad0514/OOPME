using UnityEngine;

public class PlotFunction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        HomeWork01Class myFunction1 = new HomeWork01Class(126559, 2, 0, 20, gameObject);
        myFunction1.PlotFunction();
        
    }

}
