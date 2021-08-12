using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeScreenShot : MonoBehaviour
{
    private static TakeScreenShot instance;

    public Camera myCamera;
    private bool takeScreenshotOnNextFrame;

    string name;

    RenderTexture renderTexture;
    Texture2D renderResult;
    Rect rect;
    byte[] byteArray;

    private void Awake()
    {
        instance = this;
        myCamera = gameObject.GetComponent<Camera>();
        StartCoroutine(setup());
    }

    IEnumerator setup()
    {
        yield return new WaitForSeconds(0.2f);
        myCamera.targetTexture = RenderTexture.GetTemporary(1920, 1080, 16);
        renderTexture = myCamera.targetTexture;
        renderResult = new Texture2D(myCamera.targetTexture.width, myCamera.targetTexture.height, TextureFormat.ARGB32, false);
        rect = new Rect(0, 0, myCamera.targetTexture.width, myCamera.targetTexture.height);
    }

    private void OnPostRender()
    {
        if (takeScreenshotOnNextFrame)
        {
            takeScreenshotOnNextFrame = false;
            //myCamera.targetTexture = RenderTexture.GetTemporary(1920, 1080, 16);
            renderTexture = myCamera.targetTexture;
            Debug.Log(renderTexture);

            //renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            //Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/Image/ExportImage/" + name + ".png", byteArray);
            //System.IO.File.WriteAllBytes("C:/" + name + ".png", byteArray);
            //Debug.Log("Snap!");

            RenderTexture.ReleaseTemporary(renderTexture);
            myCamera.targetTexture = null;
        }
    }

    private void takeScreenShot(int width, int height, string name)
    {
        myCamera = gameObject.GetComponent<Camera>();
        if (myCamera != null)
        {
            myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
            takeScreenshotOnNextFrame = true;
            this.name = name;
        }
        //else
        //{
        //    Debug.Log("null!");
        //}
    }

    public static void TakeScreenshot_Static(int width, int height, string name)
    {
        instance.takeScreenShot(width, height, name);
    }
}
