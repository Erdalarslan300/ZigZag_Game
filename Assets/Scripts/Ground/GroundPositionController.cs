using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPositionController : MonoBehaviour
{
  
    

    private GroundSpawnController groundSpawnController;

    private Rigidbody rb;

    [SerializeField] private float endYValue;

    private int groundDirection;


    void Start()
    {
        groundSpawnController = FindObjectOfType<GroundSpawnController>();
        rb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        CheckGroundVerticalPosition();
    }


    private void CheckGroundVerticalPosition()
    {
        if (transform.position.y <= endYValue)
        {
            SetRigidBodyValues();
            SetGroundNewPosition();


        }
    }



    private void SetGroundNewPosition()
    {
        groundDirection = Random.Range(0, 2);

        if (groundDirection == 0)
        {
            transform.position = new Vector3(groundSpawnController.lastGroundobject.transform.position.x - 1f, groundSpawnController.lastGroundobject.transform.position.y, groundSpawnController.lastGroundobject.transform.position.z);
        }
        else
        {
            transform.position = new Vector3(groundSpawnController.lastGroundobject.transform.position.x, groundSpawnController.lastGroundobject.transform.position.y, groundSpawnController.lastGroundobject.transform.position.z + 1f);
        }

        groundSpawnController.lastGroundobject = gameObject;
    }

    private void SetRigidBodyValues()
    {
        rb.isKinematic = true;
        rb.useGravity = false;
    }

}
