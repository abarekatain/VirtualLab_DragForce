using UnityEngine;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System;
//using System.Diagnostics;
//using System.Reflection;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Spreadsheet;
//using DocumentFormat.OpenXml;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Linq;
//using ExcelLibrary.CompoundDocumentFormat;
//using ExcelLibrary.SpreadSheet;
public class MultiExperience : MonoBehaviour {
    public MenuOptions Mo;
    public MainCalculation Mc;
    public DataTable dt = new DataTable();
    public int ExCount;
    public int CurrentEx = 0;
    public bool OneExFinished;
    public bool ExsFinished;
    public float AVGvelocity, AVGtime, AVGre, AVGcd, AVGviscosity;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (OneExFinished && !ExsFinished)
        {
            CurrentEx += 1;
            OneExFinished = false;

            if (CurrentEx == ExCount)
            {
                ExsFinished = true;
                GameObject.Find("BResult").GetComponent<UISprite>().enabled = true;
                GameObject.Find("BResult").GetComponentInChildren<UILabel>().enabled = true;
                GameObject.Find("BNext").GetComponent<UISprite>().enabled = false;
                GameObject.Find("BNext").GetComponentInChildren<UILabel>().enabled = false;
            }
            else
            {
                GameObject.Find("BNext").GetComponent<UISprite>().enabled = true;
                GameObject.Find("BNext").GetComponentInChildren<UILabel>().enabled = true;
            }



        }
    }


    public void NextButtonFunc()
    {
        Mo.Simulate();
        GameObject.Find("BNext").GetComponent<UISprite>().enabled = false;
        GameObject.Find("BNext").GetComponentInChildren<UILabel>().enabled = false;


    }

    void SetTheDT()
    {
        dt.Reset();
        dt.Columns.Add(" ", Type.GetType("System.String"));
        DataRow dr = dt.NewRow();
        DataRow dr1 = dt.NewRow();
        DataRow dr2 = dt.NewRow();
        DataRow dr3 = dt.NewRow();
        DataRow dr4 = dt.NewRow();
        dt.Rows.Add(dr);
        dt.Rows.Add(dr1);
        dt.Rows.Add(dr2);
        dt.Rows.Add(dr3);
        dt.Rows.Add(dr4);
        dt.Rows[0][0] = "Time";
        dt.Rows[1][0] = "Velocity";
        dt.Rows[2][0] = "Re";
        dt.Rows[3][0] = "Cd";
        dt.Rows[4][0] = "Viscosity";
        for (int i = 0; i < ExCount; i++)
        {
            dt.Columns.Add("Test " + (i + 1).ToString());
            //dt.Rows[0][i+1] = "Test " + (i+1).ToString(); 
        }
        
        
    }


   public void GetExCount(UIInput Inp)
    {
        if (Inp.value.Trim() != "")
         ExCount = int.Parse(Inp.value);
        SetTheDT();

        //var path = EditorUtility.SaveFilePanel(
        //            "Save Results",
        //            "",
        //            "Results.xls",
        //            "xls");
        //ToExcel(dt, path);


        UnityEngine.Debug.Log("Ok");

       

        
    }



    public void ExInputValidator(UIInput pp)
    {
        if (pp.value.Trim() != "")
        {
            if (pp.value == "-" || pp.value == "0")
            {
                pp.value = "1";
                
            }
           

            else if (float.Parse(pp.value) > 10f)
            {
                pp.value = "10";
            }


        }
        else
        {
            ExCount = 1;
        }
    }



    public void ToExcel(DataTable dt,string target)
    {
        //string target = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Results.xls");

        //open file
        

        try
        {
            StreamWriter wr = new StreamWriter(target);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                wr.Write(dt.Columns[i].ToString().ToUpper() + "\t");
            }

            wr.WriteLine();

            //write rows to excel file
            for (int i = 0; i < (dt.Rows.Count); i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Rows[i][j] != null)
                    {
                        wr.Write(Convert.ToString(dt.Rows[i][j]) + "\t");
                    }
                    else
                    {
                        wr.Write("\t");
                    }
                }
                //go to next line
                wr.WriteLine();
            }
            //close file
            wr.Close();
            Mo.ExportNotificationManager(0);
        }
        catch
        {
            Mo.ExportNotificationManager(1);
        }


    }

}
