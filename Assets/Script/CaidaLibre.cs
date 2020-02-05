using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaLibre : MonoBehaviour
{
    public static float Final_Velocity_Y (float Vy,float A,float T) {
        float Vf = Vy + (A * T);
        return Vf;
    }
    public static float Distance_Y(float Vo, float A, float T)
    {
        float Disy = (Vo * T)+ (0.5f * A * Mathf.Pow(T,2));
        return Disy;
    }
    public static float Time_Y(float Dis_Y, float Ay)
    {
       float timey = Mathf.Sqrt((2 * Dis_Y )/ Ay);
       return timey;
    }
    public static float Time(float Vy,float Voy,float Ay)
    {
        float TimeWhitVelocity = Vy - Voy/ Ay;
        return TimeWhitVelocity;
       
    }
    public static float H_Max(float Vy, float voy, float a)
   {
        float H = (Mathf.Sqrt(Mathf.Pow(Vy, 2)) - Mathf.Sqrt(Mathf.Pow(voy, 2)) / 2 * a);
        return H;
    }



    public static float Initial_Velocity_Y(float DisY, float A, float T)
    {
        float Vo = DisY/T - 0.5f*A*T;
        return Vo;
    }


}
