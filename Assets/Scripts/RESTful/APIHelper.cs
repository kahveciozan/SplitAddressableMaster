using UnityEngine;
using System.Net;
using System.IO;

public static class APIHelper
{
    public static JsonData GetNewJoke()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://layla-project.vercel.app/api/scenes");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();
        return JsonUtility.FromJson<JsonData>(json);
    }
}
