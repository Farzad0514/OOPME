// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using org.mariuszgromada.math.mxparser;
using oompe.lib;
using System;

public class HomeWork01Class
{
    public double trueValue;
    public int numSteps;
    private double registrationNumber;
    private double a;
    private double f;
    private double t1;
    private double t2;

    private double x0;
    private double x1;

    private double y0;
    private double y1;

    private double deltaT;
    private double area;
    private string functionString;
    private GameObject gameObject;
    private FunctionPlotter plotter;

    private Vector2 p1 = new Vector2(0, 0);
    private Vector2 p2 = new Vector2(0, 0);
    private Vector2 p3 = new Vector2(0, 0);
    private Vector2 p4 = new Vector2(0, 0);



    public HomeWork01Class(double registrationNumber, double f, double t1, double t2, GameObject gameObject)
    {
        this.registrationNumber = registrationNumber;
        this.f = f;
        this.t1 = t1;
        this.t2 = t2;
        this.gameObject = gameObject;

        a = this.registrationNumber / 40000;
        functionString = $"f(x)= {a}*x + sin(2*3.14*{this.f}*x)";
        Debug.Log(functionString);

        Function myFunction = new Function(functionString);
        this.plotter = new FunctionPlotter(myFunction, this.t1, this.t2);

    }

    public void PlotFunction()
    {
        this.plotter.Plot(this.gameObject);
    }


    // Function to calculate: f(x) = a*x + sin(2*pi*f*x)
    public double Get_Y_Value(double x)
    {
        return a * x + Mathf.Sin(2 * Mathf.PI * (float)this.f * (float)x);
    }

    // Approach 1: Constant height (y0)
    public double AreaUnderCurve_ConstantHeight(int numSteps)
    {
        double deltaT = (this.t2 - this.t1) / numSteps;
        area = 0;

        for (int i = 0; i < numSteps; i++)
        {
            x0 = this.t1 + (i) * deltaT;
            y0 = Get_Y_Value(x0);
            x1 = x0 + deltaT;

            area += y0 * deltaT;

            p1 = new Vector2((float)x0, 0f);
            p2 = new Vector2((float)x0, (float)y0);
            p3 = new Vector2((float)x1, (float)y0);
            p4 = new Vector2((float)x1, 0f);

            this.plotter.AddLine(p1, p2);
            this.plotter.AddLine(p2, p3);
            this.plotter.AddLine(p3, p4);
            this.plotter.AddLine(p4, p1);
            this.plotter.AdditionalLineColor = Color.red;

        }

        return area;
    }

    // Approach 2: Mean value (average of y0 and y1)
    public double AreaUnderCurve_MeanValue(int numSteps)
    {
        double deltaT = (this.t2 - this.t1) / numSteps;
        area = 0;

        for (int i = 0; i < numSteps; i++)
        {
            x0 = this.t1 + i * deltaT;
            y0 = Get_Y_Value(x0);

            x1 = x0 + deltaT;
            y1 = Get_Y_Value(x1);

            double meanValue = (y0 + y1) / 2;

            area += meanValue * deltaT;

            p1 = new Vector2((float)x0, 0f);
            p2 = new Vector2((float)x0, (float)meanValue);
            p3 = new Vector2((float)x1, (float)meanValue);
            p4 = new Vector2((float)x1, 0f);

            this.plotter.AddLine(p1, p2);
            this.plotter.AddLine(p2, p3);
            this.plotter.AddLine(p3, p4);
            this.plotter.AddLine(p4, p1);
            this.plotter.AdditionalLineColor = Color.green;

        }
        return area;
    }

    // Approach 3: Linear interpolation between two consecutive points
    public double AreaUnderCurve_LinearInterpolation(int numSteps)
    {
        double deltaT = (this.t2 - this.t1) / numSteps;
        double area = 0;

        for (int i = 0; i < numSteps; i++)
        {
            x0 = this.t1 + i * deltaT;
            y0 = Get_Y_Value(x0);

            x1 = x0 + deltaT;
            y1 = Get_Y_Value(x1);

            //Area of Trapezoid = (Sum of parallel sides / 2)  * deltaT 
            double length = (y0 + y1) / 2;

            area += length * deltaT;

            p1 = new Vector2((float)x0, 0f);
            p2 = new Vector2((float)x0, (float)y0);
            p3 = new Vector2((float)x1, (float)y1);
            p4 = new Vector2((float)x1, 0f);

            this.plotter.AddLine(p1, p2);
            this.plotter.AddLine(p2, p3);
            this.plotter.AddLine(p3, p4);
            this.plotter.AddLine(p4, p1);
            this.plotter.AdditionalLineColor = Color.yellow;

        }
        return area;

    }

    public double AbsoluteError(double trueValue, double calculatedValue)
    {
        return Math.Abs(trueValue - calculatedValue);
    }

    public double RelativeError(double trueValue, double calculatedValue)
    {
        return Math.Abs(((trueValue - calculatedValue) / trueValue) * 100);
    }
}



