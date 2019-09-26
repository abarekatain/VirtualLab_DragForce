using UnityEngine;
using System.Collections;

public class GageStartTimer : MonoBehaviour {
    public bool TimerTrigger;
    public float MainTime;
    public UILabel TimerLabel;
    public UIPanel PRealTime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (TimerTrigger)
        {
            MainTime += Time.deltaTime;
            try
            {
                TimerLabel.text = MainTime.ToString().Substring(0, 5);
            }
            catch { }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (PRealTime.alpha == 1)
            {
                TimerTrigger = true;
            }
        }

    }
    void OnMouseUp()
    {
        if (PRealTime.alpha == 1)
        {
            TimerTrigger = true;
        }
        
    }
}
