using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainUiHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject RecipePanel;

    [SerializeField]
    private GameObject TipPanel;

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
        //if the recipe is empty then show a tip instead of the recipe
        if (recipe.materials.Count == 0)
        {
            showTipPanel();
        }
        else
        {
            List<Items> materials = recipe.materials;
            RecipePanel.SetActive(true);
            string materialsText = "";
            foreach (Items item in materials)
            {
                materialsText += item.itemAmountLabel + " " + item.itemName + "\n";
            }
            RecipePanel.GetComponentInChildren<TextMeshProUGUI>().SetText(materialsText);
            
        }
        GameObject.Find("RecipeTitle").GetComponent<Text>().text = recipe.name;
    }
   
    public void hideRecipe()
    {
        RecipePanel.SetActive(false);
    }

    public void showTipPanel()
    {
        TipPanel.SetActive(true);
        
    }
    public void hideTipPanel()
    {
        TipPanel.SetActive(false);
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
        BowlHandler.itemsUsed = new List<Items>(); //reset the list so it doesn't hold the previous items
    }

    public void goToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        BowlHandler.itemsUsed = new List<Items>(); //reset the list so it doesn't hold the previous items
    }

    public void goToMenu()
    {
        Debug.Log("Go to Menu");
    }
}
