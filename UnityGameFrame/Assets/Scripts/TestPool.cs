using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPool : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            ObjectPool.GetInstance().outPool("Test/Cube");
        }
        if (Input.GetMouseButtonDown(1))
        {
            ObjectPool.GetInstance().outPool("Test/Sphere");
        }
    }
}
