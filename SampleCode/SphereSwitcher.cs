using UnityEngine;
using System.Collections;

public class SphereSwitcher : MonoBehaviour
{
    public GameObject BigF, MediumF, SmallF, Ceramic, Glass;
    public int SphereIndex = 0;
    public MenuOptions MenuComponent;
    public Zoom SphereZoomComponent;
    public MainCalculation MainCalc;
    public PichMouseOver Pich;
    public bool DisableSphereAnchor;
    public bool EnableSphereAnchor;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (SphereIndex)
        {
            case 0:
                BigF.SetActive(true);
                MediumF.SetActive(false);
                SmallF.SetActive(false);
                Ceramic.SetActive(false);
                Glass.SetActive(false);
                MenuComponent.Sphere = BigF.transform;
                SphereZoomComponent.Sphere = BigF.transform;
                Pich.Sphere = BigF.transform;
                MainCalc.Sphere = BigF.transform;
                break;
            case 1:
                BigF.SetActive(false);
                MediumF.SetActive(true);
                SmallF.SetActive(false);
                Ceramic.SetActive(false);
                Glass.SetActive(false);
                MenuComponent.Sphere = MediumF.transform;
                SphereZoomComponent.Sphere = MediumF.transform;
                MainCalc.Sphere = MediumF.transform;
                Pich.Sphere = MediumF.transform;
                break;
            case 2:
                BigF.SetActive(false);
                MediumF.SetActive(false);
                SmallF.SetActive(true);
                Ceramic.SetActive(false);
                Glass.SetActive(false);
                MenuComponent.Sphere = SmallF.transform;
                SphereZoomComponent.Sphere = SmallF.transform;
                MainCalc.Sphere = SmallF.transform;
                Pich.Sphere = SmallF.transform;
                break;
            case 3:
                BigF.SetActive(false);
                MediumF.SetActive(false);
                SmallF.SetActive(false);
                Ceramic.SetActive(false);
                Glass.SetActive(true);
                MenuComponent.Sphere = Glass.transform;
                SphereZoomComponent.Sphere = Glass.transform;
                MainCalc.Sphere = Glass.transform;
                Pich.Sphere = Glass.transform;
                break;
            case 4:
                BigF.SetActive(false);
                MediumF.SetActive(false);
                SmallF.SetActive(false);
                Ceramic.SetActive(true);
                Glass.SetActive(false);
                MenuComponent.Sphere = Ceramic.transform;
                SphereZoomComponent.Sphere = Ceramic.transform;
                MainCalc.Sphere = Ceramic.transform;
                Pich.Sphere = Ceramic.transform;
                break;
        }
        if (DisableSphereAnchor)
        {
            BigF.GetComponent<SetSphereStartGage>().enabled = false;
            SmallF.GetComponent<SetSphereStartGage>().enabled = false;
            MediumF.GetComponent<SetSphereStartGage>().enabled = false;
            Ceramic.GetComponent<SetSphereStartGage>().enabled = false;
            Glass.GetComponent<SetSphereStartGage>().enabled = false;
            DisableSphereAnchor = false;

        }
        else if (EnableSphereAnchor)
        {
            BigF.GetComponent<SetSphereStartGage>().enabled = true;
            SmallF.GetComponent<SetSphereStartGage>().enabled = true;
            MediumF.GetComponent<SetSphereStartGage>().enabled = true;
            Ceramic.GetComponent<SetSphereStartGage>().enabled = true;
            Glass.GetComponent<SetSphereStartGage>().enabled = true;
            EnableSphereAnchor = false;

        }
    }
}

