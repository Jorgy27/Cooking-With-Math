using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeValues : MonoBehaviour
{
    private GameObject[] valuesToChange;
    [SerializeField]
    private GameObject valueObject;
    [SerializeField]
    private Transform canvas;
    [SerializeField]
    private CraftingRecipe recipe;
    [SerializeField]
    private GameObject QuestionnairePanel;

    private float originalAmountOfRecipe;
    private bool isRecipe;
    private List<string> answers = new List<string>();
    private List<QuestionAndAnswer> QnA;
    private QuestionnaireHandler questionnaireHandler;

    private void Start()
    {
        if (recipe.materials.Count != 0)
        {
            isRecipe = true;
            //set the original amount of the recipe so it is reset once the problem is solved with the changed values
            originalAmountOfRecipe = recipe.materials[0].itemAmount;
        }
        else
        {
            //save original list of questions and answers
            QnA = QuestionnairePanel.GetComponent<QuestionnaireHandler>().QnA;
            foreach (QuestionAndAnswer qna in QnA)
            {
                answers.Add(qna.answer);
            }
        }
        getValuesForChange();
    }
    public void getValuesForChange()
    {
        valuesToChange = GameObject.FindGameObjectsWithTag("ChangeableValue");
        //for every changeable value create its representative input field
        for(int i = 0; i <= valuesToChange.Length-1; i++)
        {
            GameObject value = Instantiate(valueObject);
            value.transform.SetParent(canvas,false);
            value.GetComponentInChildren<Text>().text = valuesToChange[i].GetComponent<TMP_Text>().text;
            value.SetActive(true);
        }

        if (isRecipe)
        {
            GameObject answer = Instantiate(valueObject);
            answer.transform.SetParent(canvas, false);
            answer.GetComponentInChildren<Text>().text = "Λύση: ";

        }
        else
        {
            //set the containers based on the answers saved on the list of questions and answers
            List<string> answerLabels = new List<string> { "Περίμετρος", "Εμβαδόν", "Όγκος" };
            int i = 0;
            foreach(string answer in answers)
            {
                GameObject answerContainer = Instantiate(valueObject);
                answerContainer.transform.SetParent(canvas, false);
                answerContainer.GetComponentInChildren<Text>().text = answerLabels[i].ToString()+": ";
                i++;
            }
        }

    }

    public void setChangedValuesTypeQuestions()
    {
        GameObject[] changedValues = GameObject.FindGameObjectsWithTag("ChangedValue");
        for (int i = 0; i <= changedValues.Length - (answers.Count+1); i++)
        {
            string changed = changedValues[i].GetComponentInChildren<InputField>().text;
            //if the was no change done then keep the original text that is already kept within the placeholder of the input field
            if(changed == "")
            {
                string preText = changedValues[i].GetComponentInChildren<InputField>().placeholder.GetComponent<Text>().text;
                valuesToChange[i].GetComponentInChildren<TMP_Text>().SetText(preText);
            }
            else
            {
                valuesToChange[i].GetComponentInChildren<TMP_Text>().SetText(changed);
            }
            
        }

        questionnaireHandler = QuestionnairePanel.GetComponent<QuestionnaireHandler>();
        for (int i = 0; i < QnA.Count; i++)
        {
            string changedAnswer = changedValues[i + 2].GetComponentInChildren<InputField>().text;
            if (changedAnswer == "")
            {
                resetChangedValues();
            }
            else
            {
                questionnaireHandler.QnA[i] = new QuestionAndAnswer(QnA[i].question, changedAnswer);
            }
           
        }
    }

    public void setChangedValuesTypeRecipe()
    {
        GameObject[] changedValues = GameObject.FindGameObjectsWithTag("ChangedValue");
        for(int i=0; i <= changedValues.Length - 2; i++)
        {
            string changed = changedValues[i].GetComponentInChildren<InputField>().text;
            //if the was no change done then keep the original text that is already kept within the placeholder of the input field
            if (changed == "")
            {
                string preText = changedValues[i].GetComponentInChildren<InputField>().placeholder.GetComponent<Text>().text;
                valuesToChange[i].GetComponentInChildren<TMP_Text>().SetText(preText);
            }
            else
            {
                valuesToChange[i].GetComponentInChildren<TMP_Text>().SetText(changed);
            }
        }

        string newValue = changedValues[changedValues.Length - 1].GetComponent<InputField>().text;
        if (newValue == "")
        {
            resetChangedValues();
        }
        else
        {
            //update recipe with the new value
            recipe.materials[0] = new Items(recipe.materials[0].itemName, float.Parse(newValue), recipe.materials[0].itemAmountLabel);
        }

        
    }

    public void resetChangedValues()
    {
        if (isRecipe)
        {
            recipe.materials[0] = new Items(recipe.materials[0].itemName, originalAmountOfRecipe, recipe.materials[0].itemAmountLabel);
        }
        else
        {
            questionnaireHandler = QuestionnairePanel.GetComponent<QuestionnaireHandler>();
            for (int i = 0; i < QnA.Count; i++)
            {
                questionnaireHandler.QnA[i] = new QuestionAndAnswer(QnA[i].question, QnA[i].answer);
            }
        }
        
    }
}
