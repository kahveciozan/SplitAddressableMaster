using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonController : MonoBehaviour
{
    public string jsonURL;


    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        //ProcessJson(jsonURL);
        StartCoroutine(GetData());
    }

    [System.Obsolete]
    IEnumerator GetData()
    {
        Debug.Log("PROCESSIN DATA ,WAİT");

        WWW _www = new WWW(jsonURL);
        yield return _www;
        if (_www.error == null)
        {
            ProcessJsonData(_www.text);
        }
        else
        {
            Debug.Log("OOPPSS");
        }
    }


    private void ProcessJsonData(string _url)
    {
        JsonDataClass jsnData = JsonUtility.FromJson<JsonDataClass>(_url);
        Debug.Log(jsnData.playerName);
        Debug.Log(jsnData.balls);

        foreach (BallList x in jsnData.balls)
        {
            Debug.Log(x.name);
            Debug.Log(x.free);
            Debug.Log(x.description);
        }
    }
}
