using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Windows;
using System.IO;
using UnityEngine.Networking;


public class MenuScript : MonoBehaviour
{
    [MenuItem("Tools/Browse File from..")]
      static void Apply()
    {
        string path = EditorUtility.OpenFilePanel("Overwrite with png", "", "*");
       
        if (path.Length != 0)
        {
            /*var fileContent = File.ReadAllBytes(path);
            Debug.Log(fileContent);
            texture.LoadImage(fileContent);*/
            string url = "https://www.google.com";
            
          
        }
    }
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
            }
            
        }
    }
}
