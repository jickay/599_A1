using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LabApp;
using UnityEditor.Animations;

public class Main : MonoBehaviour
{
    // Adjust the speed for the application.
    public float speed = 1.0f;

    private Vector3 startPos = new Vector3(-0.175f, 0.2f, 0.0f);


    private GameObject currentTarget;
    private LabImageBehaviour script;

    // Start is called before the first frame update
    void Start()
    {
        GameObject imageTarget = GameObject.Find("ImageTarget");
        script = imageTarget.GetComponent<LabImageBehaviour>();
        currentTarget = script.currentTarget;

        gameObject.GetComponent<Animator>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Before position: " + transform.position);

        if (Vector3.Distance(transform.position, currentTarget.transform.position) >= 0.2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, speed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, currentTarget.transform.position) <= 0.2f)
        {
            Debug.Log("At target!");
            if (currentTarget == script.target)
            {
                currentTarget = script.target2;
            }
            else if (currentTarget == script.target2)
            {
                currentTarget = script.target3;
            } else if (currentTarget == script.target3)
            {
                Debug.Log(transform.position);
                gameObject.GetComponent<Animator>().enabled = true;
            }
            Debug.Log("New target: " + currentTarget.name);
        }

        //Debug.Log(currentTarget.name);
        //Debug.Log("Target position: " + currentTarget.transform.position);
        //Debug.Log("After position: " + transform.position);
    }

    void StartAnimation()
    {
        Debug.Log("Start Animation");
    }

    void EndAnimation()
    {
        Debug.Log("End Animation");
        transform.position = startPos;

        currentTarget = script.target;

        gameObject.GetComponent<Animator>().enabled = false;

    }
}
