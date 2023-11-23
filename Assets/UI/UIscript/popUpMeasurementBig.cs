using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net;


public class popUpMeasurementBig : MonoBehaviour
{
    //Object in the simulator
    public GameObject popup;
    public string[] tagname1 = {"DG1-RUN", "DG1-VELOC", "DG1-GEN-FRQ", "DG1-GEN-V", "DG1-I-L1", "DG1-I-L2", "DG1-I-L3", "DG1-LOAD", "DG1-LOAD-KVAR"};
    public string[] tagname2 = {"DG2-RUN", "DG2-VELOC", "DG2-GEN-FRQ", "DG2-GEN-V", "DG2-I-L1", "DG2-I-L2", "DG2-I-L3", "DG2-LOAD", "DG2-LOAD-KVAR"};

    public GameObject measurement1;
    public GameObject measurement2;
    public GameObject measurement3;
    public GameObject measurement4;
    public GameObject measurement5;
    public GameObject measurement6;
    public GameObject measurement7;
    public GameObject measurement8;
    public GameObject measurement9;
    public string phpURL;
    
    //variables
    TextMeshProUGUI TagnameText;
    TextMeshProUGUI measurementText1;
    TextMeshProUGUI measurementText2;
    TextMeshProUGUI measurementText3;
    TextMeshProUGUI measurementText4;
    TextMeshProUGUI measurementText5;
    TextMeshProUGUI measurementText6;
    TextMeshProUGUI measurementText7;
    TextMeshProUGUI measurementText8;
    TextMeshProUGUI measurementText9;
    public string measurements1;
    public string measurements2;
    public string measurements3;
    public string measurements4;
    public string measurements5;
    public string measurements6;
    public string measurements7;
    public string measurements8;
    public string measurements9;
    private string url;


    // Start is called before the first frame update
    void Start()
    {

        //sets up informasjon in component and fetches data from database
        popup.SetActive(false);

        measurementText1 = measurement2.GetComponent<TextMeshProUGUI>();
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

        measurementText5 = measurement5.GetComponent<TextMeshProUGUI>();
        url = phpURL + "?name=" + tagname1[4] + "&amount=1";
        measurements5 = GetMeasurementFromDatabase();

        measurementText6 = measurement6.GetComponent<TextMeshProUGUI>();
        url = phpURL + "?name=" + tagname1[5] + "&amount=1";
        measurements6 = GetMeasurementFromDatabase();
        
        measurementText7 = measurement7.GetComponent<TextMeshProUGUI>();
        url = phpURL + "?name=" + tagname1[6] + "&amount=1";
        measurements7 = GetMeasurementFromDatabase();

        measurementText8 = measurement8.GetComponent<TextMeshProUGUI>();
        url = phpURL + "?name=" + tagname1[7] + "&amount=1";
        measurements8 = GetMeasurementFromDatabase();

        measurementText9 = measurement9.GetComponent<TextMeshProUGUI>();
        url = phpURL + "?name=" + tagname1[8] + "&amount=1";
        measurements9 = GetMeasurementFromDatabase();
    }

    void OnTriggerEnter(Collider other)
    {
        //sets up new varables with GetMeasurementByIndex function
        popup.SetActive(true);
        TagnameText.text = "YOO";//gameObject.name;
        measurementText1.text = GetMeasurementByIndex(measurements1, 0);
        measurementText2.text = GetMeasurementByIndex(measurements2, 0);
        measurementText3.text = GetMeasurementByIndex(measurements3, 0);
        measurementText4.text = GetMeasurementByIndex(measurements4, 0);
        measurementText5.text = GetMeasurementByIndex(measurements5, 0);
        measurementText6.text = GetMeasurementByIndex(measurements6, 0);
        measurementText7.text = GetMeasurementByIndex(measurements7, 0);
        measurementText8.text = GetMeasurementByIndex(measurements8, 0);
        measurementText9.text = GetMeasurementByIndex(measurements9, 0);
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
