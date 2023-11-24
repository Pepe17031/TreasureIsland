using UnityEngine;

public class ToggleCanvas : MonoBehaviour
{
    public Canvas targetCanvas; // Ссылка на целевой Canvas
    public float detectionRadius = 1f; // Радиус обнаружения

    void Update()
    {
        // Проверка, есть ли объект с коллайдером в радиусе
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);

        foreach (Collider collider in colliders)
        {
            // Проверяем, является ли объект на нужном слое (или используйте другие критерии)
            if (collider.CompareTag("Boat"))
            {
                // Обнаружен целевой объект, включаем Canvas
                EnableCanvas();
                return; // Выходим из цикла, чтобы не продолжать обработку
            }
        }

        // Объект не обнаружен, отключаем Canvas
        DisableCanvas();
    }

    void EnableCanvas()
    {
        // Включаем компонент Canvas
        targetCanvas.enabled = true;
    }

    void DisableCanvas()
    {
        // Отключаем компонент Canvas
        targetCanvas.enabled = false;
    }
}