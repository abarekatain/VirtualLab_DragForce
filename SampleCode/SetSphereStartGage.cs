using UnityEngine;
using System.Collections;

public class SetSphereStartGage : MonoBehaviour {
	public Transform TheGage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = TheGage.position;
	}
}
