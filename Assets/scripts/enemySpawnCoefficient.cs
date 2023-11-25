using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProportionalRandomSelector<T>
{
    
    private readonly Dictionary<T, int> percentageItemsDict;  //T is a generic type parameter which guarantees type safety  
    public ProportionalRandomSelector() => percentageItemsDict = new();
    //function to add an item to dictionary
    public void AddPercentageItem(T item, int percentage) => percentageItemsDict.Add(item, percentage); 

    public T SelectItem() 
    {
        // Calculate the summa of all portions.
        int poolSize = 0;
        foreach (int i in percentageItemsDict.Values) {
            poolSize += i;
        }

        // Get a random integer from 1 to PoolSize.
        int randomNumber = Random.Range(1, poolSize);

        // Detect the item, which corresponds to current random number.
        int accumulatedProbability = 0;
        foreach (KeyValuePair<T, int> pair in percentageItemsDict) { //iterates through dictionary and returns key value pairs of the type T, int
            accumulatedProbability += pair.Value; //current value to the accumulated probability
            if (randomNumber <= accumulatedProbability) // if random number falls within that region e.g. a probability coefficient of 30% might trigger between 0-30
                return pair.Key; //return the string part of key
        }
        
        return default;

    }
}
public class enemySpawnCoefficient : MonoBehaviour
{
    ProportionalRandomSelector<enemyType> randomSelector = new();
    public waveScriptableObject waveSO;

    public enemyScriptableObject[] enemySO;
    public enemyCreditScriptableObject creditSO;
    public GameObject[] enemyPrefab;
    private int credit;
    private GameObject enemy;
    private float spawnInterval;
    // Start is called before the first frame update

    public enum enemyType
    {
        minion,
        shield,
        deflector
    }
    void spawn()
    {
        enemyType result = randomSelector.SelectItem();
        switch (result)
        {
            case enemyType.minion:
                enemy = Instantiate(enemyPrefab[(int) enemyType.minion], transform.position, Quaternion.Euler(0,180f,0));
                enemy.GetComponent<enemyController>().enemySO = enemySO[(int) enemyType.minion];
                credit -= creditSO.minionCredit;
                break;

            case enemyType.shield:
                enemy = Instantiate(enemyPrefab[(int) enemyType.shield], transform.position, Quaternion.Euler(0,180f,0));
                enemy.GetComponent<enemyController>().enemySO = enemySO[(int) enemyType.shield];
                credit -= creditSO.shieldCredit;
                break;

            case enemyType.deflector:
                enemy = Instantiate(enemyPrefab[(int) enemyType.deflector], transform.position, Quaternion.Euler(0,180f,0));
                enemy.GetComponent<enemyController>().enemySO = enemySO[(int) enemyType.deflector];
                credit -= creditSO.deflectorCredit;
                break;


        }
        Debug.Log(result);
        // return credit;
        // switch(result)
        // {
        //     case enemyType.minion:
                
                

            
        // }
    }
    void Start()
    {
        randomSelector.AddPercentageItem(enemyType.minion, waveSO.minionSpawnCoefficient);
        randomSelector.AddPercentageItem(enemyType.shield, waveSO.shieldSpawnCoefficient);
        randomSelector.AddPercentageItem(enemyType.deflector, waveSO.deflectorSpawnCoefficient);
        credit = waveSO.credit;
    }

    // Update is called once per frame
    void Update()
    {
        spawnInterval -= Time.deltaTime;
        if (credit > 0 && spawnInterval <= 0)
        {
            spawnInterval = Random.Range(1f,2f);
            spawn();
        }
    }
}
