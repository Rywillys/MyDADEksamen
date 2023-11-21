using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    private string phpScriptUrl = "http://192.168.38.100/phpmyadmin/sql.php?server=1&db=tunglab&table=IOT_signals&pos=0";

    void Start()
    {
        StartCoroutine(GetDataFromPHP());
    }

    IEnumerator GetDataFromPHP()
    {
        using (WWW www = new WWW(phpScriptUrl))
        {
            yield return www;

            if (www.error != null)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            {
                // Parse the JSON data
                string jsonData = www.text;
                ParseJSONData(jsonData);
            }
        }
    }

    void ParseJSONData(string jsonData)
    {
        // Parse JSON data here
        // Example: Deserialize the JSON into a list of objects
        // List<MyDataClass> dataList = JsonUtility.FromJson<List<MyDataClass>>(jsonData);
    }
}