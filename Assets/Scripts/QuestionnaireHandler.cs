using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionnaireHandler : MonoBehaviour
{
    [SerializeField]
    public List<QuestionAndAnswer> QnA;

    [SerializeField]
    private GameObject FailedTaskPanel;

    [SerializeField]
    private GameObject CompletedTaskPanel;

    private GameObject QuestionnairePanel;

    private Queue<QuestionAndAnswer> QnAQueue = new Queue<QuestionAndAnswer>();

    public void Start()
    {
        QuestionnairePanel = GameObject.Find("QuestionnairePanel");

        //set the first question from the existing serialized list
        QuestionnairePanel.GetComponentInChildren<TextMeshProUGUI>().SetText(QnA[0].question);

        //store the questions with the corresponding answers on a queue for better Extensibility
        foreach (QuestionAndAnswer qna in QnA)
        {
            Debug.Log(qna.question);
            QnAQueue.Enqueue(qna);
        }

    }

    public void onAnwer(Text answerHolder)
    {
        string answer = answerHolder.text;
        QuestionAndAnswer questionAndAnswer = QnAQueue.Peek(); //gets the first item without removing it
        if (answer.Equals(questionAndAnswer.answer))
        {
            CompletedTaskPanel.SetActive(true);
            QuestionnairePanel.SetActive(false);
            questionAndAnswer = QnAQueue.Dequeue(); //get the first item and remove it from the queue

            //TODO:set the next question if exists
        }
        else
        {
            FailedTaskPanel.SetActive(true);
            QuestionnairePanel.SetActive(false);
        }
    }
}
