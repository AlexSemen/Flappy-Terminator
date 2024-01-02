using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _conteiner;
    [SerializeField] private int _capacity;
    
    protected List<GameObject> _pool;


    public void ResetPool()
    {
        foreach (var pool in _pool)
        {
            pool.SetActive(false);
        }
    }

    protected void Initialize(GameObject prefab)
    {
        _pool = new List<GameObject>();

        for (int i = 0; i < _capacity; i++)
        {
            GameObject newObject = Instantiate(prefab);

            if (_conteiner != null) 
            {
                newObject.transform.SetParent(_conteiner.transform);
            }
            
            newObject.SetActive(false);

            _pool.Add(newObject);
        }
    }

    protected void Initialize(GameObject[] prefabs)
    {
        _pool = new List<GameObject>();

        for (int i = 0; i < _capacity; i++)
        {
            GameObject newObject = Instantiate(prefabs[Random.Range(0, prefabs.Length)], _conteiner.transform);
            newObject.SetActive(false);

            _pool.Add(newObject);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        foreach (GameObject obj in _pool)
        {
            if(obj.activeSelf == false)
            {
                result = obj;
                return true;
            }
        }

        result = null;
        return false;
    }


}
