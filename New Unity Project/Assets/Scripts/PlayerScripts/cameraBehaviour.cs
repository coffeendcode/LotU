﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBehaviour : MonoBehaviour
{
    public GameObject wallHit;
    public string objName;
    public wallBehaviour[] wallChildren;
    public Transform playerPos;
    public Vector3 currentPos;
    public Vector3 convoPos;
    public Quaternion currentRot;
    public Quaternion convoRot;
    public Transform newTrans;
    public bool move;

    public bool test;

    // Start is called before the first frame update
    void Start()
    {
        move = false;
        currentRot = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
            
    }

    void FixedUpdate()
    {
        ///
        if (move == false)
        {
            this.transform.position = Vector3.Lerp(new Vector3(playerPos.position.x, 8.554f, playerPos.position.z), new Vector3(this.transform.position.x - 4.5f, 15.554f, this.transform.position.z), 0.7f);
            this.transform.rotation = currentRot;
        }

        ///Raycast
        RaycastHit hit;
        LayerMask mask = LayerMask.GetMask("TransparentFX");

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, mask))  //if the raycast hits an object with the mask TransparentFX
        {
            objName = hit.collider.gameObject.name;                                 //name of object hit by raycast
            wallHit = hit.collider.gameObject;                                     //wall name hit by raycast
            wallChildren = wallHit.GetComponentsInChildren<wallBehaviour>();        //children objects from original object hit by raycast
            

            /*
             *if the object hit is a wall && the object isnt a sidewall
             *find the children and set their var visible to false
             
             *if the raycast doesnt hit the object anymore set the children visibility to true
             *set the raycast hits to false
             *honestly not sure if the last 61 && 62 do anything
             
             *if raycast doesnt hit a wall set last objects hit to false (redundant?)
            */
            if (wallHit != null)
            {
                if (hit.collider.name == wallHit.name && wallHit.GetComponent<wallBehaviour>().sideWall == false)
                {
                    foreach(wallBehaviour child in wallChildren)
                    {
                        child.hit = true;
                    }
                }
                if (hit.collider.name != objName)
                {

                    foreach (wallBehaviour child in wallChildren)
                    {
                        child.hit = false;
                    }
                    objName = null;
                    wallHit = null;
                    objName = hit.collider.gameObject.name;
                    wallHit = GameObject.Find(objName);
                }

                
                
            }
            else
            {
                foreach (wallBehaviour child in wallChildren)
                {
                    child.hit = false;
                }
            }
        }
        else
        {
            if (wallHit != false)
                foreach (wallBehaviour child in wallChildren)
                {
                    child.hit = false;
                }
            objName = null;
            wallHit = null;
            wallChildren = null;
        }

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward * 100), Color.red);
        //layerMask = ~layerMask;

    }
}
