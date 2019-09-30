
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [Header("Horizontal Spawn Area")]
    [SerializeField]
    private float spawnScaleX, distanceBetweenPlatforms = 3;

    [SerializeField]
    private string poolName = "Platform_Pool";

    [Header("Pooled Platforms")]
    [SerializeField]
    private List<GameObject> pooledPlatforms = new List<GameObject>();

    GameObject platform;
    private GameObject screenTop;

    // Start is called before the first frame update
    void Start()
    {
        //Load the Platform prefab as Resource
        platform = Resources.Load<GameObject>("Platform");
        screenTop = GameObject.Find("ScreenTop");
    }

    void OnDrawGizmos()
    {
        Vector2 t = transform.position;

        Gizmos.DrawLine(new Vector2(t.x - spawnScaleX / 2, t.y), new Vector2(t.x + spawnScaleX / 2, t.y));
    }

    void FixedUpdate()
    {
        CheckPosAndSpawn();
    }

    void CheckPosAndSpawn()
    {
        //If the top of the screen is higher than the generator. Spawn an object in
        if (screenTop.transform.position.y >= gameObject.transform.position.y)
        {
            InstPlatform(new Vector2(Mathf.Ceil(Random.Range(-spawnScaleX / 2, spawnScaleX / 2)), transform.position.y));

            //Set the position to the top + the distance between platforms
            transform.position = new Vector2(0f, transform.position.y + distanceBetweenPlatforms);
        }
    }

    /// <summary>
    /// Instantiates a platform
    /// </summary>
    /// <param name="_pos">Vector2 position</param>
    void InstPlatform(Vector2 _pos)
    {
        //If there is no pool, create one
        if (GameObject.Find(poolName) == null)
            new GameObject().name = poolName;

        GameObject _pooledObject = null;

        //Check if there is a non-active platform left
        for (int i = 0; i < pooledPlatforms.Count; ++i)
        {
            if (!pooledPlatforms[i].activeSelf)
            {
                _pooledObject = pooledPlatforms[i];
            }
        }

        //If there is no non-active platform left, create one
        if (_pooledObject == null)
        {
            GameObject _platform = Instantiate<GameObject>(platform);
            pooledPlatforms.Add(_platform);// Add the new platform to the list
            _platform.transform.position = _pos;
            _platform.transform.parent = GameObject.Find(poolName).transform;
        }
        else
        {
            GameObject _platform = _pooledObject;
            _platform.SetActive(true);
            _platform.transform.position = _pos;
        }
        
    }
}
