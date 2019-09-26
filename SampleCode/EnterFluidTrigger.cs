using UnityEngine;
using System.Collections;

public class EnterFluidTrigger : MonoBehaviour {
    public MainCalculation MainCalc;
    public PichMouseOver PichScript;
    public bool PichPermission = true;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Enter");
        MainCalc.TimeCounterTrigger = true;
        MainCalc.OneTimeSimulate2 = true;
        MainCalc.OneTimeSimulate1 = false;
        GameObject.Find("BResult").GetComponent<UISprite>().enabled = false ;
        GameObject.Find("BResult").GetComponentInChildren<UILabel>().enabled = false;
    }
    void OnTriggerExit()
    {
        MainCalc.TimeCounterTrigger = false;
        MainCalc.OneTimeConfig = false;
        MainCalc.OneTimeSimulate2 = false;
        MainCalc.OneTimeSimulate3 = false;
        MainCalc.Sphere.rigidbody.velocity = Vector3.zero;
        
        GameObject.Find("FirstGage").GetComponent<GageStartTimer>().TimerTrigger = false;
        Debug.Log("Exit");
    }
       
}
