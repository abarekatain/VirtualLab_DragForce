using UnityEngine;
using System.Collections;

public class Zoom : MonoBehaviour {
	public Transform Sphere;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


		transform.position = new Vector3 (transform.position.x, Sphere.position.y, Sphere.position.z); 

	}


}
