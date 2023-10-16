using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlights : MonoBehaviour
{
    // Start is called before the first frame update
    public Quaternion wantedRot;
    public Quaternion startedRot;
    public Quaternion resetRot;
    void Start()
    {
        startedRot = transform.rotation;
        resetRot = startedRot;
    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation = Quaternion.Slerp(transform.rotation, wantedRot, 0.05f);
    }
    private void LateUpdate()
    {
            if (transform.rotation == wantedRot)
            {
                Debug.Log("Reverse");
                if (wantedRot == startedRot)
                {
                    wantedRot = resetRot;
                }
                else
                {
                    wantedRot = startedRot;
                    resetRot = transform.rotation;
                }
            }
        }
    }
