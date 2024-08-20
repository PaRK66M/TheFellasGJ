using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    [SerializeField]
    GameObject scorchPrefab;
    [SerializeField]
    GameObject firePrefab;
    [SerializeField]
    private int startingScorches;
    private int numberOfScorches = 0;
    private GameObject[] scorchContainer;
    [SerializeField]
    private int startingFires;
    private int numberOfFires;
    private GameObject[] fireContainer;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < startingScorches; i++)
        {
            AddScorchToArray();

            scorchContainer[i].SetActive(false);
        }

        for (int i = 0; i < numberOfFires; i++)
        {
            AddFireToArray();

            fireContainer[i].SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void AddScorchToArray()
    {
        numberOfScorches++;
        GameObject[] newArray = new GameObject[numberOfScorches];
        for (int i = 0; i < numberOfScorches - 1; i++)
        {
            newArray[i] = scorchContainer[i];
        }
        scorchContainer = newArray;
        scorchContainer[numberOfScorches - 1] = Instantiate(scorchPrefab, transform);
        
    }

    private void AddFireToArray()
    {
        numberOfFires++;
        GameObject[] newArray = new GameObject[numberOfFires];
        for (int i = 0; i < numberOfFires - 1; i++)
        {
            newArray[i] = fireContainer[i];
        }
        fireContainer = newArray;
        fireContainer[numberOfFires - 1] = Instantiate(firePrefab, transform);
    }

    public void SpawnScorch(Vector3 position)
    {
        int index = GetNextScorch();
        scorchContainer[index].transform.position = position;
        scorchContainer[index].SetActive(true);
    }

    public void SpawnFire(Vector3 position, Vector3 scale)
    {
        int index = GetNextFire();
        fireContainer[index].transform.position = position;
        fireContainer[index].transform.localScale = scale;
        fireContainer[index].SetActive(true);
    }

    private int GetNextScorch()
    {
        for (int i = 0; i < numberOfScorches; i++)
        {
            if (!scorchContainer[i].activeSelf)
            {
                return i;
            }
        }

        AddScorchToArray();
        scorchContainer[numberOfScorches - 1].SetActive(false);
        return numberOfScorches - 1;
    }

    private int GetNextFire()
    {
        for (int i = 0; i < numberOfFires; i++)
        {
            if (!fireContainer[i].activeSelf)
            {
                return i;
            }
        }

        AddFireToArray();
        fireContainer[numberOfFires - 1].SetActive(false);
        return numberOfFires - 1;
    }

    public void ResetFires()
    {
        for (int i = 0; i < numberOfScorches; i++)
        {
            scorchContainer[i].SetActive(false);
        }

        for (int i = 0; i < numberOfFires; i++)
        {
            fireContainer[i].SetActive(false);
        }
    }

    public void FreezeFires(int leftPosition, int rightPosition)
    {
        for (int i = 0; i < numberOfScorches; i++)
        {
            if (scorchContainer[i].activeSelf)
            {
                if(scorchContainer[i].transform.position.x >= leftPosition && scorchContainer[i].transform.position.x <= rightPosition)
                {
                    scorchContainer[i].SetActive(false);
                }
            }
        }

        for (int i = 0; i < numberOfFires; i++)
        {
            if (fireContainer[i].activeSelf)
            {
                if (fireContainer[i].transform.position.x >= leftPosition && fireContainer[i].transform.position.x <= rightPosition)
                {
                    fireContainer[i].SetActive(false);
                }
            }
        }
    }
}
