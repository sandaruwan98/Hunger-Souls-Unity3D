using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimap : MonoBehaviour
{
    public Transform objectiveMark;
    public Transform objectiveposition;
    public float radius = 92;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (objectiveposition.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, objectiveposition.position);
        if (distance < radius)
        {
            objectiveMark.position = objectiveposition.position;

        }
        else {
            Ray ray = new Ray(transform.position, direction);
            Vector3 pos = ray.GetPoint(radius);
            objectiveMark.position = pos;
        }
        
    }
}
