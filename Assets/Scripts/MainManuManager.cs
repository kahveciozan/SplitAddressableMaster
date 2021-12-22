using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.AddressableAssets.ResourceLocators;
using System.Linq;
using UnityEngine.ResourceManagement.ResourceLocations;

public class MainManuManager : MonoBehaviour
{
    public int downloadProgressInput;
    public Text textInfo, textBnt1, textBnt2, textBnt3;
    private AsyncOperationHandle<long> s1, s2, s3;

    private void Start()
    {

        StartCoroutine(RemoteDeneme());
        StartCoroutine(RemoteDeneme2());
        StartCoroutine(RemoteDeneme3());

        textInfo.text = "OYUN YÜKLENİYOR BEKLEYİNİZ";
        StartCoroutine(MyStart());
    }

    IEnumerator MyStart()
    {
        yield return new WaitForSeconds(1f);
        s1 = Addressables.GetDownloadSizeAsync("Level1");
        s2 = Addressables.GetDownloadSizeAsync("Level2");
        s3 = Addressables.GetDownloadSizeAsync("Level4");                            // .complated dedikten sonra yükleme yapilabilir

        yield return new WaitForSeconds(1f);                                         // GetDownloadSieAsync bitene kadar bekle olarak degistir
        textInfo.text = "Level1: " + s1.Result / (1024) + "kB"+
                        "\nLevel2: " + s2.Result / (1024 ) + "kB" +
                        "\nLevel4: " + s3.Result / (1024) + "kB";


        if (s1.Result > 0)
        {
            textBnt1.text = "Download Scene " + (s1.Result / (1024)) + "kB";
        }
        else
        {
            textBnt1.text = "PLAY";
        }

        if (s2.Result > 0)
        {
            textBnt2.text = "Download Scene " + (s2.Result / (1024)) + "kB";
        }
        else
        {
            textBnt2.text = "PLAY";
        }

        if (s3.Result > 0)
        {
            textBnt3.text = "Download Scene " + (s3.Result / (1024)) + "kB";
        }
        else
        {
            textBnt3.text = "PLAY";
        }
    }


    public void LoadAddressableScene(string sceneName)
    {
        // TO DO Button Click Sound
        StartCoroutine(DownloadScene(sceneName));
    }

    IEnumerator DownloadScene(string sceneName)
    {
        Button clickedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        Text clickedText = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>();
        var scn = Addressables.GetDownloadSizeAsync(sceneName);
        //downloadScene.Completed += SceneDownloadComplete;
        clickedButton.interactable = false;
        if (scn.Result == 0)
        {
            textInfo.text = "SAHNE YÜKLENİYOR";
            Addressables.LoadSceneAsync(sceneName, LoadSceneMode.Single, true);
        }
        else
        {
            var downloadScene = Addressables.DownloadDependenciesAsync(sceneName);
            textInfo.text = "Sahne İndiriliyor";
            clickedText.text = "EVET DEĞİŞİYOR";

            while (!downloadScene.IsDone)
            {
                var status = downloadScene.GetDownloadStatus();
                float progress = status.Percent;
                downloadProgressInput = (int)(progress * 100);

                clickedText.text = downloadProgressInput.ToString() + " % Downloading";
                yield return null;
            }
            clickedText.text = "PLAY";
            clickedButton.interactable = true;
            downloadProgressInput = 100;
        }

        //textInfo.text = "Sahneye Gidiliyor";

    }

    #region SceneDownloadComplate
    private void SceneDownloadComplete(AsyncOperationHandle<SceneInstance> _handle)
    {
        if (_handle.Status == AsyncOperationStatus.Succeeded)
        {
            textInfo.text = "PLAY C";
        }
    }
    #endregion

    #region Remote1
    IEnumerator RemoteDeneme()
    {
        var catalogPath = "https://storage.googleapis.com/addressable-deneme/Android/catalog_2021.12.08.09.53.34.json";
        //Load a catalog and automatically release the operation handle.
        AsyncOperationHandle<IResourceLocator> handle = Addressables.LoadContentCatalogAsync(catalogPath, true);
        yield return handle;

        //...

    }
    IEnumerator RemoteDeneme2()
    {
        var catalogPath = "https://storage.googleapis.com/addressable-deneme/Android/catalog_2021.12.08.07.19.43.json";
        //Load a catalog and automatically release the operation handle.
        AsyncOperationHandle<IResourceLocator> handle2 = Addressables.LoadContentCatalogAsync(catalogPath, true);
        yield return handle2;
    }


    IEnumerator RemoteDeneme3()
    {
        var catalogPath = "https://storage.googleapis.com/addressable-deneme/Android/1639388453570-0.9941029056360071/Android/catalog_2021.12.09.11.35.01.json";
        //Load a catalog and automatically release the operation handle.
        AsyncOperationHandle<IResourceLocator> handle3 = Addressables.LoadContentCatalogAsync(catalogPath, true);


        yield return handle3;
    }




    #endregion




    #region Remote2
    IEnumerator DownloadRemote(string sceneName)
    {
        var catalogPath = "https://storage.googleapis.com/addressable-deneme/Android/catalog_2021.12.08.09.53.34.json";

        var h = Addressables.InitializeAsync();
        yield return h;
        Debug.Log($"Addressables.ResourceLocators.Count: {Addressables.ResourceLocators.Count()}"); // 1

        var h2 = Addressables.LoadContentCatalogAsync(catalogPath);
        yield return h2;
        Debug.Log($"Addressables.ResourceLocators.Count: {Addressables.ResourceLocators.Count()}"); // 2

        yield return null;
    }
    #endregion

}
