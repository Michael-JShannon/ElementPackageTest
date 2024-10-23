using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    public ElementManager elementManager;

    public GameObject[] cubes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < cubes.Length; i++)
        {
            if (cubes[i] != null && cubes[i].GetComponent<Damageable>().health <= 0)
            {
                Destroy(cubes[i]);
            }
        }
    }

    void AddCube(GameObject newCube)
    {
        for(int i = 0; i < cubes.Length; i++)
        {
            if (cubes[i] == null)
            {
                cubes[i] = newCube;
                break;
            }
        }
    }

    public void GenerateCube(GameObject cube)
    {
        GameObject newCube = Instantiate(cube);
        elementManager.AssignRandomElementToObject(newCube);
        AddCube(newCube);
    }
}
