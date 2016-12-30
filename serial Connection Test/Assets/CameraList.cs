using UnityEngine;
using System.Collections;
using System.IO;

public class CameraList : MonoBehaviour
{
    public string deviceName;
    WebCamTexture wct;
    public int device = 0;
    public GameObject panel;

    // Use this for initialization
    void Start() {
        WebCamDevice[] devices = WebCamTexture.devices;
        deviceName = devices[device].name;

        wct = new WebCamTexture(deviceName, 1280, 720, 60);
        GetComponent<Renderer>().material.mainTexture = wct;

        wct.Play();
    }

    // For photo varibles

    public Texture2D heightmap;
    public Vector3 size = new Vector3(100, 10, 100);


    // For saving to the _savepath
    private string _SavePath = "C:/Users/Ben/Desktop/serial Connection Test/Assets/Materials/"; //Change the path here!
    int x = 0;

    private void Update() {
        if (wct.didUpdateThisFrame) {


        }
    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 70, 50, 30), "Click"))
        {
            TakeSnapshot();
        }

    }

    void TakeSnapshot()
    {
        //for saving file
        string path =  _SavePath + "Texture.png";
        Texture2D snapshot = new Texture2D(wct.width,wct.height);
        snapshot.SetPixels(wct.GetPixels());
        byte[] data = snapshot.EncodeToPNG();
        FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
        fs.Write(data,0,data.Length);
        fs.Close();
        panel.GetComponent<TextureScroll>().AddTexture(snapshot);
        x++;
        print("snapshot to "+path+" "+data.Length);
    }
}