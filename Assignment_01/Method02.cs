using UnityEngine;

public class Method02 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        // The true value of area by the analytical method / exact solution 
        double trueValueOfArea = 632.795;
        int stepSize = 10;

        HomeWork01Class myFunction1 = new HomeWork01Class(126559, 2, 0, 20, gameObject);
    
        double area_method_2 = myFunction1.AreaUnderCurve_MeanValue(stepSize);
        double absoluteError =  myFunction1.AbsoluteError(trueValueOfArea, area_method_2);
        double relativeError =  myFunction1.RelativeError(trueValueOfArea, area_method_2);
        
        Debug.Log($"Area for Method 02 : {area_method_2}");
        Debug.Log($"Absolute Error for Method 02 : {absoluteError}");
        Debug.Log($"Relative Error for Method 02 : {relativeError}");


        myFunction1.PlotFunction();
        
    }
}
