using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ContinueButton : MonoBehaviour
{
    public string[] names;
    
    public bool gameStarted = false;

    public void ContinueToGame()
    {
        TMP_InputField[] inputFields = FindObjectsByType(typeof(TMP_InputField), 0) as TMP_InputField[];

        names = new string[inputFields.Length];

        for (int i = 0; i < inputFields.Length; i++)
        {
            // Store the text from each input field in the names array
            names[i] = inputFields[i].text;
        }

        gameStarted = true;

        SceneManager.LoadScene(2);
    }
}
