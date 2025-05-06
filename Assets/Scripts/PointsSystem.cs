using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class PointsSystem : MonoBehaviour
{
    public TMP_Text pointsText;

    public int points;


    void Start()
    {
        points = 0;
    }

    void Update()
    {
        pointsText.text = points.ToString();
    }

    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
    }
}
