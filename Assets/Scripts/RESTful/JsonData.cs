using System;
using System.Collections.Generic;

[Serializable]
public class JsonData
{
    public List<Scenes> scenes;
}


[Serializable]
public class Scenes
{
    public string id;
    public string user_id;
    public string categoryId;
    public string title;
    public string description;
    public string bundleUrl;
    public string bundleUrl2;
    public string hashUrl;
    public string jsonUrl;
    public string imageUrl;
    public bool isVerified;
    public DateTime createdAt;
    public DateTime updatedAt;

    public Category category;
    public User user;
}


[Serializable]
public class Category
{
    public string id;
    public string title;
    public DateTime createdAt;
    public DateTime updatedAt;
}


[Serializable]
public class User
{
    public string id;
    public string name;
    public string email;
    public DateTime emailVerified;
    public string image;
    public DateTime createdAt;
    public DateTime updatedAt;
    public bool isContributor;


}



