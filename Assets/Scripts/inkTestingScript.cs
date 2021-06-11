using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class inkTestingScript : MonoBehaviour
{
    public TextAsset inkJSON;
    private Story story;

    public Text textPrefab;
    public Button buttonPrefab;


    // Start is called before the first frame update
    public void init()
    {
        story = new Story(inkJSON.text);  

        refreshUI();   
    }

    void refreshUI()
    {
        eraseUI();

        Text storyText = Instantiate(textPrefab) as Text;
        string text = loadStoryChunk();

        List<string> tags = story.currentTags;


        if(tags.Count > 0)
        {   
            text = "<b>" + tags[0] + "</b> - " +  text;
        }

        storyText.text = text;
        storyText.transform.SetParent(this.transform, false);

        foreach (Choice choice in story.currentChoices)
        {
            Button choiceButton = Instantiate(buttonPrefab) as Button;
            Text choiceText = buttonPrefab.GetComponentInChildren<Text>();
            choiceText.text = choice.text;
            choiceButton.transform.SetParent(this.transform, false);

            choiceButton.onClick.AddListener(delegate{
                chooseStoryChoice(choice);
            });
        }
    }

    void eraseUI()
    {
        for(int i = 0; i < this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }

    void chooseStoryChoice(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        refreshUI();  
    }

    string loadStoryChunk()
    {
        string text = "";

        if(story.canContinue)
        {
            text = story.ContinueMaximally();
        }
       return text;
    }
}
