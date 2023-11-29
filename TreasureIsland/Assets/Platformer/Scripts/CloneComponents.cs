using UnityEngine;

public class ObjectCloner : MonoBehaviour
{
    public GameObject originalObject; // объект, который вы хотите клонировать
    public int numberOfClones = 5; // количество клонов
    public float randomRangeX = 1f; // диапазон рандома по оси X
    public void CloneObject()
    {
        /*// Клонируем объект
        GameObject clone = Instantiate(originalObject);

        // Помещаем клон в указанное место
        clone.transform.position = transform.position;
        clone.transform.rotation = transform.rotation;*/
        
        
        for (int i = 0; i < numberOfClones; i++)
        {
            // Клонируем объект
            GameObject clone = Instantiate(originalObject);

            // Помещаем клон в указанное место с рандомом по оси X
            float randomX = Random.Range(-randomRangeX, randomRangeX);
            clone.transform.position = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z);

            // Клонам можно также устанавливать другие параметры по вашему желанию
        }
    }
}