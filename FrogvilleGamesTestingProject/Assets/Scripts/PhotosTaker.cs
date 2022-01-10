using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotosTaker : MonoBehaviour
{
    public Camera cameraToTakePhoto;
    public void TakePhoto()
    {
        cameraToTakePhoto.targetTexture = RenderTexture.GetTemporary(Screen.width - 600, Screen.height - 200, 16);
        StartCoroutine(waitASecound());
    }

    IEnumerator waitASecound()
    {
        yield return new WaitForEndOfFrame();
        RenderTexture renderTexture = cameraToTakePhoto.targetTexture;
        Texture2D result = new Texture2D(Screen.width-600, Screen.height-200, TextureFormat.ARGB32, false);
        Rect rect = new Rect(300, 100, Screen.width-600, Screen.height-200);
        result.ReadPixels(rect, 0, 0);

        byte[] ba = result.EncodeToPNG();
        string photoName = "photo" + DateCreator();
        System.IO.File.WriteAllBytes(Application.dataPath + "/Output/"+photoName+".png", ba);
        Debug.Log("Succesfully saved photo");

        RenderTexture.ReleaseTemporary(renderTexture);
        cameraToTakePhoto.targetTexture = null;
    }

    string DateCreator()
    {
        string sec = "";
        string min = "";
        string h = "";
        string day = "";

        if (DateTime.Now.Day < 10) day = "0" + DateTime.Now.Day;
        else day = DateTime.Now.Day.ToString();
        if (DateTime.Now.Hour < 10) h = "0" + DateTime.Now.Hour;
        else h = DateTime.Now.Hour.ToString();
        if (DateTime.Now.Minute < 10) min = "0" + DateTime.Now.Minute;
        else min = DateTime.Now.Minute.ToString();
        if (DateTime.Now.Second < 10) sec = "0" + DateTime.Now.Second;
        else sec = DateTime.Now.Second.ToString();


        string currentDate = day + h + min + sec;
        return currentDate;
    }
}