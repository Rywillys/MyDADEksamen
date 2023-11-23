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

    public GameObject tagnameS1;
    public GameObject tagnameS2;

    public GameObject measurement1;
    public GameObject measurement2;
    public GameObject measurement3;
    public GameObject measurement4;
    public GameObject measurement5;
    public GameObject measurement6;
    public GameObject measurement7;
    public GameObject measurement8;
    public GameObject measurement9;

    public GameObject measurement10;
    public GameObject measurement11;
    public GameObject measurement12;
    public GameObject measurement13;
    public GameObject measurement14;
    public GameObject measurement15;
    public GameObject measurement16;
    public GameObject measurement17;
    public GameObject measurement18;
    
    public string phpURL;
    
    //variables
    TextMeshProUGUI tagnameS1Text;
    TextMeshProUGUI tagnameS2Text;
    TextMeshProUGUI measurementText1;
    TextMeshProUGUI measurementText2;
    TextMeshProUGUI measurementText3;
    TextMeshProUGUI measurementText4;
    TextMeshProUGUI measurementText5;
    TextMeshProUGUI measurementText6;
    TextMeshProUGUI measurementText7;
    TextMeshProUGUI measurementText8;
    TextMeshProUGUI measurementText9;

    TextMeshProUGUI measurementText10;
    TextMeshProUGUI measurementText11;
    TextMeshProUGUI measurementText12;
    TextMeshProUGUI measurementText13;
    TextMeshProUGUI measurementText14;
    TextMeshProUGUI measurementText15;
    TextMeshProUGUI measurementText16;
    TextMeshProUGUI measurementText17;
    TextMeshProUGUI measurementText18;

    public string measurements1;
    public string measurements2;
    public string measurements3;
    public string measurements4;
    public string measurements5;
    public string measurements6;
    public string measurements7;
    public string measurements8;
    public string measurements9;

    public string measurements10;
    public string measurements11;
    public string measurements12;
    public string measurements13;
    public string measurements14;
    public string measurements15;
    public string measurements16;
    public string measurements17;
    public string measurements18;
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

        measurementText14 = measurement14.GetComponent<TextMeshProUGUI>();
        url = phpURL + "?name=" + tagname2[4] + "&amount=1";
        measurements14 = GetMeasurementFromDatabase();

        measurementText15 = measurement15.GetComponent<TextMeshProUGUI>();
        url = phpURL + "?name=" + tagname2[5] + "&amount=1";
        measurements15 = GetMeasurementFromDatabase();
        
        measurementText16 = measurement16.GetComponent<TextMeshProUGUI>();
        url = phpURL + "?name=" + tagname2[6] + "&amount=1";
        measurements16 = GetMeasurementFromDatabase();

        measurementText17 = measurement17.GetComponent<TextMeshProUGUI>();
        url = phpURL + "?name=" + tagname2[7] + "&amount=1";
        measurements17 = GetMeasurementFromDatabase();

        measurementText18 = measurement18.GetComponent<TextMeshProUGUI>();
        url = phpURL + "?name=" + tagname2[8] + "&amount=1";
        measurements18 = GetMeasurementFromDatabase();
    }

    void OnTriggerEnter(Collider other)
    {
        //sets up new varables with GetMeasurementByIndex function
        popup.SetActive(true);
        tagnameS1Text.text = TagnameWrite1;
        tagnameS2Text.text = TagnameWrite2;
        if (GetMeasurementByIndex(measurements1, 1) == "1"){
            measurementText1.text = "RUNNING";
        }
        else{
            measurementText1.text = "STOPPED";
        };

        measurementText2.text = GetMeasurementByIndex(measurements2, 1);
        measurementText3.text = GetMeasurementByIndex(measurements3, 1);
        measurementText4.text = GetMeasurementByIndex(measurements4, 1);
        measurementText5.text = GetMeasurementByIndex(measurements5, 1);
        measurementText6.text = GetMeasurementByIndex(measurements6, 1);
        measurementText7.text = GetMeasurementByIndex(measurements7, 1);
        measurementText8.text = GetMeasurementByIndex(measurements8, 1);
        measurementText9.text = GetMeasurementByIndex(measurements9, 1);

        if (GetMeasurementByIndex(measurements10, 1) == "1"){
            measurementText10.text = "RUNNING";
        }
        else{
            measurementText10.text = "STOPPED";
        };

        measurementText11.text = GetMeasurementByIndex(measurements11, 1);
        measurementText12.text = GetMeasurementByIndex(measurements12, 1);
        measurementText13.text = GetMeasurementByIndex(measurements13, 1);
        measurementText14.text = GetMeasurementByIndex(measurements14, 1);
        measurementText15.text = GetMeasurementByIndex(measurements15, 1);
        measurementText16.text = GetMeasurementByIndex(measurements16, 1);
        measurementText17.text = GetMeasurementByIndex(measurements17, 1);
        measurementText18.text = GetMeasurementByIndex(measurements18, 1);
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
