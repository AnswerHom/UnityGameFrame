using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 对象池管理
/// </summary>
public class ObjectPool : BaseManager<ObjectPool> {
    public Dictionary<string, Pool> poolDic;
    private GameObject _poolObj;

    public ObjectPool()
    {
        poolDic = new Dictionary<string, Pool>();
    }

    /// <summary>
    /// 进池
    /// </summary>
    public void intoPool(GameObject obj)
    {
        string name = obj.name;
        if (poolDic.ContainsKey(name))
        {
            poolDic[name].intoPool(obj);
        }else
        {
            Pool p = new Pool(name);
            p.intoPool(obj);
            poolDic.Add(name, p);
            if(_poolObj == null)
            {
                _poolObj = new GameObject();
                _poolObj.name = "Pool";
            }
            p.container.transform.parent = _poolObj.transform;
        }
    }

    /// <summary>
    /// 出池
    /// </summary>
    public GameObject outPool(string name)
    {
        if (poolDic.ContainsKey(name) && poolDic[name].list.Count > 0)
        {
            Pool p = poolDic[name];
            return p.outPool();
        }else
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>(name));
            obj.name = name;
            return obj;
        }
    }

    public void Clear()
    {
        if (poolDic.Count > 0)
        {
            poolDic.Clear();
        }
        if (_poolObj)
        {
            _poolObj = null;
        }
    }
}

/// <summary>
/// 池子
/// </summary>
public class Pool
{
    /// <summary>
    /// 名字
    /// </summary>
    public string name;
    /// <summary>
    /// 对象数组
    /// </summary>
    public List<GameObject> list;
    /// <summary>
    /// 对象容器
    /// </summary>
    public GameObject container;

    public Pool(string str)
    {
        name = str;
        list = new List<GameObject>();
        container = new GameObject();
        container.name = name;
    }

    /// <summary>
    /// 进池(回收)
    /// </summary>
    public void intoPool(GameObject obj)
    {
        obj.SetActive(false);
        list.Add(obj);
        obj.transform.parent = container.transform;
    }

    /// <summary>
    /// 出池
    /// </summary>
    /// <returns></returns>
    public GameObject outPool()
    {
        GameObject obj = list[0];
        list.RemoveAt(0);
        obj.SetActive(true);
        obj.transform.parent = null;
        return obj;
    }
}

