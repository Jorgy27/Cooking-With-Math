using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUiHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject RecipePanel;

    [SerializeField]
    private GameObject QuestionnairePanel;

    [SerializeField]
    private GameObject FailedTaskPanel;

    [SerializeField]
    private GameObject CompletedTaskPanel;

    [SerializeField]
    private CraftingRecipe recipe;

    private void Start()
    {
        showRecipe();
    }

    //enable and load the recipe panel
    public void showRecipe()
    {
        RecipePanel.SetActive(true);
        List<Items> materials = recipe.materials;
        string materialsText = "";
        foreach (Items item in materials)
        {
            materialsText += item.itemAmountLabel + " " + item.itemName + "\n";
        }
        RecipePanel.GetComponentInChildren<TextMeshProUGUI>().SetText(materialsText);
        GameObject.Find("RecipeTitle").GetComponent<Text>().text = recipe.name;
    }

    public void hideRecipe()
    {
        RecipePanel.SetActive(false);
    }

    public void onCraftClick(CraftingRecipe recipe)
    {
        //get the full list of questions and answers from the QuestionnaireHandler
        List<QuestionAndAnswer> qna = QuestionnairePanel.GetComponent<QuestionnaireHandler>().QnA;

        //enable the questionnaire panel
        bool canBeCrafted = recipe.CanCraft();

        if (canBeCrafted && qna.Count!=0)
        {
            QuestionnairePanel.SetActive(true);
        }
        else if(canBeCrafted && qna.Count == 0)
        {
            CompletedTaskPanel.SetActive(true);
        }
        else
        {
            FailedTaskPanel.SetActive(true);
        }
    }

    public void restartScene()
    {
        //reloads the active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void goToNextScene()
    {
        Debug.Log("Next Level");
    }

    public void goToMenu()
    {
        Debug.Log("Go to Menu");
    }
}
