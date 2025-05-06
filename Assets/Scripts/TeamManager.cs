using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamManager : MonoBehaviour
{

    public string[] names = new string[5];
    void Start()
    {
        
    }

    public void AddName1ToArray(string text)
    {
        names[0] = text;
    }
    public void AddName2ToArray(string text)
    {
        names[1] = text;
    }
    public void AddName3ToArray(string text)
    {
        names[2] = text;
    }
    public void AddName4ToArray(string text)
    {
        names[3] = text;
    }
    public void AddName5ToArray(string text)
    {
        names[4] = text;
    }

    public void Continue()
    {
       
    }
}
