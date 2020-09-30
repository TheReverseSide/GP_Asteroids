using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private int numOfObjects = 10;
    [SerializeField] private GameObject optionalParent;

    private List<GameObject> pool;
    private bool hasInitialised;

    // Initailzes a pool with the specific number of objects
    public void Init()
    {
        if (spawnPrefab == null)
        {
            Debug.LogError("ObjectPool: spawnPrefab has not been set.", this);
        }
        
        pool = new List<GameObject>(numOfObjects);
        for (int i = 0; i < numOfObjects; i++)
        {
            AddGameObject();
        }

        hasInitialised = true;
    }
    
    //
    public GameObject GetGameObject()
    {
        if (!hasInitialised)
        {
            Debug.LogError("ObjectPool: has not been intialised. Call 'Init' first.", this);
            return null;
        }

        for (int i = 0; i < pool.Count; i++)
        {
            GameObject ob = pool[i];
            if (!ob.activeSelf)
            {
                ob.transform.Translate(Vector3.zero);
                ob.transform.rotation = Quaternion.identity;
                ob.SetActive(true);
                return ob;
            }
        }
        
        // If we made it here, then we have to add another GO
        GameObject additionalGO = AddGameObject();
        additionalGO.SetActive(true);
        return additionalGO;
    }

    public void ReleaseObject(GameObject go)
    {
        go.SetActive(false);
    }

    public void ReleaseAll()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            GameObject ob = pool[i];
            ob.SetActive(false);
        }
    }

    private GameObject AddGameObject() {
        GameObject go = Instantiate( spawnPrefab, Vector3.zero, Quaternion.identity ) as GameObject;
        if( optionalParent == null ) {
            go.transform.SetParent( this.transform );
        } else {
            go.transform.SetParent( optionalParent.transform, true );
        }
        go.SetActive( false );
        pool.Add( go );
        return go;
    }
}

