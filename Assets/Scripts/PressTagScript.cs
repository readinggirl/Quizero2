using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class PressTagScript : MonoBehaviour
{
    public string question;

    public string correctAnswer;
    public string answer2;
    public string answer3;

    public QuizEventScript eventScript;
    
    void OnEnable()
    {
        // Only for testing purposes!!
        TouchSimulation.Enable();
    }

    
    void Update()
    {
        // System to detect screen touches
        if (Input.touchCount > 0)
        {
            UnityEngine.Touch touch = Input.GetTouch(0);

            if (touch.phase == UnityEngine.TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null && hit.collider == GetComponent<Collider>())
                    {
                   

                        eventScript.QuizStart(question,correctAnswer,answer2,answer3);
                    }
                }
            }
        }
    }
}
