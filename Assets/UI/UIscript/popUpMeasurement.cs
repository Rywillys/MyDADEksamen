using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net;


public class popUpMeasurement : MonoBehaviour
{
    //Object in the simulator
    public GameObject popup;
    public GameObject tagname;
    public GameObject measurement1;
    public GameObject measurement2;
    public GameObject measurement3;
    public GameObject measurement4;
    public string phpURL;
    
    //variables
    TextMeshProUGUI TagnameText;
    TextMeshProUGUI measurementText1;
    TextMeshProUGUI measurementText2;
    TextMeshProUGUI measurementText3;
    TextMeshProUGUI measurementText4;
    public string measurements;
    private string url;

    // Start is called before the first frame update
    void Start()
    {
        //sets up informasjon in component and fetches data from database
        popup.SetActive(false);
        TagnameText = tagname.GetComponent<TextMeshProUGUI>();
        measurementText1 = measurement1.GetComponent<TextMeshProUGUI>();
        measurementText2 = measurement2.GetComponent<TextMeshProUGUI>();
        measurementText3 = measurement3.GetComponent<TextMeshProUGUI>();
        measurementText4 = measurement4.GetComponent<TextMeshProUGUI>();
        url = phpURL + "?name=" + name + "&amount=1";
        measurements = GetMeasurementFromDatabase();
        
    }

    void OnTriggerEnter(Collider other)
    {
        //sets up new varables with GetMeasurementByIndex function
        popup.SetActive(true);
        TagnameText.text = gameObject.name;
        measurementText1.text = GetMeasurementByIndex(measurements, 1);
        measurementText2.text = GetMeasurementByIndex(measurements, 2);
        measurementText3.text = GetMeasurementByIndex(measurements, 0);
        measurementText4.text = GetMeasurementByIndex(measurements, 0);
        
        
        
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
