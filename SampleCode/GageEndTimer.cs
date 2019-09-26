using UnityEngine;
using System.Collections;

public class GageEndTimer : MonoBehaviour {
    public GageStartTimer GST;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.S))
        {
            if (GST.PRealTime.alpha == 1)
            {
                GST.TimerTrigger = false;
            }
        }
	}

    void OnMouseDown()
    {
        if (GST.PRealTime.alpha == 1)
        {
            GST.TimerTrigger = false;
        }
        
    }
}
