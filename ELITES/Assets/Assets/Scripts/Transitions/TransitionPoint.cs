using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionPoint : MonoBehaviour
{
    private readonly Vector3[] locations;
    [System.Serializable]
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
        ExternalCall, InteractPressed, OnTriggerEnter,
    }

    [Tooltip("This is the gameobject that will transition.  For example, the player.")]
    public GameObject transitioningGameObject;
    [Tooltip("Whether the transition will be within this scene, to a different zone or a non-gameplay scene.")]
    public TransitionType transitionType;
    //[SceneName]
    //public string newSceneName;
    //[Tooltip("The tag of the SceneTransitionDestination script in the scene being transitioned to.")]
    //public SceneTransitionDestination.DestinationTag transitionDestinationTag;
    //[Tooltip("The destination in this scene that the transitioning gameobject will be teleported.")]
    //public TransitionPoint destinationTransform;
    [Tooltip("Which map to transport to")]
    public TransitionLocation transitionLocation;
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
    private Vector3 destinationTransform;

    bool m_TransitioningGameObjectPresent;


    // Use this for initialization
    void Start()
    {
        //if (transitionWhen == TransitionWhen.ExternalCall)
        //    m_TransitioningGameObjectPresent = true;
        
        locations[0] = new Vector3(-0.16f,9.54f,0f);
        locations[1] = new Vector3(-17.2f, 0.32f, 0.37f);
        locations[2] = new Vector3(19.38f, 12.72f, 0f);


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
            if (Input.GetKey(KeyCode.E)) // (PlayerInput.Instance.Interact.Down)
            {
                Debug.Log("Left click");
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

        if (transitionLocation == TransitionLocation.HQ)
        {
            destinationTransform = locations[0];

        }

        if (transitionLocation == TransitionLocation.Village)
        {
            destinationTransform = new Vector3(-17.2f, 0.32f, 0.37f);

        }

        if (transitionLocation == TransitionLocation.OddballHouse)
        {
            destinationTransform = locations[2];

        }


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

        if (transitionWhen == TransitionWhen.ExternalCall)
            TransitionInternal();
    }

    public static void Teleport(GameObject transitioningGameObject, Vector3 destination)
    {
        Debug.Log("teleporting");
        transitioningGameObject.transform.position = destination;
    }


}
