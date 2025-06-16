using System;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;

public class LoadQuestions : MonoBehaviour {
    public static TextAsset jsonFile;

    private void Start() { 
        var questions = LoadFromJson();
    }

    public static Question[] LoadFromJson() {
        var tmpList = JsonUtility.FromJson<QuestionList>(jsonFile.text);

        foreach (var question in tmpList.questions)
        {
            Debug.Log("Question: " + question.text);
            Debug.Log("Correct Answer: " + question.choices[int.Parse(question.correctAnswerIndex)]);
        }

        return tmpList.questions;
    }
}