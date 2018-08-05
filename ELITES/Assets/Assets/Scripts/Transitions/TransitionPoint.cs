using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionPoint : MonoBehaviour
{
    
    // code from 2D Gamekit (Unity tutorial)
    public enum TransitionType
    {
        DifferentZone, DifferentNonGameplayScene, SameScene,
    }

    public enum TransitionLocation
    {
        HQ, Village, OddballHouse, OddballBasement, OddballBoss, Nightmare, MonsterNest,
    }



    public enum TransitionWhen
    {
        InteractPressed, OnTriggerEnter,
    }

    [Tooltip("This is the gameobject that will transition.  For example, the player.")]
    public GameObject transitioningGameObject;
    PlayerProgression playerProgression;

    [Tooltip("Whether the transition will be within this scene, to a different zone or a non-gameplay scene.")]
    public TransitionType transitionType;
    
    [Tooltip("The destination in this scene that the transitioning gameobject will be teleported.")]
    public TransitionPoint destinationTransform;

    [Tooltip("What should trigger the transition to start.")]
    public TransitionWhen transitionWhen;

    [Tooltip("The player will lose control when the transition happens but should the axis and button values reset to the default when control is lost.")]
    public bool resetInputValuesOnTransition = true;

    //[Tooltip("Is this transition only possible with specific items in the inventory?")]
    //public bool requiresInventoryCheck;
    //[Tooltip("The inventory to be checked.")]
    //public InventoryController inventoryController;
    //[Tooltip("The required items.")]
    //public InventoryController.InventoryChecker inventoryCheck;
    //private Vector3 destinationTransform;

    bool m_TransitioningGameObjectPresent;


    // Use this for initialization
    void Start()
    {
        playerProgression = transitioningGameObject.GetComponent<PlayerProgression>();

    }

    // Update is called once per frame
    void Update()
    {
        //if (ScreenFader.IsFading || SceneController.Transitioning)
        //    return;

        if (!m_TransitioningGameObjectPresent)
            return;

        if (transitionWhen == TransitionWhen.InteractPressed)
        {
            if (Input.GetKey(KeyCode.E) && playerProgression.getQuestLevel() >= 1) // (PlayerInput.Instance.Interact.Down)
            {
                Debug.Log("Interact Open");
                TransitionInternal();
            }
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == transitioningGameObject)
        {
            Debug.Log("triggered");
            m_TransitioningGameObjectPresent = true;

            //if (ScreenFader.IsFading || SceneController.Transitioning)
            //    return;

            if (transitionWhen == TransitionWhen.OnTriggerEnter)
                TransitionInternal();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == transitioningGameObject)
        {
            m_TransitioningGameObjectPresent = false;
        }
    }

    // main transition function 

    protected void TransitionInternal()
    {
        //if (requiresInventoryCheck)
        //{
        //    if (!inventoryCheck.CheckInventory(inventoryController))
        //        return;
        //}


        if (transitionType == TransitionType.SameScene)
        {
            Debug.Log("transitioning");
            Teleport(transitioningGameObject, destinationTransform);
        }
        //else
        //{
        //    SceneController.TransitionToScene(this);
        //}
    }

    public void Transition()
    {
        if (!m_TransitioningGameObjectPresent)
            return;

    }

    public void Teleport(GameObject transitioningGameObject, TransitionPoint destination)
    {
        Debug.Log("teleporting");
        transitioningGameObject.transform.position = destination.transform.position;
        
    }


}
