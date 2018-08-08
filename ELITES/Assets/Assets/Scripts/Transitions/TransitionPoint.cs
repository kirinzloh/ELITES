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
        InteractPressed, OnTriggerEnter, Automatic
    }

    [Tooltip("This is the gameobject that will transition.  For example, the player.")]
    public GameObject transitioningGameObject;
    public GameObject skeletonSpawnPoint;

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
    public int questLevel;

    // Use this for initialization
    void Start()
    {
    

    }

    // Update is called once per frame
    void Update()
    {
        //if (ScreenFader.IsFading || SceneController.Transitioning)
        //    return;

        if (!m_TransitioningGameObjectPresent)
            return;

        if (transitionWhen == TransitionWhen.InteractPressed && questLevel <= PlayerManager.instance.getQuestLevel())
        {
            if (Input.GetKey(KeyCode.Space) && PlayerManager.instance.getTransitionPermission()) // (PlayerInput.Instance.Interact.Down)
            {
                Debug.Log("Interact Open");
                TransitionInternal();
            }
        }

        if (transitionWhen == TransitionWhen.Automatic && questLevel <= PlayerManager.instance.getQuestLevel())
        {
            TransitionInternal();
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

            if (transitionWhen == TransitionWhen.OnTriggerEnter && questLevel <= PlayerManager.instance.getQuestLevel())
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
        PlayerManager.instance.switchTransition();
        transitioningGameObject.transform.position = destination.transform.position;
        SpawnEnemy spawn = transform.GetComponent<SpawnEnemy>();
        if (spawn != null)
        {
            spawn.enabled = true;
        }
        Destroy(this);
    }


}
