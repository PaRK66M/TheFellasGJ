using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    [SerializeField]
    GameObject firePrefab;
    [SerializeField]
    private int numberOfFires;
    public List<GameObject> fireContainer;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfFires; i++)
        {
            fireContainer.Add(Instantiate(firePrefab, transform));
            
            fireContainer[i].SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnFire(Vector3 position)
    {
        int index = GetNextFire();
        fireContainer[index].transform.position = position;
        fireContainer[index].SetActive(true);
        Debug.Log("Fire: " + index);
        Debug.Log("Fire: " + position);
    }

    private int GetNextFire()
    {
        for(int i = 0; i < numberOfFires; i++)
        {
            if (!fireContainer[i].activeSelf)
            {
                return i;
            }
        }

        fireContainer.Add(Instantiate(firePrefab, transform));
        fireContainer[numberOfFires].SetActive(false);
        return numberOfFires++;
    }

    public void ResetFires()
    {
        for (int i = 0; i < numberOfFires; i++)
        {
            fireContainer[i].SetActive(false);
        }
    }
}
