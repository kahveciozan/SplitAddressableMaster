using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChuchNorris : MonoBehaviour
{

    private void Start()
    {
        Joke j = APIHelper.GetNewJoke();

        foreach (Scenes s in j.scenes)
        {
            Debug.Log("ID: "+s.id);
            Debug.Log("TITLE: " + s.title);
            Debug.Log("JsonURL: " + s.jsonUrl);

            Debug.Log("User Name: " + s.user.name);

            
        }

    }

    public void NewJoke()
    {
        Joke j = APIHelper.GetNewJoke();

        foreach (Scenes x in j.scenes)
        {
            Debug.Log(x.jsonUrl);
        }
    }




    /*
    #region WWW Obsolate Version
    public string jsonURL = "https://gist.githubusercontent.com/kahveciozan/6883122b48c1d6e31e3e8dcde6a8c8e0/raw/200befdf89ac6a3cda6e705d1376acc398d57698/ozan123";


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
        Joke jsnData = JsonUtility.FromJson<Joke>(_url);


        foreach (Scenes x in jsnData.scenes)
        {
            Debug.Log(x.id);
            Debug.Log(x.title);
            Debug.Log(x.jsonUrl);
        }
    }

    #endregion
    */

}
