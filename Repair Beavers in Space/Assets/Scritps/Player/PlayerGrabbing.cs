using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabbing : MonoBehaviour
{

    public Transform grabAnchor;
    public Transform releaseAnchor;

    private Grabbable newestGrabbable;
    private Grabbable heldObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleGrabRelease()
    {
        if (heldObject == null)
        {
            if (this.newestGrabbable != null)
            {
                ExecuteGrab(this.newestGrabbable);
                this.newestGrabbable = null;
            }
        }
        else
        {
            ExecuteRelease();
        }
    }

    private void ExecuteGrab(Grabbable grabbable)
    {
        grabbable.TogglePhysics(false);
        grabbable.transform.SetParent(grabAnchor);
        grabbable.transform.localPosition = Vector3.zero;
        grabbable.transform.localRotation = Quaternion.identity;

        heldObject = grabbable;
    }

    private void ExecuteRelease()
    {
        heldObject.transform.position = releaseAnchor.position;
        heldObject.transform.parent = null;
        heldObject.TogglePhysics(true);

        heldObject = null;
    }

    // these 2 methods should be reworked later
    public void CanGrabThis(Grabbable grabbable)
    {
        this.newestGrabbable = grabbable;
    }

    public void CannotGrabThisAnymore(Grabbable grabbable)
    {
        if(this.newestGrabbable == grabbable)
        {
            this.newestGrabbable = null;
        }
    }
}
