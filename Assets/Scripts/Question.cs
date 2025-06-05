using System;
using System.Collections.Generic;
using UnityEngine;

public class Question
{
    public string Text { get; set; }
    public List<String> Choices { get; set; }
    public int CorrectAnswerIndex { get; set; }
    public int Points { get; set; }
    
    internal class Location {
        public int LocationX { get; set; }
        public int LocationY { get; set; }
    }
}
