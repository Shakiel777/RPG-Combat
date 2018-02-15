using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AICharacterControl))]
[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{


    ThirdPersonCharacter thirdPersonCharacter = null;   // A reference to the ThirdPersonCharacter on the object
    CameraRaycaster cameraRaycaster = null;
    Vector3 currenDestination, clickPoint;
    AICharacterControl aiCharacterControl = null;
    GameObject walkTarget = null;

    [SerializeField] const int walkableLayerNumber = 8;
    [SerializeField] const int enemyLayerNumber = 9;

    bool isInDirectMode = false;  
        
    void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        thirdPersonCharacter = GetComponent<ThirdPersonCharacter>();
        currenDestination = transform.position;
        aiCharacterControl = GetComponent<AICharacterControl>();
        walkTarget = new GameObject("walkTarget");

        cameraRaycaster.notifyMouseClickObservers += ProcessMouseClick;
    }

    void ProcessMouseClick(RaycastHit raycastHit, int layerHit)
    {
        switch (layerHit)
        {
            case enemyLayerNumber:
                // navigate to the enemy
                GameObject enemy = raycastHit.collider.gameObject;
                aiCharacterControl.SetTarget(enemy.transform);
                break;
            case walkableLayerNumber:
                // navigate to point on the ground
                walkTarget.transform.position = raycastHit.point;
                aiCharacterControl.SetTarget(walkTarget.transform);
                break;
            default:
                Debug.LogWarning("Don't know how to handle mouse click for the player movement");
                return;
        }

    }


    // TODO make this get called again
    void ProcessDirectMovement()
    {
        // read inputs
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // calculate camera relative direction to move:
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 movement = v * cameraForward + h * Camera.main.transform.right;

        thirdPersonCharacter.Move(movement, false, false);
    }




    //private void OnDrawGizmos()
    //{
    //    // draw movement gizmos
    //    Gizmos.color = Color.black;
    //    Gizmos.DrawLine(transform.position, currenDestination);
    //    Gizmos.DrawSphere(currenDestination, .1f);
    //    Gizmos.DrawSphere(clickPoint, .15f);

    //    // draw attack sphere
    //    Gizmos.color = new Color(255f, 0f, 0, .5f);
    //    Gizmos.DrawWireSphere(transform.position, attackMoveStopRadius);
    //}
}

