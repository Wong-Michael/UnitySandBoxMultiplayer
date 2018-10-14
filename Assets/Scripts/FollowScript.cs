using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour {
    public Transform targetTransform;
    public int speed = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        followTarget(targetTransform);	
	}

    void followTarget(Transform target)
    {
        Vector3 totalDisplacement = target.position - this.transform.position;
        Vector3 direction = totalDisplacement.normalized;
        float displacementMagnitude = totalDisplacement.magnitude;
        if (displacementMagnitude > 1.5f)
        {
            this.transform.Translate(direction * speed * Time.deltaTime);   
        }
    }
}
