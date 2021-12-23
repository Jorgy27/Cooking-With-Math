using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct QuestionAndAnswer 
{
    [SerializeField]
    public string question;
    [SerializeField]
    public string answer;

    public QuestionAndAnswer(string question, string answer)
    {
        this.question = question;
        this.answer = answer;
    }
}
