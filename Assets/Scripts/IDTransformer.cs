using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.AddressableAssets;

static class IDTransformer
{
    //Implement a method to transform the internal ids of locations
    
    static string MyCustomTransform(IResourceLocation location)
    {
        if(location.InternalId.StartsWith("https"))
            Debug.Log(location.InternalId);

        if (location.InternalId.StartsWith("https://storage.googleapis.com/addressable-deneme/Android/remotescene3_scenes_all_9c7f99a41318f06bf7c22fde560d2d8b.bundle"))
        {
            //Get the url you want to use to point to your current server
            string currentUrlToUse = "https://storage.googleapis.com/addressable-deneme/Android/1639388453570-0.9941029056360071/Android/remotescene3_scenes_all_9c7f99a41318f06bf7c22fde560d2d8b.bundle";
            return location.InternalId.Replace(location.InternalId, currentUrlToUse);
        }

        if (location.InternalId.StartsWith("https://storage.googleapis.com/addressable-deneme/Android/eb6f37e068cc2feb93272af596fb5abc_unitybuiltinshaders_425f8e8ecd6c5d6efd5e520021ee1922.bundle"))
        {
            //Get the url you want to use to point to your current server
            string currentUrlToUse = "https://storage.googleapis.com/addressable-deneme/Android/1639388453570-0.9941029056360071/Android/eb6f37e068cc2feb93272af596fb5abc_unitybuiltinshaders_425f8e8ecd6c5d6efd5e520021ee1922.bundle";
            return location.InternalId.Replace(location.InternalId, currentUrlToUse);
        }

        return location.InternalId;
    }

    //Override the Addressables transform method with your custom method.
    //This can be set to null to revert to default behavior.

    [RuntimeInitializeOnLoadMethod]
    static void SetInternalIdTransform()
    {
        Addressables.InternalIdTransformFunc = MyCustomTransform;

    }


}
