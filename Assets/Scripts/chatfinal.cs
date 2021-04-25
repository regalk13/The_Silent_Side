using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class chatfinal : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject chatzone;
    public GameObject enemy;
    public GameObject oldman;
    public GameObject collider1;
    public GameObject battlezone;

    private girlmove girlmove;

    public void corot()
    {
        StartCoroutine(Type());
    }

    void Update(){
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }
    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void Nextsentence(){

        continueButton.SetActive(false);

        if(index < sentences.Length - 1){
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }else
        {
          textDisplay.text = "";
          continueButton.SetActive(false);
          chatzone.SetActive(false);
          collider1.SetActive(true);
          oldman.SetActive(false);
          enemy.SetActive(true);
          battlezone.SetActive(true);

          girlmove = FindObjectOfType<girlmove>();

          girlmove.canMove = true;
        }
    }
}
