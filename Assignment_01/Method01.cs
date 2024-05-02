using UnityEngine;

public class Method01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        // The true value of area by the analytical method / exact solution 

        double trueValueOfArea = 632.795;
        int stepSize = 10;

        HomeWork01Class myFunction1 = new HomeWork01Class(126559, 2, 0, 20, gameObject);
    
        double area_method_1 = myFunction1.AreaUnderCurve_ConstantHeight(stepSize);

        double absoluteError =  myFunction1.AbsoluteError(trueValueOfArea, area_method_1);
        double relativeError =  myFunction1.RelativeError(trueValueOfArea, area_method_1);
        
        Debug.Log($"Area for Method 01 : {area_method_1}");
        Debug.Log($"Absolute Error for Method 01 : {absoluteError}");
        Debug.Log($"Relative Error for Method 01 : {relativeError}");

        myFunction1.PlotFunction();
        
    }
}
