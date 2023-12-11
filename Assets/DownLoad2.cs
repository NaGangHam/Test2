using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class DownLoad2 : MonoBehaviour{
    string filePath = "Assets/Images/testImage.jpg";


    // Start is called before the first frame update
    void Start(){
        File.Create(filePath).Close();
    }

    public void ButtonClick() {
        StartCoroutine(FileDownLoad());
    }

    IEnumerator FileDownLoad() {
        string url = "https://holosoft.co.kr/gallery/pics/testImage.jpg";

        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success) {
            Debug.Log("Error : " + request.error);
        }
        else {
            File.WriteAllBytes(filePath, request.downloadHandler.data);
        }
    }
}
