using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBackground : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 targetToMove = new Vector3(cameraTransform.position.x,cameraTransform.position.y+1, 0);

        transform.position = targetToMove;

    }
}
