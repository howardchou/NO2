using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public PipeServer pipeServer;
    public Vector3 handDetectionPos1;
    public Vector3 handDetectionPos2;
    public Vector3 headPosition;
    public GameObject headPrefab;
    public Vector3 elbowPos1;
    public Vector3 elbowPos2;
    public float handDistance;
    public Vector3 elbowCenter;
    public GameObject centerPrefab;
    public bool isCircle = false;
    // Start is called before the first frame update
    void Start()
    {
        isCircle = false;
        centerPrefab.SetActive(false);
        headPrefab.SetActive(false);
        handDistance = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        handDetectionPos1 = pipeServer.handDetectionPos1;
        handDetectionPos2 = pipeServer.handDetectionPos2;
        headPosition = pipeServer.headPosition;
        headPosition.y = 0.5f;
        elbowPos1 = pipeServer.elbowPos1;
        elbowPos2 = pipeServer.elbowPos2;
        handDistance = Vector3.Distance(handDetectionPos1, handDetectionPos2);
        if (pipeServer.isPeople)
        {
            detectCircle();
            headPrefab.SetActive(true);
            headPrefab.transform.position = headPosition; 
        }
        if (isCircle)
        {
            headPrefab.SetActive(false);
            elbowCenter = (elbowPos1 + elbowPos2) / 2f;
            elbowCenter.y = 0.5f;
            centerPrefab.SetActive(true);
            centerPrefab.transform.position = elbowCenter;
        }
        else
        {
            centerPrefab.SetActive(false);
        }
    }

    void detectCircle()
    {
        if (handDistance < 3f)
        {
            isCircle = true;
        }
        else isCircle = false;
    }
}
