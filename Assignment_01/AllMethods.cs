using UnityEngine;

public class AllMethods : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        // The true value of area by the analytical method / exact solution 

        double trueValueOfArea = 632.795;
        int stepSize = 200;

        HomeWork01Class myFunction1 = new HomeWork01Class(126559, 2, 0, 20, gameObject);
    
        double area_method_1 = myFunction1.AreaUnderCurve_ConstantHeight(stepSize);
        double area_method_2 = myFunction1.AreaUnderCurve_MeanValue(stepSize);
        double area_method_3 = myFunction1.AreaUnderCurve_LinearInterpolation(stepSize);

        double[] areas = new double[] {area_method_1, area_method_2, area_method_3};

        for (int i = 0; i < areas.Length; i++) 
        {
            double absoluteError =  myFunction1.AbsoluteError(trueValueOfArea, areas[i]);
            double relativeError =  myFunction1.RelativeError(trueValueOfArea, areas[i]);
            
            Debug.Log($"Area for Method {i+1} : {areas[i]}");
            Debug.Log($"Absolute Error for Method {i+1} : {absoluteError}");
            Debug.Log($"Relative Error for Method {i+1} : {relativeError}");
        }

        // myFunction1.PlotFunction();
        
    }
}
