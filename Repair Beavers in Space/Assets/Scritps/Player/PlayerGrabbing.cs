using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabbing : MonoBehaviour
{

    public Transform grabAnchor;

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

    public void TryGrabbing()
    {
        if(this.newestGrabbable != null)
        {
            ExecuteGrab(this.newestGrabbable);
            this.newestGrabbable = null;
        }
    }

    private void ExecuteGrab(Grabbable grabbable)
    {
        grabbable.rigidbody.isKinematic = true;
        grabbable.transform.SetParent(grabAnchor);
        grabbable.transform.localPosition = Vector3.zero;
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
