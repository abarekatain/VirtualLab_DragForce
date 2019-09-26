using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using System.Data;
using System.Runtime.InteropServices;

public class MenuOptions : MonoBehaviour {
    // public List<Vector2> Vecs;
    
    public MainCalculation Mc;
	public Transform MainCam;
	public Transform CamOriginalPosition;
	public Transform SphereLookPos;
	public bool SphereZoomInTrigger = false;
	public bool SphereZoomOutTrigger = false;
	public bool SphereRotation = false;
	public float smoothTime = 0.3F;
	public float SphereRotSpeed = 5;
	private Vector3 velocity = Vector3.zero;
	private float RotVelocity = 0;
	public Transform Sphere;
	public Transform OrbitTarget;
	public SphereSwitcher Switcher;
	public MainCalculation MainCalc;

	public bool DistanceZoomInTrigger = false;
	public bool DistanceZoomOutTrigger = false;
	public Transform DistanceLookPos;
	public Transform DistanceLookAtTarget;
	public Transform StartGage;
	public Transform LiquidSurface;
	public Transform FirstGage;
	public Transform LastGage;
    public MultiExperience MultiEx;
    public PichMouseOver PichOver;

    public UIPanel PSphere;
    public WMG_Axis_Graph Wag;
    public WMG_Series Ws;
    public int XAxis, YAxis;
    public UISprite[] GuidePages;


    public TweenAlpha ReError;
    public TweenAlpha ReWarning;
    public TweenAlpha ReWarningSi;
    public TweenAlpha SExCount;
    public TweenAlpha PsiResult;

    public TweenAlpha PExRes;
   public TweenAlpha ExportSuccess;
   public TweenAlpha ExportFailed;

    public GameObject VWarning;


    public float a, b, c;


    [DllImport("user32.dll")]
    private static extern void SaveFileDialog(); //in your case : OpenFileDialog









    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void LateUpdate () {
	if (SphereZoomInTrigger) {
	
			MainCam.position = Vector3.SmoothDamp(MainCam.position, SphereLookPos.position, ref velocity, smoothTime);

			MainCam.camera.orthographicSize = Mathf.SmoothDamp(MainCam.camera.orthographicSize,0.2f,ref RotVelocity,smoothTime);
			MainCam.LookAt(Sphere);


		}
	else if (SphereZoomOutTrigger) {
			MainCam.position = Vector3.SmoothDamp(MainCam.position, CamOriginalPosition.position, ref velocity, smoothTime);

			MainCam.camera.orthographicSize = Mathf.SmoothDamp(MainCam.camera.orthographicSize, 1.77f, ref RotVelocity,smoothTime);
			MainCam.LookAt(OrbitTarget);

		}
		if (SphereRotation) {
			Sphere.Rotate(0,0,SphereRotSpeed * Time.deltaTime);
		}
		if (DistanceZoomInTrigger) {
			MainCam.position = Vector3.SmoothDamp(MainCam.position, DistanceLookPos.position, ref velocity, smoothTime);

			MainCam.camera.orthographicSize = Mathf.SmoothDamp(MainCam.camera.orthographicSize,2.17f,ref RotVelocity,smoothTime);
			MainCam.LookAt(DistanceLookAtTarget);
				}
		if (DistanceZoomOutTrigger) {
			MainCam.position = Vector3.SmoothDamp(MainCam.position, CamOriginalPosition.position, ref velocity, smoothTime);

			MainCam.camera.orthographicSize = Mathf.SmoothDamp(MainCam.camera.orthographicSize, 1.77f, ref RotVelocity,smoothTime);
			MainCam.LookAt(OrbitTarget);
				}




        if(PSphere.alpha == 1)
        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
           var pp = GameObject.Find("PPSphere").GetComponent<UIPopupList>();


            if (pp.value == pp.items[0].ToString())
            {
                pp.value = pp.items[1].ToString();
            }
            else if (pp.value == pp.items[1].ToString())
            {
                pp.value = pp.items[2].ToString();
            }
            else if (pp.value == pp.items[2].ToString())
            {
                pp.value = pp.items[3].ToString();

            }
            else if (pp.value == pp.items[3].ToString())
            {
                pp.value = pp.items[4].ToString();
            }

        }
       else if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            var pp = GameObject.Find("PPSphere").GetComponent<UIPopupList>();

            if (pp.value == pp.items[1].ToString())
            {
                pp.value = pp.items[0].ToString();
            }
            else if (pp.value == pp.items[2].ToString())
            {
                pp.value = pp.items[1].ToString();

            }
            else if (pp.value == pp.items[3].ToString())
            {
                pp.value = pp.items[2].ToString();
            }
            else if (pp.value == pp.items[4].ToString())
            {
                pp.value = pp.items[3].ToString();
            }
        }
    }
	public void Exit()
	{
		Application.Quit ();
	}
	public void GetSphereData(UIPopupList pp,UILabel Dlabel,UILabel Ylabel)
	{
		if (pp.value == pp.items[0].ToString()) {
			Mc.SD = 0.00945f;
			Mc.SY = 78600f;
			Dlabel.text = "9.45";
			Ylabel.text = "78600";
			Switcher.SphereIndex = 0;
				}
		else if (pp.value == pp.items[1].ToString()) {
			Mc.SD = 0.0079f;
			Mc.SY = 78600f;
			Dlabel.text = "7.9";
			Ylabel.text = "78600";
			Switcher.SphereIndex = 1;
		}
		else if (pp.value == pp.items[2].ToString()) {
			Mc.SD = 0.00393f;
			Mc.SY = 78600f;
			Dlabel.text = "3.93";
			Ylabel.text = "78600";
			Switcher.SphereIndex = 2;

		}
		else if (pp.value == pp.items[3].ToString()) {
			Mc.SD = 0.00648f;
			Mc.SY = 24600f;
			Dlabel.text = "6.48";
			Ylabel.text = "24600";
			Switcher.SphereIndex = 3;
		}
		else if (pp.value == pp.items[4].ToString()) {
			Mc.SD = 0.00653f;
			Mc.SY = 22600f;
			Dlabel.text = "6.53";
			Ylabel.text = "22600";
			Switcher.SphereIndex = 4;
		}

	}
	public void GetFluidPurity(UIPopupList pp)
	{
		Mc.Purity = int.Parse (pp.value);

	}

    public void GetFluidPurity1(UIPopupList pp)
    {
        Mc.Purity1 = int.Parse(pp.value);

    }
    public void GetFluidTemperature (UIInput txt)
	{
		if (txt.value.Trim() != "") {
            if (txt.value == "-")
            {
                txt.value = "0";
                Mc.T = float.Parse(txt.value);
            }
            else if (float.Parse(txt.value) >= 0f && float.Parse(txt.value) <= 50f)
            {
                Mc.T = float.Parse(txt.value);
            }
            else if (float.Parse(txt.value) > 50f)
            {
                txt.value = "50";
                Mc.T = float.Parse(txt.value);
            }
        }
        else
        {
            Mc.T = 0f;
        }
    }
	public void SphereZoomIn()
	{
		SphereZoomInTrigger = true;
		SphereRotation = true;
		//SphereZoomOutTrigger = false;
		MainCam.gameObject.GetComponent<MouseOrbit> ().enabled = false;
	}
	public void SphereZoomOut()
	{
		SphereZoomInTrigger = false;
		SphereZoomOutTrigger = true;
		SphereRotation = false;
		MainCam.gameObject.GetComponent<MouseOrbit> ().enabled = true;
		MainCam.GetComponent<MouseOrbit> ().dist = 1.53f;
	}
	public void FinishSphereZoom()
	{
		SphereZoomOutTrigger = false;
	}




	public void DistanceZoomIn()
	{
		DistanceZoomInTrigger = true;
		//SphereZoomOutTrigger = false;
		MainCam.gameObject.GetComponent<MouseOrbit> ().enabled = false;
	}
	public void DistanceZoomOut()
	{
		DistanceZoomInTrigger = false;
		DistanceZoomOutTrigger = true;
		MainCam.gameObject.GetComponent<MouseOrbit> ().enabled = true;
		MainCam.GetComponent<MouseOrbit> ().dist = 1.53f;
        StartCoroutine(MyMethodName());



    }
	public void FinishDistanceZoom()
	{
		DistanceZoomOutTrigger = false;
	}
    
	public void SetABDistance(UIInput pp)
	{


            if (pp.value.Trim() != "")
        {
             if (pp.value == "-")
                {
                     pp.value = "0";
                     StartGage.position = LiquidSurface.position + new Vector3(0, float.Parse(pp.value) / 100, 0);
                     MainCalc.SphereFallingDistance = float.Parse(pp.value) / 100f;
                }
            else if (float.Parse(pp.value) >= 0f && float.Parse(pp.value) <= 100f)
                    {
                StartGage.position = LiquidSurface.position + new Vector3(0, float.Parse(pp.value) / 100, 0);
                MainCalc.SphereFallingDistance = float.Parse(pp.value) / 100f;
                    }



            else if (float.Parse(pp.value) > 100f)
            {
                pp.value = "100";
                StartGage.position = LiquidSurface.position + new Vector3(0, float.Parse(pp.value) / 100, 0);
                MainCalc.SphereFallingDistance = float.Parse(pp.value) / 100f;
            }

        }
            else
            {
                StartGage.position = LiquidSurface.position + new Vector3(0, 0, 0);
                MainCalc.SphereFallingDistance = 0;
            }

        GetTerminalDistance();

	}
	public void SetBCDistance(UIInput pp)
	{
       
        if (pp.value.Trim() != "") {
                if (pp.value == "-")
                    {
                         pp.value = "0";
                         FirstGage.position = LiquidSurface.position - new Vector3(0, float.Parse(pp.value) / 100, 0);
                    }
                else if (float.Parse(pp.value) >= 0f && float.Parse(pp.value) <= 170f)
                    {
                         FirstGage.position = LiquidSurface.position - new Vector3(0, float.Parse(pp.value) / 100, 0);
                    }

                else if (float.Parse(pp.value) > 170f)
                    {
                         pp.value = "170";
                         FirstGage.position = LiquidSurface.position - new Vector3(0, float.Parse(pp.value) / 100, 0);
                    }

            
		}
		    else
                 {
			FirstGage.position = LiquidSurface.position + new Vector3 (0, 0, 0);
		         }
        SetCDDistance(GameObject.Find("TxtCD").GetComponent<UIInput>());
    }
	public void SetCDDistance(UIInput pp)
	{
		if (pp.value.Trim() != "") {
                if (pp.value == "-")
                    {
                        pp.value = "0";
                        LastGage.position = FirstGage.position - new Vector3(0, float.Parse(pp.value) / 100f, 0);
                        Mc.Distance = float.Parse(pp.value)/100f;
                    }
                else if (float.Parse(pp.value) >= 0f && float.Parse(pp.value) <= ((1.75f - (LiquidSurface.position.y - FirstGage.position.y)) * 100))
                    {
                        LastGage.position = FirstGage.position - new Vector3(0, float.Parse(pp.value) / 100f, 0);
                        Mc.Distance = float.Parse(pp.value)/100f;
                    }

               else if (float.Parse(pp.value) > ((1.75f - (LiquidSurface.position.y - FirstGage.position.y)) * 100))
                    {
                        pp.value = ((1.75f - (LiquidSurface.position.y - FirstGage.position.y))*100).ToString();
                        LastGage.position = FirstGage.position - new Vector3(0, float.Parse(pp.value) / 100f, 0);
                        Mc.Distance = float.Parse(pp.value)/100f;
                    }
            
            
        }
		else {
			LastGage.position = FirstGage.position + new Vector3 (0, 0, 0);
            MainCalc.Distance = 0f;
        }
		
	}

	public void Simulate()
	{

		Switcher.DisableSphereAnchor = true;
		MainCalc.OneTimeConfig = true;
		MainCalc.OneTimeSimulate1 = true;
	}

    public void EnableSphereAnchor()
    {
        GameObject.Find("BResult").GetComponent<UISprite>().enabled = false;
        GameObject.Find("BResult").GetComponentInChildren<UILabel>().enabled = false;
        GameObject.Find("BNext").GetComponent<UISprite>().enabled = false;
        GameObject.Find("BNext").GetComponentInChildren<UILabel>().enabled = false;
        Switcher.EnableSphereAnchor = true;
        GameObject.Find("FirstGage").GetComponent<GageStartTimer>().MainTime = 0f;
        GameObject.Find("LTimer").GetComponent<UILabel>().text = null;
        GameObject.Find("FirstGage").GetComponent<GageStartTimer>().TimerTrigger = false;
        GameObject.Find("Operator").GetComponent<MultiExperience>().ExsFinished = false;
        GameObject.Find("Operator").GetComponent<MultiExperience>().CurrentEx = 0;
        MultiEx.AVGcd = 0;
        MultiEx.AVGre = 0;
        MultiEx.AVGtime = 0;
        MultiEx.AVGvelocity = 0;
        MultiEx.AVGviscosity = 0;
    }

    public void ShowFinalResults()
    {
        MultiEx.AVGcd /= MultiEx.ExCount;
        MultiEx.AVGre /= MultiEx.ExCount;
        MultiEx.AVGtime /= MultiEx.ExCount;
        MultiEx.AVGvelocity /= MultiEx.ExCount;
        MultiEx.AVGviscosity /= MultiEx.ExCount;

        //GameObject.Find("LCd").GetComponent<UILabel>().text = MultiEx.AVGcd.ToString();
        //GameObject.Find("LAlpha").GetComponent<UILabel>().text = MainCalc.Viscosity.ToString();
        //var TheTime = GameObject.Find("FirstGage").GetComponent<GageStartTimer>().MainTime;
        //if (TheTime != 0)
        //{
          //  GameObject.Find("LV").GetComponent<UILabel>().text = MultiEx.AVGvelocity.ToString();
        //}
        //else if (TheTime == 0)
        //{
        //    GameObject.Find("LV").GetComponent<UILabel>().text = "--------";

        //}

       // GameObject.Find("LRe").GetComponent<UILabel>().text = MultiEx.AVGre.ToString();


        //var path = EditorUtility.SaveFilePanel(
        //    "Save Results",
        //    "",
        //    "Results.xls",
        //    "xls");




        //MultiEx.ToExcel(MultiEx.dt);
    }

    public void SetInputFocus(UIInput Inp)
    {
        Inp.isSelected = true;
        
    }


    IEnumerator MyMethodName()
    {

        var a = Switcher.SphereIndex;
        Switcher.SphereIndex = 0;
        yield return new WaitForSeconds(0.02f);
        Switcher.SphereIndex = 1;
        yield return new WaitForSeconds(0.02f);
        Switcher.SphereIndex = 2;
        yield return new WaitForSeconds(0.02f);
        Switcher.SphereIndex = 3;
        yield return new WaitForSeconds(0.02f);
        Switcher.SphereIndex = 4;
        yield return new WaitForSeconds(0.02f);
         Switcher.SphereIndex = a;
    }

    public void PExResultsPanelConfig(UIPopupList SpherePP,UILabel SphereD,UILabel SphereY)
    {
        GameObject.Find("LSphereType").GetComponent<UILabel>().text = SpherePP.value;
        GameObject.Find("LSphereDia").GetComponent<UILabel>().text = SphereD.text;
        GameObject.Find("LSphereSpecilicGravity").GetComponent<UILabel>().text = SphereY.text;
        GameObject.Find("LFluidDensty").GetComponent<UILabel>().text = MainCalc.GDensity.ToString();
        GameObject.Find("LFluidTemp").GetComponent<UILabel>().text = MainCalc.T.ToString();
        GameObject.Find("LFluidPer").GetComponent<UILabel>().text = MainCalc.Purity.ToString();
        
        GameObject.Find("LDisFromTop").GetComponent<UILabel>().text = (MainCalc.SphereFallingDistance*100).ToString();
        GameObject.Find("LDisBetweenTwoGage").GetComponent<UILabel>().text = (MainCalc.Distance*100).ToString();
        if (MultiEx.AVGre > 10000)
        {
            GameObject.Find("LReNumber").GetComponent<UILabel>().text = "0";
            GameObject.Find("LTerminalVelocity").GetComponent<UILabel>().text = "0";

        }
        else
        {
            GameObject.Find("LReNumber").GetComponent<UILabel>().text = MultiEx.AVGre.ToString();
            GameObject.Find("LTerminalVelocity").GetComponent<UILabel>().text = MultiEx.AVGvelocity.ToString();
        }
        
        GameObject.Find("LDragCeo").GetComponent<UILabel>().text = MultiEx.AVGcd.ToString();
        
        GameObject.Find("LFluidViscosity").GetComponent<UILabel>().text = MultiEx.AVGviscosity.ToString();
    }

    public void PSiResultsPanelConfig(UIPopupList SpherePP, UILabel SphereD, UILabel SphereY)
    {
        GameObject.Find("LSphereType1").GetComponent<UILabel>().text = SpherePP.value;
        GameObject.Find("LSphereDia1").GetComponent<UILabel>().text = SphereD.text;
        GameObject.Find("LSphereSpecilicGravity1").GetComponent<UILabel>().text = SphereY.text;
        GameObject.Find("LFluidDensty1").GetComponent<UILabel>().text = MainCalc.GDensity.ToString();
        GameObject.Find("LFluidTemp1").GetComponent<UILabel>().text = MainCalc.T.ToString();
        GameObject.Find("LFluidPer1").GetComponent<UILabel>().text = MainCalc.Purity.ToString();
        GameObject.Find("LDisFromTop1").GetComponent<UILabel>().text = (MainCalc.SphereFallingDistance * 100).ToString();
        GameObject.Find("LDisBetweenTwoGage1").GetComponent<UILabel>().text = (MainCalc.Distance * 100).ToString();

        GameObject.Find("LReNumber1").GetComponent<UILabel>().text = MainCalc.Re.ToString();
        GameObject.Find("LDragCeo1").GetComponent<UILabel>().text = MainCalc.CD.ToString();
        GameObject.Find("LTerminalVelocity1").GetComponent<UILabel>().text = MainCalc.TerminalVelocity.ToString();
        GameObject.Find("LFluidViscosity1").GetComponent<UILabel>().text = MainCalc.Viscosity.ToString();
        GameObject.Find("LTime1").GetComponent<UILabel>().text = (MainCalc.XDis / MainCalc.TerminalVelocity).ToString();


        GameObject.Find("LReNumber2").GetComponent<UILabel>().text = MainCalc.Re1.ToString();
        GameObject.Find("LDragCeo2").GetComponent<UILabel>().text = MainCalc.CD1.ToString();
        GameObject.Find("LTerminalVelocity2").GetComponent<UILabel>().text = MainCalc.TerminalVelocity1.ToString();
        GameObject.Find("LFluidViscosity2").GetComponent<UILabel>().text = MainCalc.Viscosity1.ToString();
        GameObject.Find("LTime2").GetComponent<UILabel>().text = (MainCalc.XDis1 / MainCalc.TerminalVelocity1).ToString();
    }



    public void ExportTheExcelFile()
    {
        System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();

        saveFileDialog1.Filter = "Excel File|*.xls";
        saveFileDialog1.Title = "Save Excel Export";
        saveFileDialog1.ShowDialog();

        // If the file name is not an empty string open it for saving.
        if (saveFileDialog1.FileName != "")
        {
            MultiEx.ToExcel(MultiEx.dt,saveFileDialog1.FileName);
        }


            
    }

    public void SetXAxis(UIPopupList pp)
    {
        
        if (pp.value == pp.items[0].ToString())
        {
            XAxis = 4;
            Wag.xAxisMinValue = (int)MultiEx.AVGviscosity - 0.5f;
            Wag.xAxisMaxValue = (int)MultiEx.AVGviscosity + 1.5f;
            FPlot(XAxis, YAxis, MultiEx.dt);

        }
        else if (pp.value == pp.items[1].ToString())
        {
            XAxis = 3;
            Wag.xAxisMinValue = (int)MultiEx.AVGcd - 0.5f;
            Wag.xAxisMaxValue = (int)MultiEx.AVGcd + 1.5f;
            FPlot(XAxis, YAxis, MultiEx.dt);
        }
        else if (pp.value == pp.items[2].ToString())
        {
            XAxis = 2;
            Wag.xAxisMinValue = (int)MultiEx.AVGre - 0.5f;
            Wag.xAxisMaxValue = (int)MultiEx.AVGre + 1.5f;
            FPlot(XAxis, YAxis, MultiEx.dt);
        }
        else if (pp.value == pp.items[3].ToString())
        {
            XAxis = 1;
            Wag.xAxisMinValue = (int)MultiEx.AVGvelocity - 0.5f;
            Wag.xAxisMaxValue = (int)MultiEx.AVGvelocity + 1.5f;
            FPlot(XAxis, YAxis, MultiEx.dt);
        }
        else if (pp.value == pp.items[4].ToString())
        {
            XAxis = 0;
            Wag.xAxisMinValue = (int)MultiEx.AVGtime - 0.5f;
            Wag.xAxisMaxValue = (int)MultiEx.AVGtime + 1.5f;
            FPlot(XAxis, YAxis, MultiEx.dt);
        }

    }


    public void SetYAxis(UIPopupList pp)
    {
        if (pp.value == pp.items[0].ToString())
        {
            YAxis = 4;
            Wag.yAxisMinValue = (int)MultiEx.AVGviscosity - 0.5f;
            Wag.yAxisMaxValue = (int)MultiEx.AVGviscosity + 1.5f;

        }
        else if (pp.value == pp.items[1].ToString())
        {
            YAxis = 3;
            Wag.yAxisMinValue = (int)MultiEx.AVGcd - 0.5f;
            Wag.yAxisMaxValue = (int)MultiEx.AVGcd + 1.5f;
        }
        else if (pp.value == pp.items[2].ToString())
        {
            YAxis = 2;
            Wag.yAxisMinValue = (int)MultiEx.AVGre - 0.5f;
            Wag.yAxisMaxValue = (int)MultiEx.AVGre + 1.5f;
        }
        else if (pp.value == pp.items[3].ToString())
        {
            YAxis = 1;
            Wag.yAxisMinValue = (int)MultiEx.AVGvelocity - 0.5f;
            Wag.yAxisMaxValue = (int)MultiEx.AVGvelocity + 1.5f;
        }
        else if (pp.value == pp.items[4].ToString())
        {
            YAxis = 0;
            Wag.yAxisMinValue = (int)MultiEx.AVGtime - 0.5f;
            Wag.yAxisMaxValue = (int)MultiEx.AVGtime + 1.5f;
        }

        FPlot(XAxis, YAxis, MultiEx.dt);

    }

    public void DoPlot()
    {
        FPlot(XAxis, YAxis, MultiEx.dt);
    }
    public void FPlot(int x, int y, DataTable dt)
    {
        int n = dt.Columns.Count;

        Ws.pointValues.RemoveRange(0, Ws.pointValues.Count);
        Vector2 vct = new Vector2();
       
        for (int i = 0; i < n-1; ++i)
        {
            float a = float.Parse(dt.Rows[x][i+1].ToString());
            float b = float.Parse(dt.Rows[y][i+1].ToString());
            vct.x = a;
            vct.y = b;

            Ws.pointValues.Insert(i,vct);
        }
        if (Ws.pointValues.Count == 0) return;
        float xDisFromAxis ;
        float yDisFromAxis ;
        Ws.pointValues.Sort(delegate (Vector2 a, Vector2 b)
        {
            return a.x.CompareTo(b.x);
        });
        xDisFromAxis = (Ws.pointValues[Ws.pointValues.Count - 1].x - Ws.pointValues[0].x) / 4;
        Wag.xAxisMaxValue = Ws.pointValues[Ws.pointValues.Count - 1].x + xDisFromAxis;
        Wag.xAxisMinValue = Ws.pointValues[0].x - xDisFromAxis;

        Ws.pointValues.Sort(delegate (Vector2 a, Vector2 b)
        {
            return a.y.CompareTo(b.y);
        });
        yDisFromAxis = (Ws.pointValues[Ws.pointValues.Count - 1].y - Ws.pointValues[0].y) / 4;
        Wag.yAxisMaxValue = Ws.pointValues[Ws.pointValues.Count - 1].y + yDisFromAxis;
        Wag.yAxisMinValue = Ws.pointValues[0].y - yDisFromAxis;

    }


    public void EnableeStartButtonInExperimentMenu(GameObject GO)
    {
        GameObject.Find("BResult").GetComponent<UISprite>().enabled = false;
        GameObject.Find("BResult").GetComponentInChildren<UILabel>().enabled = false;
        GO.SetActive(true);
    }
    public void DisableStartButtonInExperimentMenu(GameObject GO)
    {
        GO.SetActive(false);
    }

    public void DontPichInSimulation()
   {
        PichOver.InSimulation = true;  
   }
    public void ExitingSimulationMode()
    {
        PichOver.InSimulation = false;
    }

    public void ShiftArrayRight()
    {
        var LastItem = GuidePages[GuidePages.Length-1].enabled; 
        if (LastItem == false)
        {
        
        for (int i = GuidePages.Length - 1; i >0 ; i--)
        {
            GuidePages[i].enabled = GuidePages[i-1].enabled;
        }
        GuidePages[0].enabled = LastItem;
        }

        
    }

    public void ShiftArrayLeft()
    {
        var FirstItem = GuidePages[0].enabled;
        if (FirstItem == false)
        {
        for (int i = 0; i <GuidePages.Length - 1 ; i++)
        {
            GuidePages[i].enabled = GuidePages[i+1].enabled;
        }
        GuidePages[GuidePages.Length - 1].enabled = FirstItem;
        }

    }
    public void PGuideInitialConfig()
    {
        GuidePages[0].enabled = true;
        for (int i = 1; i < GuidePages.Length; i++)
        {
            GuidePages[i].enabled = false;
        }
    }


    public void ReNotificationManager()
    {
        MainCalc.Config();
        if (MainCalc.Re > 100f || MainCalc.Re1 > 100f)
        {
           // NotificationPanel.PlayForward();
            ReError.PlayForward();
        }
        else if (MainCalc.Re > 1 || MainCalc.Re1 > 1f)
        {
           // NotificationPanel.PlayForward();
            ReWarning.PlayForward();
        }
        else
        {
            SExCount.PlayForward();
        }

    }


    public void ReNotificationManager4Simulation()
    {
        MainCalc.Config();
        if (MainCalc.Re > 100f)
        {
            // NotificationPanel.PlayForward();
            ReError.PlayForward();
        }
        else if (MainCalc.Re > 1)
        {
            // NotificationPanel.PlayForward();
            ReWarningSi.PlayForward();
        }
        else
        {
            PsiResult.PlayForward();
            Simulate();
            DontPichInSimulation();

        }

    }



    public void ExportNotificationManager(int ErrorIndex)
    {

        if (ErrorIndex == 0)
        {
            PExRes.PlayReverse();
            ExportSuccess.PlayForward();
        }
        else if (ErrorIndex == 1)
        {
            PExRes.PlayReverse();
            ExportFailed.PlayForward();

        }

    }

    public void ToggleCamOrbit()
    {
        MainCam.gameObject.GetComponent<MouseOrbit>().enabled = !MainCam.gameObject.GetComponent<MouseOrbit>().enabled;
    }


    public void GetTerminalDistance()
    {
        MainCalc.Config();
        GameObject.Find("Lx").GetComponent<UILabel>().text = (SolveODE(0.00001f, 0.01f, MainCalc.TerminalVelocity, MainCalc.SphereFallingDistance) * 100).ToString().Substring(0, 4);

    }












    private void Initialize(float Vp, float Gp, float G, float Cd, float density, float A)
    {
        //Vp : Volume of Sphere
        //Gp : Specific weight of sphere
        //G : Specific weight of Glycerine
        //Cd : Drag Coefficient
        //A : Area 
        a = Vp * (Gp - G);
        b = (-0.5f) * Cd * density * A;
        c = -(Gp * Vp) / 9.8f;
    }

    private float F1(float z)
    {
        return z;
    }
    private float F2(float z)
    {
        float zp = (-a / c) - (b / c) * Mathf.Pow(z, 2);
        return zp;
    }
    private float SolveODE(float step, float delta, float V, float h0)
    {
        try
        {
            //V : Terminal Velocity (V>0)
            //h0 : height
            float z0 = Mathf.Sqrt(2 * 9.8f * h0);
            Initialize(((4f / 3f) * Mathf.PI * Mathf.Pow(MainCalc.SD / 2, 3)), MainCalc.SY, MainCalc.GY, MainCalc.CD, MainCalc.Density, (Mathf.PI * Mathf.Pow(MainCalc.SD / 2, 2)));
            float k1, k2, k3, k4, l1, l2, l3, l4, Yn = 0, Yn1, Zn = z0, Zn1;
            for (int n = 0; ; ++n)
            {
                k1 = step * F1(Zn);
                l1 = step * F2(Zn);
                k2 = step * F1(Zn + (0.5f * l1));
                l2 = step * F2(Zn + (0.5f * l1));
                k3 = step * F1(Zn + (0.5f * l2));
                l3 = step * F2(Zn + (0.5f * l2));
                k4 = step * F1(Zn + l3);
                l4 = step * F2(Zn + l3);
                Yn1 = Yn + (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                Zn1 = Zn + (l1 + 2 * l2 + 2 * l3 + l4) / 6;
                Yn = Yn1;
                Zn = Zn1;
                if (Mathf.Abs(Zn1 - V) <= delta)
                {
                    return Yn1;
                }

            }

        }
        catch
        {
            return 0;
        }
    }


    private float SolveODE1(float step, float delta, float V)
    {
        try
        {
        //V : Terminal Velocity (V>0)
        //h0 : height
        float z0 = V;
        Initialize(((4f / 3f) * Mathf.PI * Mathf.Pow(MainCalc.SD / 2, 3)), MainCalc.SY, MainCalc.GY1, MainCalc.CD1, MainCalc.Density1, (Mathf.PI * Mathf.Pow(MainCalc.SD / 2, 2)));
        float k1, k2, k3, k4, l1, l2, l3, l4, Yn = 0, Yn1, Zn = z0, Zn1;
        for (int n = 0; ; ++n)
        {
            k1 = step * F1(Zn);
            l1 = step * F2(Zn);
            k2 = step * F1(Zn + (0.5f * l1));
            l2 = step * F2(Zn + (0.5f * l1));
            k3 = step * F1(Zn + (0.5f * l2));
            l3 = step * F2(Zn + (0.5f * l2));
            k4 = step * F1(Zn + l3);
            l4 = step * F2(Zn + l3);
            Yn1 = Yn + (k1 + 2 * k2 + 2 * k3 + k4) / 6;
            Zn1 = Zn + (l1 + 2 * l2 + 2 * l3 + l4) / 6;
            Yn = Yn1;
            Zn = Zn1;
            if (Mathf.Abs(Zn1 - V) <= delta)
            {
                return Yn1;
            }
        }
        }
        catch
        {
            return 0;
        }
    }


    public void VelocityAnalysis()
    {
        MainCalc.Config();
        if (MainCalc.TerminalVelocity <= 0.01)
        {
            VWarning.SetActive(true);
        }
        else
        {
            VWarning.SetActive(false);
        }
    }




}
