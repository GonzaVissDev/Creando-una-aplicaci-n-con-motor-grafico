using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Datos : MonoBehaviour
{
    //Animaciones 
    public Animator Button_Animator;
    public Animator Button_Formula;

    // InputField
    public InputField I_Vo;
    public InputField I_Vf;
    public InputField I_DisX;
    public InputField I_DisY;
    public InputField I_Ax;
    public InputField I_Ay;
    public InputField I_T;
    public InputField I_Vo_Y;
    public InputField I_Vf_Y;
    public InputField I_Ang_x;
    public InputField I_Ang_y;
    // Text 
    public Text Text_vo;
    public Text Text_vf;
    public Text Text_voy;
    public Text Text_vfy;
    public Text Text_disx;
    public Text Text_disy;
    public Text Text_time;
    public Text Text_Ax;
    public Text Text_Ay;
    public Text Text_r;
    public Text Text_d;
    public Text Text_AngleX;
    public Text Text_angleY;
    public Text Warning_Text;

    //Button
    public Button Button_vo;
    public Button Button_vf;
    public Button Button_disx;
    public Button Button_disy;
    public Button Button_time;
    public Button Button_voy;
    public Button Button_vfy;


    //Datos
    public float Vo = 0;
    public float Vf = 0;
    public float Vo_Y = 0;
    public float Vf_Y = 0;
    public float DisX = 0;
    public float DisY = 0;
    public float Ax = 0;
    public float Ay = 9.8f;
    public float T = 0;
    public float Anglex = 0;
    public float angley = 0;
    public float Magnitude = 0;
    public float Direction = 0;
    private string Warning;

    public void Start()
    {
        Button_Animator = GetComponent<Animator>();
        GameObject ButtonObj = GameObject.FindWithTag("SaveButton");

        if (ButtonObj != null)
        {
            Button_Animator = ButtonObj.GetComponent<Animator>();

        }

       Button_Formula = GetComponent<Animator>();
        GameObject FormulaObj = GameObject.FindWithTag("FormulaButton");

        if (FormulaObj != null)
        {Button_Formula= FormulaObj.GetComponent<Animator>();

        }
    }



    // Update is called once per frame
    void Update()
    {
        Text_vo.text = "Velocidad Inicial (X):" + Vo.ToString() + "" + "m/s";
        Text_vf.text = "Velocidad Final (X):" + Vf.ToString() + "" + "m/s";
        Text_voy.text = "Velocidad Inicial(Y):" + Vo_Y.ToString() + "" + "m/s";
        Text_vfy.text = "Velocidad Final (Y):" + Vf_Y.ToString() + "" + "m/s";
        Text_disx.text = "Distancia (X):" + DisX.ToString() + "" + "m";
        Text_disy.text = "Distancia (Y):" + DisY.ToString() + "" + "m";
        Text_time.text = "Tiempo (T):" + T.ToString() + "" + "seg";
        Text_Ax.text = "Aceleración (X):" + Ax.ToString() + "" + "m/s^2";
        Text_Ay.text = "Aceleración (Y):" + Ay.ToString() + "" + "m/s^2";
        Text_r.text = "R:" + "" + Magnitude;
        Text_d.text = "Arc(Tan)" + "" + Direction;
        Text_AngleX.text = "Angluo (x):" + "" + Anglex;
        Text_angleY.text = "Angluo (y):" + "" + angley;

    }
    // Formulas De projectil

    public void Component_Vox()
    {
        if (Anglex > 0)
        {
            float Formula = Projectile.ComponentVox(Vo, Anglex);
            Vo = Formula;
        }
        if (Anglex == 0)
        {
            Warning = "Falta el valor de : Angulo(X)";
        }
    }

    public void Component_Voy()
    {
        if (angley > 0)
        {

            float Formula = Projectile.ComponentVoy(Vo_Y, angley);
            Vo_Y = Formula;

        }
        if (angley == 0)
        {
            Warning = "Falta el valor de : Angulo(X)";
        }
    }

    //Distancia En X
    public void Distance_in_x()
    {
        if (Vo != 0 && T != 0)
        {
            if (DisX == 0)
            {
                float Formula = Projectile.Distance_X(Vo, Ax, T);
                DisX = Formula;
            }
        }
        else
            Warning = "No se conoce el valor de: Velocidad inicial (X) o Tiempo";
        WarningText(Warning);
        if (DisX > 0)
        {
            Warning = "Distancia(X):" + DisX + "" + "m";
            WarningText(Warning);
        }
    }


    //Velocidad Inicial en X
    public void Velocity_In_X()
    {
        if (DisX != 0 && T != 0)
        {
            if (Vo == 0)
            {
                float Formula = Projectile.Velocity_X(DisX, Ax, T);
                Vo = Formula;
            }
        }
        else
            Warning = "No se conoce el valor de: Distancia (X) o Tiempo";
        WarningText(Warning);
        if (Vo > 0)
        {
            Warning = "Velocidad Inicial (x):" + Vo + "" + "m/s";
        }
    }

    //Velocidad Final en X
    public void FinalVelocity_In_X()
    {
        if (Vo != 0 && T != 0)
        {
            if (Vf == 0)
            {
                float Formula = Projectile.Final_Velocity(Vo, Ax, T);
                Vf = Formula;
            }
        }
        else
            Warning = "No se conoce el valor de: Velocidad inicial (X) / Tiempo en X";
        WarningText(Warning);
        if (Vf > 0)
        {
            Warning = "Velocidad Final (x) :" + Vf + "" + "m/s";
            WarningText(Warning);
        }
    }

    // Magnitud Y Direccion 

    public void Magnitude_and_Direction()
    {
        if (Vf != 0 && Vf_Y != 0)
        {
            float R = Projectile.Magnitude(Vf, Vf_Y);
            Magnitude = R;
            Direction = Mathf.Atan2(Vf_Y, Vf);

            Debug.Log("Su magnitud es de : " + Magnitude + "y su direccion" + Direction);
        }
        else
            Warning = "Falta Calcular las Componentes En X o Y";
        WarningText(Warning);
    }

    // Formulas de Caida Libre

    //Distancia en Y
    public void Distance_in_Y()
    {
        if (Ay != 0 && T != 0)
        {
            if (DisY == 0)
            {
                float Formula = CaidaLibre.Distance_Y(Vo_Y, Ay, T);
                DisY = Formula;
            }

        }
        else
            Warning = "No se conoce el valor de: Aceleracion (Y) o Tiempo";
        WarningText(Warning);
        if (DisY > 0)
        {
            Warning = "Distancia (Y):" + DisY + "" + "m";
            WarningText(Warning);
        }
    }

    //Altura Maxima
    public void AlturaMaxima()
    {
      
        if (Vf_Y != 0 && Vo_Y != 0)
        {
           
                float H = CaidaLibre.H_Max(Vf_Y, Vo_Y, Ay);
                Warning = "Altura Maxima:" + H + "m";
            
        }
        else
            Warning = "No se conoce el valor de: Velocidad Final o Inicial (Y)";
        WarningText(Warning);

    }

    //Velocidad Inicial en Y
    public void Initial_Velocity_Y()
    {
        if (DisY != 0 && T != 0)
        {
            if (Vo_Y == 0)
            {
                float Formula = CaidaLibre.Initial_Velocity_Y(DisY, Ay, T);
                Vo_Y = Formula;
            }
        }
        else
            Warning = "No se conoce el valor de: Distancia(Y) o Tiempo";
        WarningText(Warning);

        if (Vo_Y > 0)
        {
            Warning = "Volocidad Inicial(Y):" + Vo_Y + "" + "m/s";
        }
    }


    //Velocidad Final en Y
    public void Final_Velocity_Y()
    {
        if (Ay != 0 && T != 0)
        {
            if (Vf_Y == 0)
            {
                float Formula_Y = CaidaLibre.Final_Velocity_Y(Vo_Y, Ay, T);
                Vf_Y = Formula_Y;
            }

        }
        else
            Warning = "No se conoce el valor de: Aceleracion(Y)  o Tiempo";
        WarningText(Warning);
        if (Vf_Y > 0)
        {
            Warning = "Velocidad Final(Y) :" + Vf_Y + "" + "m/s";
            WarningText(Warning);
        }

    }


    public void Time()
    {
        if (DisY > 0 && T == 0)
        {
            float Time_Formula = CaidaLibre.Time_Y(DisY, Ay);
            T = Time_Formula;

        }
        else
            Warning = "No se conoce el valor de: Distancia(Y)";
        WarningText(Warning);
        if (Vf_Y > 0 && Ay > 0)
        {
            float Time_Formula = CaidaLibre.Time(Vf_Y, Vo_Y, Ay);
            T = Time_Formula;
        }
        else
            Warning = "No se conoce el valor de: Velocidad Final (Y)";
        WarningText(Warning);
        if (T > 0)
        {
            Warning = "Tiempo:" + T + "" + "seg";
            WarningText(Warning);
        }
    }

  public void FormulaIn()
    {
        Button_Formula.SetBool("In", true);
    }
    public void Formulaout()
    {
        Button_Formula.SetBool("In", false);
    }


    public void SaveInfo()
    {

        // Guardo los datos que ingreso el usuario en el input.


        if (I_Vo.text != "")
        {
            Vo = float.Parse(I_Vo.text);
        }
        if (I_Vf.text != "")
        {
            Vf = float.Parse(I_Vf.text);
        }
        if (I_Vo_Y.text != "")
        {
            Vo_Y = float.Parse(I_Vo_Y.text);
        }
        if (I_Vf_Y.text != "")
        {
            Vf_Y = float.Parse(I_Vf_Y.text);
        }
        if (I_Ay.text != "")
        {
            Ay = float.Parse(I_Ay.text);
        }
        if (I_Ax.text != "")
        {
            Ax = float.Parse(I_Ax.text);
        }
        if (I_DisY.text != "")
        {
            DisY = float.Parse(I_DisY.text);
        }
        if (I_DisX.text != "")
        {
            DisX = float.Parse(I_DisX.text);
        }
        if (I_T.text != "")
        {
            T = float.Parse(I_T.text);
        }
        if (I_Ang_x.text != "")
        {
            Anglex = float.Parse(I_Ang_x.text);

        }
        if (I_Ang_y.text != "")
        {
            angley = float.Parse(I_Ang_y.text);
        }

        Button_Animator.SetBool("Click", true);
    }

    public void EditInfo()
    {
        Button_Animator.SetBool("Click", false);
    }



    public void WarningText(string Message)
    {

        Warning_Text.text = Message;
    }

}