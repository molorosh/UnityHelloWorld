using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoScreenScript : MonoBehaviour
{

    [SerializeField]
    private float finishZ = -10f;

    [SerializeField]
    private float incrementZ = -0.1f;

    [SerializeField]
    private int delayMilliseconds = 4000;

    [SerializeField]
    private string nextSceneName;

    private DateTime startedAt = DateTime.MinValue;
    private DateTime endedBy = DateTime.MinValue;
    private Transform cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = this.gameObject.transform;
        startedAt = DateTime.Now;
        endedBy = startedAt.AddMilliseconds(delayMilliseconds);
        ToDoMgr.Create();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.z > finishZ)
        {
            //Debug.Log(gameObject.transform.position.z);
            Vector3 pos = gameObject.transform.position;
            pos.z += Time.deltaTime * incrementZ;
            gameObject.transform.position = pos;
        }
        if(DateTime.Now >= endedBy)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
        }
    }
}
