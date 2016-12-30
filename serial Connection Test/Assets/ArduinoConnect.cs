using UnityEngine;
using System.Collections;
using System.Threading;
using System.IO.Ports;
using UnityEngine.UI;

public class ArduinoConnect : MonoBehaviour {

    public Text text;
    public static SerialPort sp = new SerialPort("COM1",9600);
    
    private string message2;
	// Use this for initialization
	void Start () {

        text = GetComponent<Text>();
        text.text = "Get This Party Started";
        OpenConnection();
        sp.ReadTimeout = 100;
	}

    // Update is called once per frame
    void Update() {
        try {
            message2 = sp.ReadLine();
            text.text += message2;
        }
        catch (System.Exception) { print("glitch"); }
        /*
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.G))
                sp.Write("g");
            else if (Input.GetKey(KeyCode.R))
                text.text = "";
            else if (Input.GetKey(KeyCode.P))
                sp.Write("p");
            else
                sp.Write("s");
        }*/
	}

    void OpenConnection()
    {
        if (sp != null)
        {
            if (sp.IsOpen)
            {
                sp.Close();
                print("Someone forgot to close");
            }
            else
            {
                sp.Open();
                sp.ReadTimeout = 1000;
                print("Opened port");
            }

        }
        else
        {
            if (sp.IsOpen)
                print("Port already in use");
            else
                print("port does not exist");
        }
    }

    void OnApplicationQuit()
    {
        sp.Close();
    }
}

