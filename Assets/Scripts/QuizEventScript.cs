using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class QuizEventScript : MonoBehaviour
{
    public TMPro.TMP_Text quizText;

    public Button answer1;
    public Button answer2;
    public Button answer3;

    TMPro.TMP_Text answer1Text;
    TMPro.TMP_Text answer2Text;
    TMPro.TMP_Text answer3Text;

    private List<string> answers;
    private int correctAnswerIndex;
    private int wrongAnswers;

    public PointsSystem pointsSystem;

    void OnEnable()
    {
        // Disable the text and buttons

        quizText.enabled = false;
        answer1.image.enabled = false;
        answer2.image.enabled = false;
        answer3.image.enabled = false;

        answer1Text = answer1.GetComponentInChildren<TMPro.TMP_Text>();
        answer2Text = answer2.GetComponentInChildren<TMPro.TMP_Text>();
        answer3Text = answer3.GetComponentInChildren<TMPro.TMP_Text>();

        answer1.onClick.AddListener(() => CheckAnswer(0));
        answer2.onClick.AddListener(() => CheckAnswer(1));
        answer3.onClick.AddListener(() => CheckAnswer(2));

        wrongAnswers = 0;

    }

    public void QuizStart(string questionString, string answer1String, string answer2String, string answer3String)
    { 
        quizText.enabled=true;
        answer1.image.enabled=true;
        answer2.image.enabled=true;
        answer3.image.enabled=true;

        quizText.text = questionString;

        // Define the answers and the correct answer
        answers = new List<string> { answer1String, answer2String, answer3String};
        correctAnswerIndex = 0; // First element is the correct answer

        // Shuffle answers list
        ShuffleAnswers();

        // Assign shuffled answers to the buttons
        answer1Text.text = answers[0];
        answer2Text.text = answers[1];
        answer3Text.text = answers[2];
    }

    private void ShuffleAnswers()
    {
        // Shuffle the answers and keep track of the correct answer index
        for (int i = answers.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            string temp = answers[i];
            answers[i] = answers[randomIndex];
            answers[randomIndex] = temp;

            // Update the correct answer index if it was swapped
            if (randomIndex == correctAnswerIndex) correctAnswerIndex = i;
            else if (i == correctAnswerIndex) correctAnswerIndex = randomIndex;
        }
    }

    private void CheckAnswer(int index)
    {
        // Check if the answer was correct and give corrisponding points

        if (index == correctAnswerIndex)
        {
            Debug.Log("Correct!");

            quizText.enabled = false;
            answer1.image.enabled = false;
            answer2.image.enabled = false;
            answer3.image.enabled = false;

            answer1Text.text = " ";
            answer2Text.text = " ";
            answer3Text.text = " ";

            if(wrongAnswers == 0)
            {
                pointsSystem.AddPoints(3);
            }
            else if (wrongAnswers == 1)
            {
                pointsSystem.AddPoints(2);
            }
            else if (wrongAnswers == 2)
            {
                pointsSystem.AddPoints(1);
            }

            wrongAnswers = 0;
        }
        else
        {
            Debug.Log("Wrong!");
            
            wrongAnswers++;
        }
    }
}

