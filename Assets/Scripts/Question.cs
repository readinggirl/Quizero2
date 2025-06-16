using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public string text;
    public string[] choices;
    public string correctAnswerIndex;
    public string locationX;
    public string locationY;
}

[System.Serializable]
public class QuestionList {
    public Question[] questions;
}
