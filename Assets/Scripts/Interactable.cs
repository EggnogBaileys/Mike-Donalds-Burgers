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
    public int interacted = 0;

    [Header("Interaction: ")]
    [SerializeField] public eInteractableType InteractableType;
    [SerializeField] public Texture2D cursor_appearance;
    [SerializeField] private string message;
    [SerializeField] private GameObject grabbable;

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
                print("Interacted");
                var index = GameObject.FindWithTag("MainCamera").GetComponent<Player_Movement>().NumberOfHeldItems++;
                GameObject.FindWithTag("MainCamera").GetComponent<Player_Movement>().HeldItems[index] = grabbable;
                Object.Destroy(this.gameObject);
                break;
            case eInteractableType.NPC:
                interacted++;
                print(message); //Test
                //call dialog script like below
                //this.GetComponent<dialogscript>().dialog();
                //Freeze Movement and rotation
                break;
        }
    }
}
