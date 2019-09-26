using UnityEngine;
using System.Collections;

public class PichMouseOver : MonoBehaviour {
	public Transform Sphere;
	public float v;
	float StartTime;
	public bool MoveTrigger;
	public Vector3 StartPos;
	public Transform StopPos;
	public SphereSwitcher Switcher;
    public MultiExperience MultiEx;
    public MainCalculation MainCalc;
    public bool LetsPichIt;
    public bool InSimulation = false;
    // Use this for initialization
    void Start () {
        InSimulation = false;
    }
	
	// Update is called once per frame
	void Update () {
	if (MoveTrigger) {

			StartMove();
				}
    if(!InSimulation)
        {        
        if (Sphere.position.y < 0.7f && 0.6f < Sphere.position.y)
        {
            LetsPichIt = true;
        }
        else
        {
            LetsPichIt = false;
        }
        }
	}
	void OnMouseDown() {
        if (LetsPichIt)
        {
            Data2Dt();
            MultiEx.OneExFinished = true;
            GetComponent<TweenRotation>().PlayForward();
            MoveTrigger = true;
            LetsPichIt = false;

            GameObject.Find("FirstGage").GetComponent<GageStartTimer>().MainTime = 0f;
            GameObject.Find("LTimer").GetComponent<UILabel>().text = null;
            
        }


	}

    void Data2Dt()
    {
        
        var time = GameObject.Find("FirstGage").GetComponent<GageStartTimer>().MainTime;
        var Tv = MainCalc.CustomTerminalVelocity(time);

        MultiEx.AVGcd += MainCalc.CustomCd(Tv);
        MultiEx.AVGre += MainCalc.CustomRe(Tv);
        MultiEx.AVGtime += time;
        MultiEx.AVGvelocity += Tv;
        MultiEx.AVGviscosity += MainCalc.CustomViscosity(Tv);
        if (time==0)
        {
            MultiEx.dt.Rows[0][MultiEx.CurrentEx + 1] = 0;
            MultiEx.dt.Rows[1][MultiEx.CurrentEx + 1] = 0;
            MultiEx.dt.Rows[2][MultiEx.CurrentEx + 1] = 0;
            MultiEx.dt.Rows[3][MultiEx.CurrentEx + 1] = 0;
            MultiEx.dt.Rows[4][MultiEx.CurrentEx + 1] = 0;
        }
        else
        {
            MultiEx.dt.Rows[0][MultiEx.CurrentEx + 1] = time;
            MultiEx.dt.Rows[1][MultiEx.CurrentEx + 1] = Tv;
            MultiEx.dt.Rows[2][MultiEx.CurrentEx + 1] = MainCalc.CustomRe(Tv);
            MultiEx.dt.Rows[3][MultiEx.CurrentEx + 1] = MainCalc.CustomCd(Tv);
            MultiEx.dt.Rows[4][MultiEx.CurrentEx + 1] = MainCalc.CustomViscosity(Tv);
        }

    }

    void StartMove ()
	{
		var distCovered = (Time.time - StartTime) * v;
		// Fraction of journey completed = current distance divided by total distance.
		var fracJourney = distCovered / 0.1f;
		// Set our position as a fraction of the distance between the markers.
		Sphere.position = Vector3.Lerp (Sphere.position, StopPos.position, v * Time.deltaTime);
        
		if (Sphere.position == StopPos.position) {
			MoveTrigger = false;
			Switcher.EnableSphereAnchor = true;
				}
	}
}
