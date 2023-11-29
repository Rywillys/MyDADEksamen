using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net;

public class popUpMeasurementVoltageAndI : MonoBehaviour
{
    //Object in the simulator
    public GameObject popup;
    public string[] tagname1 = {"DG1-GEN-V", "DG1-I-L1", "DG1-I-L2", "DG1-I-L3"};
    public string[] tagname2 = {"DG2-GEN-V", "DG2-I-L1", "DG2-I-L2", "DG2-I-L3"};

    public GameObject tagnameS1;
    public GameObject tagnameS2;

    public GameObject measurement1;
    public GameObject measurement2;
    public GameObject measurement3;
    public GameObject measurement4;


    public GameObject measurement10;
    public GameObject measurement11;
    public GameObject measurement12;
    public GameObject measurement13;

    
    public string phpURL;
    
    //variables
    TextMeshProUGUI tagnameS1Text;
    TextMeshProUGUI tagnameS2Text;
    TextMeshProUGUI measurementText1;
    TextMeshProUGUI measurementText2;
    TextMeshProUGUI measurementText3;
    TextMeshProUGUI measurementText4;


    TextMeshProUGUI measurementText10;
    TextMeshProUGUI measurementText11;
    TextMeshProUGUI measurementText12;
    TextMeshProUGUI measurementText13;


    public string measurements1;
    public string measurements2;
    public string measurements3;
    public string measurements4;


    public string measurements10;
    public string measurements11;
    public string measurements12;
    public string measurements13;

    public string TagnameWrite1;
    public string TagnameWrite2;
    private string url;


    // Start is called before the first frame update
    void Start()
    {
        tagnameS1Text = tagnameS1.GetComponent<TextMeshProUGUI>();
        tagnameS2Text = tagnameS2.GetComponent<TextMeshProUGUI>();
        //sets up informasjon in component and fetches data from database
        popup.SetActive(false);

        measurementText1 = measurement1.GetComponent<TextMeshProUGUI>();
        url = phpURL + "?name=" + tagname1[0] + "&amount=1";
        measurements1 = GetMeasurementFromDatabase();

        measurementText2 = measurement2.GetComponent<TextMeshProUGUI>();
        url = phpURL + "?name=" + tagname1[1] + "&amount=1";
        measurements2 = GetMeasurementFromDatabase();

        measurementText3 = measurement3.GetComponent<TextMeshProUGUI>();
        url = phpURL + "?name=" + tagname1[2] + "&amount=1";
        measurements3 = GetMeasurementFromDatabase();

        measurementText4 = measurement4.GetComponent<TextMeshProUGUI>();
        url = phpURL + "?name=" + tagname1[3] + "&amount=1";
        measurements4 = GetMeasurementFromDatabase();

        measurementText10 = measurement10.GetComponent<TextMeshProUGUI>();
        url = phpURL + "?name=" + tagname2[0] + "&amount=1";
        measurements10 = GetMeasurementFromDatabase();

        measurementText11 = measurement11.GetComponent<TextMeshProUGUI>();
        url = phpURL + "?name=" + tagname2[1] + "&amount=1";
        measurements11 = GetMeasurementFromDatabase();

        measurementText12 = measurement12.GetComponent<TextMeshProUGUI>();
        url = phpURL + "?name=" + tagname2[2] + "&amount=1";
        measurements12 = GetMeasurementFromDatabase();

        measurementText13 = measurement13.GetComponent<TextMeshProUGUI>();
        url = phpURL + "?name=" + tagname2[3] + "&amount=1";
        measurements13 = GetMeasurementFromDatabase();
    }

    void OnTriggerEnter(Collider other)
    {
        //sets up new varables with GetMeasurementByIndex function
        popup.SetActive(true);
        tagnameS1Text.text = TagnameWrite1;
        tagnameS2Text.text = TagnameWrite2;

        measurementText1.text = GetMeasurementByIndex(measurements1, 1) + " V";
        measurementText2.text = GetMeasurementByIndex(measurements2, 1) + " A";
        measurementText3.text = GetMeasurementByIndex(measurements3, 1) + " A";
        measurementText4.text = GetMeasurementByIndex(measurements4, 1) + " A";


        measurementText10.text = GetMeasurementByIndex(measurements10, 1) + " V";
        measurementText11.text = GetMeasurementByIndex(measurements11, 1) + " A";
        measurementText12.text = GetMeasurementByIndex(measurements12, 1) + " A";
        measurementText13.text = GetMeasurementByIndex(measurements13, 1) + " A";

    }

    private string GetMeasurementByIndex(string measurement, int index)
    {
        string[] parts = measurement.Split(',');
        return parts[index];
    } 

    private string GetMeasurementFromDatabase()
    {
        string response;
        using (WebClient client = new WebClient())
        {
            response = client.DownloadString(url);
        }
        
        return response;    
    }

    void OnTriggerExit(Collider other)
    {
        popup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
