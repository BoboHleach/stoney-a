using UnityEngine;

public class levelGenerator : MonoBehaviour
{
    public GameObject cubePrefab;
    // Start is called before the first frame update
    void Start()
    {

        Instantiate(cubePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        for (int i = 0; i < 1000; i++)
        {
            generateCubes();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void generateCubes()
    {
        GameObject[] spawnAbleLocation = GameObject.FindGameObjectsWithTag("ZObject");
        int spawnSelectorInt = Random.Range(0, spawnAbleLocation.Length);
        Collider[] touchingBlocks = Physics.OverlapBox(spawnAbleLocation[spawnSelectorInt].transform.position, new Vector3(0.4f, 0.4f, 0.4f));
        if (touchingBlocks.Length != 0)
        {
            generateCubes();
        }
        else
        {
            if (spawnAbleLocation[spawnSelectorInt].gameObject.transform.position.y > 200 || spawnAbleLocation[spawnSelectorInt].gameObject.transform.position.y < -201)
            {
                generateCubes();
                return;
            }
            GameObject generatedCube = Instantiate(cubePrefab, spawnAbleLocation[spawnSelectorInt].transform.position, Quaternion.identity);
            Destroy(spawnAbleLocation[spawnSelectorInt]);
        }
    }
}
