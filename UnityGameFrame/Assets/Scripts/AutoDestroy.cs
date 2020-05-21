using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    void OnEnable()
    {
        Invoke("Destroy", 1);
    }

    private void Destroy()
    {
        ObjectPool.GetInstance().intoPool(this.gameObject);
    }
}
