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
    private bool variablesChanged = false;
    private List<string> answers = new List<string>();
    private List<QuestionAndAnswer> QnA;
    private QuestionnaireHandler questionnaireHandler;
    private bool timeRelated = false;

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
        variablesChanged = true;
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
            if (answers[0].Length > 4 && answers[0].Substring(0, 4) == "Time")
            {
                timeRelated = true;

            }
            else
            {
                //set the containers based on the answers saved on the list of questions and answers
                List<string> answerLabels = new List<string> { "Περίμετρος", "Εμβαδόν", "Όγκος με ύψος 1.5" };
                int i = 0;
                foreach (string answer in answers)
                {
                    GameObject answerContainer = Instantiate(valueObject);
                    answerContainer.transform.SetParent(canvas, false);
                    answerContainer.GetComponentInChildren<Text>().text = answerLabels[i].ToString() + ": ";
                    i++;
                }
            }
        }

    }

    public void setChangedValuesTypeQuestions()
    {
        GameObject[] changedValues = GameObject.FindGameObjectsWithTag("ChangedValue");

        questionnaireHandler = QuestionnairePanel.GetComponent<QuestionnaireHandler>();
        string changedAnswer;

        if (timeRelated)
        {
            changedAnswer = changedValues[0].GetComponentInChildren<InputField>().text;

            if (changedAnswer == "")
            {
                resetChangedValues();
            }
            else
            {
                changedAnswer = "Time+" + changedValues[0].GetComponentInChildren<InputField>().text.Split(' ')[0];
                questionnaireHandler.QnA[0] = new QuestionAndAnswer(QnA[0].question, changedAnswer);
            }

        }
        else
        {
            //if it is not time related then changable questions exist only in the last scene that holds multiple questions and answers
            for (int i = 0; i < QnA.Count; i++)
            {
                changedAnswer = changedValues[i + 2].GetComponentInChildren<InputField>().text;

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
        changeUiText(changedValues);
        
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
        if (variablesChanged)
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

    private void changeUiText(GameObject[] changedValueTextUI)
    {
        int amountOfAnswersToChange;
        if (timeRelated) //If it is timerelated then there is no need to change the answer of the question since it computes it on real time
        {
            amountOfAnswersToChange = 0;
        }
        else
        {
            amountOfAnswersToChange = answers.Count;
        }

        for (int i = 0; i <= changedValueTextUI.Length - (amountOfAnswersToChange + 1); i++)
        {
            string changed = changedValueTextUI[i].GetComponentInChildren<InputField>().text;
            //if the was no change done then keep the original text that is already kept within the placeholder of the input field
            if (changed == "")
            {
                string preText = changedValueTextUI[i].GetComponentInChildren<InputField>().placeholder.GetComponent<Text>().text;
                valuesToChange[i].GetComponentInChildren<TMP_Text>().SetText(preText);
            }
            else
            {
                valuesToChange[i].GetComponentInChildren<TMP_Text>().SetText(changed);
            }

        }
    }
}
