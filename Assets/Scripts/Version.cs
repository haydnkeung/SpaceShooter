using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Version : MonoBehaviour
{

    
    public Text versionText;
    public string versionNumber = "1.0";//Versio Number
    /*
     Both clients must have same version to see each other
         */


    public void Awake()
    {
        versionText.text = "Version: "+ versionNumber;
    
    }


   
    
}
