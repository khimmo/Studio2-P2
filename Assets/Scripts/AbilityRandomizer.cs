using UnityEngine;

public class AbilityRandomizer : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public RectTransform[] spawnPositions;

    private void Start()
    {
        SpawnThreeRandomObjectsOnCanvas();
    }
    public void SpawnThreeRandomObjectsOnCanvas()
    {

        ShuffleArray(objectsToSpawn);
        ShuffleArray(spawnPositions);

        for (int i = 0; i < 3; i++)
        {
            GameObject objectToSpawn = objectsToSpawn[i];
            RectTransform spawnPosition = spawnPositions[i];


            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition.position, Quaternion.identity, spawnPosition);


        }
    }


    private void ShuffleArray<T>(T[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            T temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }
}
