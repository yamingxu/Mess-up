using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    public GameObject[] roomObj;
    private Vector3[] newPos = new Vector3[51];
    private Vector3[] oldPos = new Vector3[51];
    private float[] distance = new float[51];
    private int[] ifMoved = new int[51];
    private int totalMove = 0;
    public int winNum;
    public bool winning;
    public float moveDist;

    public AudioSource grabSound;

    // Start is called before the first frame update
    void Start()
    {
       
        for (int i = 0; i < roomObj.Length; i++)
        {
            oldPos[i] = roomObj[i].transform.position;
            newPos[i] = oldPos[i];
            distance[i] = Vector3.Distance(oldPos[i], newPos[i]);
            ifMoved[i] = 0;
        }


    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < roomObj.Length; i++)
        {
            newPos[i] = roomObj[i].transform.position;
            distance[i] = Vector3.Distance(oldPos[i], newPos[i]);

            if(distance[i] > moveDist)
            {
                ifMoved[i] = 1;
            }
            totalMove += ifMoved[i];

            if (totalMove == winNum)
            {
                winning = true;
                Debug.Log("You Got all!");
            }


            // Debug.Log(roomObj[i].GetComponent<OVRGrabbable>().grabbedOrNot);
            if (roomObj[i].GetComponent<OVRGrabbable>().isGrabbed == true)
            {
                grabSound.Play();
            }



        }
        totalMove = 0;

        //


    }
}
