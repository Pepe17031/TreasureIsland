using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float turnAngSpeed = 0.1f; // Скорость изменения направления
    public float forwardSpeed = 10f; // Полная скорость вперед
    public float turnForwardSpeedMultiplier = 3f; // Скорость вперед при повороте
    public float initialRotation = -90f; // начальный угол поворота носа корабля
    public Transform targetTest; // Позиция цели
    public float distance_value = 10;
    private Vector3 targetPosition; // Позиция цели
    public float rockingForce = 1f; // Сила покачивания

    private Rigidbody rb; // Rigidbody компонент

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Получаем компонент Rigidbody
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Проверка на нажатие левой кнопки мыши
        {
            // Получение позиции клика мыши в мировых координатах
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                targetPosition = hit.point; // Установка позиции цели на место клика
            }
        }
        
        Vector3 dir = (targetPosition - transform.position).normalized; // Направление от корабля к цели

        float angleDiff = Vector3.SignedAngle(transform.forward, new Vector3(dir.x, 0f, dir.z), Vector3.up) - initialRotation; // Разница углов в градусах
        float distance = Vector3.Distance(transform.position, targetPosition);
        Debug.Log(angleDiff);
        if (distance > distance_value)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

            if (angleDiff > 20)
            {
                // Поворот вправо
                Debug.Log("Поворот вправо");
                //rb.AddTorque(Vector3.up * turnAngSpeed, ForceMode.VelocityChange);
                transform.Rotate(Vector3.up, turnAngSpeed);

            }
            else if (angleDiff < -20)
            {
                // Поворот влево
                Debug.Log("Поворот влево");
                //rb.AddTorque(Vector3.up * -turnAngSpeed, ForceMode.VelocityChange);
                transform.Rotate(Vector3.up, -turnAngSpeed);

            }

            // Применение не полной скорости вперед
            Debug.Log("Полный вперед");
            rb.AddForce(new Vector3(dir.x, 0f, dir.z).normalized * turnForwardSpeedMultiplier * forwardSpeed, ForceMode.VelocityChange); 
        }
        else
        {
            // Остановить линейное движение
            rb.velocity = Vector3.zero;

            // Остановить вращение
            rb.angularVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.None;

        }
       
    }
}