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

    public void Start()
    {
        QuestionnairePanel = GameObject.Find("QuestionnairePanel");
        QuestionnairePanel.GetComponentInChildren<TextMeshProUGUI>().SetText(QnA[0].question);
    }

    public void onAnwer(Text answerHolder)
    {
        string answer = answerHolder.text;
        if (answer.Equals(QnA[0].answer))
        {
            CompletedTaskPanel.SetActive(true);
            QuestionnairePanel.SetActive(false);
        }
        else
        {
            FailedTaskPanel.SetActive(true);
            QuestionnairePanel.SetActive(false);
        }
    }
}
