using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootController : MonoBehaviour
{
    public PipeServer pipeServer;
    public Vector3 footPosition1;
    public Vector3 footPosition2;
    public GameObject footPrefab1;
    public GameObject footPrefab2;

    public GameObject footInstance1;
    public GameObject footInstance2;

    void Start()
    {
        footInstance1 = Instantiate(footPrefab1, pipeServer.footPosition1, Quaternion.identity);
        footInstance2 = Instantiate(footPrefab2, pipeServer.footPosition2, Quaternion.identity);
        footInstance1.SetActive(false);
        footInstance2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pipeServer.isPeople)
        {
            footInstance1.SetActive(true);
            footPosition1 = pipeServer.footPosition1;
            footPosition1.y = 0;
            footInstance1.transform.position = footPosition1;

            footInstance2.SetActive(true);
            footPosition2 = pipeServer.footPosition2;
            footPosition2.y = 0;
            footInstance2.transform.position = footPosition2;
        }

    }
}
