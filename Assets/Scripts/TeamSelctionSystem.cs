using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TeamSelctionSystem : MonoBehaviour
{
    public Button mainButton;

    public GameObject panel;

    public Button[] teamButtons;

    public 
    void Start()
    {
        panel.SetActive(false);

        
    }


    public void SelectTeam()
    {
        panel.SetActive(true);
    }

    public void RedButton()
    {
        mainButton.image.color = teamButtons[0].image.color;

        panel.SetActive(false);
    }
    public void BlueButton()
    {
        mainButton.image.color = teamButtons[1].image.color;

        panel.SetActive(false);
    }
    public void GreenButton()
    {
        mainButton.image.color = teamButtons[2].image.color;

        panel.SetActive(false);
    }
    public void YellowButton()
    {
        mainButton.image.color = teamButtons[3].image.color;

        panel.SetActive(false);
    }
    public void PinkButton()
    {
        mainButton.image.color = teamButtons[4].image.color;

        panel.SetActive(false);
    }
    public void BlackButton()
    {
        mainButton.image.color = teamButtons[5].image.color;

        panel.SetActive(false);
    }
}
