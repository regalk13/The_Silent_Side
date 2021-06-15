using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : Interactable
{
    // Reference to dialog value
    [SerializeField] private TextAssetValue dialogValue;
    // Reference to the NPC dialog
    [SerializeField] private TextAsset myDialog;
    //Notification to send to hte canvases to activate and check
    //dialog
    [SerializeField] private Notification DialogNotification;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange)
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                dialogValue.value = myDialog;
                DialogNotification.Raise();
            }
        }
        
    }
}
