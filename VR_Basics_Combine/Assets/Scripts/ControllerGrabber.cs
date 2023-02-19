using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabber : MonoBehaviour
{
    private bool _grabbingObject;
    private bool _intersectingObject;

    public bool userGrab;
    private GameObject grabbedObject;

    public Material canGrabMaterial;
    private Material _savedMaterial;

    private Vector3 vel;

    // Start is called before the first frame update
    void Start()
    {
        _grabbingObject = false;
        grabbedObject = null;
        vel = new Vector3(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (!userGrab && _grabbingObject)
        {
            grabbedObject.transform.parent = null;
            grabbedObject = null;
            _grabbingObject = false;
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (!_intersectingObject)
        {
            _savedMaterial = other.gameObject.GetComponent<Renderer>().material;
            other.gameObject.GetComponent<Renderer>().material = canGrabMaterial;
            _intersectingObject = true;
        }

    

    }

    public void OnTriggerStay(Collider other)
    {
        if (userGrab && !_grabbingObject)
        {
            if (other.gameObject.CompareTag("grabbable"))
            {
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                _grabbingObject = true;
                grabbedObject = other.gameObject;
               // LockMovement(other.gameObject);
                grabbedObject.transform.SetParent(this.transform);
                
            }

        }
        //else
        //{
        //    UnlockMovement(other.gameObject);
        //}


        //other.gameObject.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity;
        //vel = this.GetComponent<Rigidbody>().velocity;
        




    }

    public void OnTriggerExit(Collider other)
    {
        if (_intersectingObject)
        {
            other.gameObject.GetComponent<Renderer>().material = _savedMaterial;
            _intersectingObject = false;
        }

        
    }

   //void LockMovement(GameObject gameObj) //grab
   // {
   //     gameObj.GetComponent<Rigidbody>().useGravity = false;
   //     gameObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
   // }

   // void UnlockMovement(GameObject gameObj) //release
   // {
   //     gameObj.GetComponent<Rigidbody>().useGravity = true;
   //     gameObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
   // }

}