using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DownLoad1 : MonoBehaviour{
    [SerializeField]
    RawImage img;


    // Start is called before the first frame update
    void Start(){
        StartCoroutine(ImageLoad("testImage.jpg"));
    }

    IEnumerator ImageLoad(string imgName) {
        string uri = "https://holosoft.co.kr/gallery/pics/" + imgName;

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(uri);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success) {
            Debug.Log(request.error);
        }
        else {
            img.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            img.SetNativeSize();
        }

    }
}
