using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net;

public class popUpMeasurementSensors : MonoBehaviour
{
    //Object in the simulator
    public GameObject popup;
    public string[] tagname1 = {"301TE101", "301HE102", "723TE301", "723TE302", "723TE303", "723TE304"};

    public GameObject tagnameS1;

    public GameObject measurement1;
    public GameObject measurement2;
    public GameObject measurement3;
    public GameObject measurement4;
    public GameObject measurement5;
    public GameObject measurement6;
    
    public string phpURL;
    
    //variables
    TextMeshProUGUI tagnameS1Text;
    TextMeshProUGUI measurementText1;
    TextMeshProUGUI measurementText2;
    TextMeshProUGUI measurementText3;
    TextMeshProUGUI measurementText4;
    TextMeshProUGUI measurementText5;
    TextMeshProUGUI measurementText6;

    public string measurements1;
    public string measurements2;
    public string measurements3;
    public string measurements4;
    public string measurements5;
    public string measurements6;
    public string TagnameWrite1;
    private string url;


    // Start is called before the first frame update
    void Start()
    {
        tagnameS1Text = tagnameS1.GetComponent<TextMeshProUGUI>();
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

        measurementText5 = measurement5.GetComponent<TextMeshProUGUI>();
        url = phpURL + "?name=" + tagname1[4] + "&amount=1";
        measurements5 = GetMeasurementFromDatabase();

        measurementText6 = measurement6.GetComponent<TextMeshProUGUI>();
        url = phpURL + "?name=" + tagname1[5] + "&amount=1";
        measurements6 = GetMeasurementFromDatabase();
        
    }

    void OnTriggerEnter(Collider other)
    {
        //sets up new varables with GetMeasurementByIndex function
        popup.SetActive(true);
        tagnameS1Text.text = TagnameWrite1;

        measurementText1.text = GetMeasurementByIndex(measurements1, 1) + "°C";
        measurementText2.text = GetMeasurementByIndex(measurements2, 1) + "°C";
        measurementText3.text = GetMeasurementByIndex(measurements3, 1) + "°C";
        measurementText4.text = GetMeasurementByIndex(measurements4, 1) + "°C";
        measurementText5.text = GetMeasurementByIndex(measurements5, 1) + "°C";
        measurementText6.text = GetMeasurementByIndex(measurements6, 1) + "°C";
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
