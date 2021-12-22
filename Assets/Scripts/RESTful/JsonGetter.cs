using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class JsonGetter : MonoBehaviour
{
    public List<Text> textsInfos;

    public List<string> jsonURLs;
    public List<string> titles;
    public List<string> descriptions;
    public List<string> contNames;
    public List<string> imageURLs;


    private void Start()
    {
        JsonData j = APIHelper.GetNewJoke();

        foreach (Scenes s in j.scenes)
        {   
            jsonURLs.Add(s.jsonUrl);
            titles.Add(s.title);
            contNames.Add(s.user.name);
            imageURLs.Add(s.imageUrl);
            descriptions.Add(s.description);
        }


        for (int i = 0; i<textsInfos.Count; i++)
        {

            textsInfos[i].text = "Title: " + titles[i]
                               + "\nDescrip: " + descriptions[i]
                               + "\nCont: " + contNames[i];

            Image tempButtonImg = textsInfos[i].GetComponentInParent<Image>();

            StartCoroutine(DownloadImage(imageURLs[i], tempButtonImg));

        }

    }


    IEnumerator DownloadImage(string MediaUrl, Image buttonImage)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
        {
            // ImageComponent.texture = ((DownloadHandlerTexture) request.downloadHandler).texture;

            Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
            buttonImage.GetComponent<Image>().overrideSprite = sprite;
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
