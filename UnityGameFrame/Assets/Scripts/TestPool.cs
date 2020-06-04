using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPool : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InputManager.GetInstance();
        EventManager.GetInstance().AddEventListener<int>("进度条变化", onProgress);
        EventManager.GetInstance().AddEventListener<KeyCode>("按键按下", OnKeyDown);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            //ObjectPool.GetInstance().outPool("Test/Cube");
            Debug.Log("============> 同步加载");
            GameObject obj = ResManager.GetInstance().LoadRes<GameObject>("Test/Cube");
            obj.transform.localScale = Vector3.one * 2;
        }
        if (Input.GetMouseButtonDown(1))
        {
            ObjectPool.GetInstance().outPool("Test/Sphere", (obj) =>
            {
                Debug.Log("============> 异步加载");
                obj.transform.localScale = Vector3.one * 2;
            });
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ScenesManager.GetInstance().LoadSceneAsync(1, onLoadScene);
        }
    }

    private void onLoadScene()
    {
        Debug.Log("=========> 加载完成");
    }

    private void onProgress(int info)
    {
        Debug.Log("=========> progress = " + info);
    }

    private void OnKeyDown(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.A:
                MusicManager.GetInstance().PlayBackMusic("Bgm/backMusic");
                break;
            case KeyCode.D:
                MusicManager.GetInstance().StopBackMusic();
                break;
            case KeyCode.W:
                UIManager.GetInstance().HidePanel("LoginPanel");
                break;
            case KeyCode.S:
                UIManager.GetInstance().ShowPanel<LoginPanel>("LoginPanel", UILayer.BOTTOM);
                break;
        }
    }
}
