using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
  public static float ComponentVox (float vx, float angle)
    {
        float Cvx = vx * Mathf.Cos(angle);
        return Cvx;
    }
    public static float ComponentVoy(float vy, float angle)
    {
        float Cvy = vy * Mathf.Sin(angle);
        return Cvy;
    }

   
    public static float Distance_X(float Vo, float A, float T)
    {
        float Disx = (Vo * T) + (0.5f * A * Mathf.Pow(T, 2));
        return Disx;
    }

    public static float Velocity_X(float Dis_X,float Ax,float T)
    {
        float Vox = Dis_X / T;
        return Vox;
    }

    public static float Final_Velocity(float Vo, float A, float T)
    {
        float Vf = Vo + (A * T);
        return Vf;
    }
    public static float Magnitude(float vx, float vy)
    {
        float R = Mathf.Sqrt(Mathf.Pow(vx, 2) + Mathf.Pow(vy, 2));
        return R;
    }
}
