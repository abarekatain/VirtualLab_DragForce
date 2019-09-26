using UnityEngine;
using System.Collections;

public class MainCalculation : MonoBehaviour {
	public float Viscosity = 0.1f,GDensity = 1260f,GY,SD = 0.00393f,SY = 78600f,Distance = 1f,T=20f,TravelTime,CD,TerminalVelocity,Re,Density;
    public float Viscosity1 = 0.1f, GDensity1 = 1260f, GY1, SD1 = 0.00393f, SY1 = 78600f, Distance1 = 1f, T1 = 20f, TravelTime1, CD1, TerminalVelocity1, Re1, Density1;
    public int Purity,Purity1;
    public float SphereFallingDistance;
	public bool OneTimeConfig = false;
	public bool OneTimeSimulate1 = false;
    public bool OneTimeSimulate2 = false;
    public bool OneTimeSimulate3 = false;
    float StartTime;
	public Transform FirstGage,LastGage,Sphere;
    float FluidEntranceTime = 0;
    public bool TimeCounterTrigger;

    public float XDis, XDis1;

	// Use this for initialization
	void Start () {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height,false);
        QualitySettings.SetQualityLevel(1);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if (OneTimeConfig) {
			Config();
            Config1();
			OneTimeConfig  = false;
            
				}
		if (OneTimeSimulate1) {
            //Sphere.rigidbody.isKinematic = false;
             Sphere.rigidbody.useGravity = true;
            
        }
        else if (!OneTimeSimulate1)
        {
            Sphere.rigidbody.useGravity = false;
        }
        if (OneTimeSimulate2)
        {
            StartMovement();
        }
        if (OneTimeSimulate3)
        {
            StartMovement1();   
        }
        if (TimeCounterTrigger)
        {
            FluidEntranceTime += Time.deltaTime;
        }
        else if (!TimeCounterTrigger)
        {
            FluidEntranceTime = 0;
        }

        XDis = Mathf.Abs(GameObject.Find("FirstGage").transform.position.y - 1.54f);
        XDis1 = Mathf.Abs(GameObject.Find("LastGage").transform.position.y - 1.54f);



    }

	float GetViscosity()
	{
		float Cm = Purity / 100f;
		float a = 0.705f - 0.0017f * T;
		float b = (4.9f + 0.036f * T) * (Mathf.Pow(a,2.5f	));
		float Alpha = 1f - Cm + (a * b * Cm * (1f - Cm)) / (a * Cm + b * (1f- Cm));
		float Uw = 1.79f* Mathf.Exp (((-1230f + T) * T) / (36100f + 360f * T));
		float Ug = 12100f * Mathf.Exp (((-1233f + T) * T) / (9900f + 70f * T));
		return (((Mathf.Pow(Uw,Alpha)) * (Mathf.Pow (Ug, (1f - Alpha))))/1000);

	}
    float GetViscosity1()
    {
        float Cm = Purity1 / 100f;
        float a = 0.705f - 0.0017f * T;
        float b = (4.9f + 0.036f * T) * (Mathf.Pow(a, 2.5f));
        float Alpha = 1f - Cm + (a * b * Cm * (1f - Cm)) / (a * Cm + b * (1f - Cm));
        float Uw = 1.79f * Mathf.Exp(((-1230f + T) * T) / (36100f + 360f * T));
        float Ug = 12100f * Mathf.Exp(((-1233f + T) * T) / (9900f + 70f * T));
        return (((Mathf.Pow(Uw, Alpha)) * (Mathf.Pow(Ug, (1f - Alpha)))) / 1000);

    }

    public void Config ()
	{
		Viscosity = GetViscosity ();
		Density = GetDensity();
		GY = Density * 9.8f;
		TerminalVelocity = (((SD * SD) * GY) * (SY / GY - 1f)) / (18f * Viscosity);
		Re = (Density * TerminalVelocity * SD) / Viscosity;

        if (Re >= 1) {
			Debug.Log ("ReynoldsError");
		}
		CD = (4f * SD * (SY / GY - 1f) * 9.8f) / (3f * (TerminalVelocity * TerminalVelocity));
		Re = 24 / CD;
        
		TravelTime = Distance / TerminalVelocity;

	}

    public void Config1()
    {
        Viscosity1 = GetViscosity1();
        Density1 = GetDensity1();
        GY1 = Density1 * 9.8f;
        TerminalVelocity1 = (((SD * SD) * GY1) * (SY / GY1 - 1f)) / (18f * Viscosity1);
        Re1 = (Density1 * TerminalVelocity1 * SD) / Viscosity1;

        if (Re >= 1)
        {
            Debug.Log("ReynoldsError");
        }
        CD1 = (4f * SD * (SY / GY1 - 1f) * 9.8f) / (3f * (TerminalVelocity1 * TerminalVelocity1));


        TravelTime = Distance / TerminalVelocity;

    }

    void StartMovement ()
	{

        //Sphere.transform.Translate(new Vector3(0, -TerminalVelocity*Time.deltaTime, 0));
        Sphere.rigidbody.velocity = new Vector3(0,-TerminalVelocity,0);
		if (Sphere.position == LastGage.position) {
			OneTimeConfig = false;
			OneTimeSimulate2 = false;

				}
	}

    void StartMovement1()
    {


        //Sphere.transform.Translate(new Vector3(0, -TerminalVelocity*Time.deltaTime, 0));
        Sphere.rigidbody.velocity = new Vector3(0, -TerminalVelocity1, 0);
        if (Sphere.position == LastGage.position)
        {
            OneTimeConfig = false;
            OneTimeSimulate2 = false;
            OneTimeSimulate3 = false;
        }
    }
    float GetDensity()
	{
		float Cm = Purity / 100f;
		return ((1000 * GDensity) / ((GDensity * (1 - Cm)) + (1000 * Cm)));
	}

    float GetDensity1()
    {
        float Cm = Purity1 / 100f;
        return ((1000 * GDensity) / ((GDensity * (1 - Cm)) + (1000 * Cm)));
    }

    float RealTimeVelocity(float t)
    {
        
        float a = -1.6316e-6f;
        float b = 6.065e-6f * CD;
        float c = -19.731e-8f;
        float d = Mathf.Sqrt(2f * 9.81f * SphereFallingDistance);
        Debug.Log(a);
        Debug.Log(b);
        Debug.Log(c);
        Debug.Log(d);
        return (-Mathf.Sqrt(a) * Mathf.Pow((1f / Mathf.Cos((Mathf.Sqrt(a) * Mathf.Sqrt(b) * t - c * Mathf.Atan(Mathf.Sqrt(b) * d / Mathf.Sqrt(a))) / c)),2) * Mathf.Tan((Mathf.Sqrt(a) * Mathf.Sqrt(b) * t - c * Mathf.Atan(Mathf.Sqrt(b) * d / Mathf.Sqrt(a))) / c) / (Mathf.Sqrt(b) * (Mathf.Pow(Mathf.Tan((Mathf.Sqrt(a) * Mathf.Sqrt(b) * t - c * Mathf.Atan(Mathf.Sqrt(b) * d / Mathf.Sqrt(a))) / c),2) + 1f)));


    }


    public float CustomTerminalVelocity(float time)
    {
        return Distance/time;
    }

    public float CustomViscosity(float Tv)
    {
        return (((SD * SD) * GY) * (SY / GY - 1f)) / (18f * Tv);
    }
    public float CustomCd(float Tv)
    {
         return (4f * SD * (SY / GY - 1f) * 9.8f) / (3f * (Tv  * Tv));  
    }
    public float CustomRe(float Tv)
    {
        return (24 / CustomCd(Tv));
    }


}
