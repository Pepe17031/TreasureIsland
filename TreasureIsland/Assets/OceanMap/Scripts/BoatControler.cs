using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Rigidbody rb; // Rigidbody компонент
    private Vector3 targetPosition; // Позиция цели
    public float initialRotation = -90f; // начальный угол поворота носа корабля
    public float distance_value = 1;
    public float turnAngSpeed = 0.1f; // Скорость поворота
    
    public float forwardSpeed = 10f; // Полная скорость вперед
    public float turnForwardSpeedMultiplier = 3f; // Скорость вперед при повороте
    public AudioSource _audio1;
    public AudioSource _audio2;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Получаем компонент Rigidbody
        _audio1.volume = 0.1f;
        _audio2.volume = 0.1f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Проверка на нажатие левой кнопки мыши
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                targetPosition = hit.point; // Установка позиции цели на место клика
            }

        }
        
        Vector3 dir = (targetPosition - transform.position).normalized; // Направление
        float angleDiff = Vector3.SignedAngle(transform.forward, new Vector3(dir.x, 0f, dir.z), Vector3.up) - initialRotation; // Разница углов в градусах
        float distance = Vector3.Distance(transform.position, targetPosition); // Расстояние
        
        //Debug.Log("Direction: " + dir + " | Angle: " + angleDiff + " | Distance: " + distance);  

        if (distance > distance_value)
        {
            //rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            if (angleDiff > 20)
            {
                // Поворот вправо
                //rb.AddTorque(Vector3.up * turnAngSpeed, ForceMode.VelocityChange);
                transform.Rotate(Vector3.up, turnAngSpeed);

            }
            else if (angleDiff < -20)
            {
                // Поворот влево
                //rb.AddTorque(Vector3.up * -turnAngSpeed, ForceMode.VelocityChange);
                transform.Rotate(Vector3.up, -turnAngSpeed);

            }

            // Применение не полной скорости вперед
            rb.AddForce(new Vector3(dir.x, 0f, dir.z).normalized * turnForwardSpeedMultiplier * forwardSpeed, ForceMode.VelocityChange); 

            if (_audio1.volume < 0.6f)
            {
                _audio1.volume = _audio1.volume + 0.05f;
            }
            if (_audio2.volume < 0.4f)
            {
                _audio2.volume = _audio2.volume + 0.05f;
            }

        }
        
        else
        {
            // Остановить линейное движение
            rb.velocity = Vector3.zero;
            if (_audio1.volume > 0.05f)
            {
                _audio1.volume = _audio1.volume - 0.05f;
                _audio2.volume = _audio2.volume - 0.05f;
            }
            

            // Остановить вращение
            rb.angularVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.None;

        }
       
    }
}