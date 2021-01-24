using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour{

    public Transform objectToFollow;
    public bool doUnparent = true;
    public bool doLookAtCamera = true;
    public bool invertLookAt = true;
    
    private Transform tr;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start(){
        tr = GetComponent<Transform>();
        if(doUnparent)
            tr.parent = null;

        offset = tr.position - objectToFollow.position;

       
    }

    void LateUpdate(){
        if(objectToFollow == null){
            //gameObject.SetActive(false);
            return;
        }
        tr.position = objectToFollow.position + offset;

        if(doLookAtCamera){
            tr.LookAt(Camera.main.GetComponent<Transform>());
            if(invertLookAt)
                tr.Rotate(Vector3.up*180, Space.Self);
        }
    }
}
