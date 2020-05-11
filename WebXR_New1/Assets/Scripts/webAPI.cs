using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization.Formatters.Binary;

public class webAPI : MonoBehaviour
{  
    public void Run()
    {

        // A correct website page.
        string path = EditorUtility.OpenFilePanel("Overwrite with png", "", "*");



        Debug.Log(path);

         StartCoroutine(GetRequest(path));

        // A non-existing page.
        //StartCoroutine(GetRequest("https://error.html"));
    }

    IEnumerator GetRequest(string path)
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
       // formData.Add(new MultipartFormFileSection("file", bytes, files[0], "text/plain"));
        formData.Add(new MultipartFormDataSection("file=path"));
        //formData.Add(new MultipartFormFileSection("my file data", "myfile.txt"));

        UnityWebRequest www = UnityWebRequest.Post("http://6d8247b9.ngrok.io/file-upload", formData);
        yield return www.SendWebRequest();
        Debug.Log(www.downloadHandler.text);


        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
}
