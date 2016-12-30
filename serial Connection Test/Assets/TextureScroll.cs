using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroll : MonoBehaviour {

    public Texture2D Starttext;
    public List<Texture> myTextures = new List<Texture>();
    
    int maxTextures=0;
    int arrayPos = 0;
    public void Start()
    {
        myTextures.Add(Starttext);
        GetComponent<Renderer>().material.mainTexture = myTextures[0];
    } 


    public void AddTexture(Texture x){
        myTextures.Add(x);
        ++maxTextures;

        }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            arrayPos++;
            arrayPos = arrayPos % maxTextures;
            print("array pos = " + arrayPos.ToString());
            GetComponent<Renderer>().material.mainTexture = myTextures[arrayPos];
            
            

        }
    }
}
