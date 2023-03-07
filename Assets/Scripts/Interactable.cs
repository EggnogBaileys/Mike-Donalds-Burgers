using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eInteractableType
{
    Object,
    NPC
}

public class Interactable : MonoBehaviour
{
    [Header("Interaction: ")]
    [SerializeField] public eInteractableType InteractableType;
    [SerializeField] public Texture2D cursor_appearance;
    [SerializeField] private string message;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        switch(InteractableType)
        {
            case eInteractableType.Object:
                print(message); //Test
                break;
            case eInteractableType.NPC:
                print(message); //Test
                //call dialog script like below
                //this.GetComponent<dialogscript>().dialog();
                //Freeze Movement and rotation
                break;
        }
    }
}
