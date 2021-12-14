using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class JsonDataClass
{
    public string playerName;
    public List<BallList> balls;
    public List<BallList> loadingImages;
}



[Serializable]
public class BallList
{
    public string name;
    public string description;
    public int price;
    public string image;
    public int size;
    public string weight;
    public string free;
}


[Serializable]
public class LoadingImg
{
    public string image;
}