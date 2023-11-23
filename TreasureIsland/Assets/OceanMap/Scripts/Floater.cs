using UnityEngine;

public class Floater : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float depthBeforeSubmerget = 1f;
    public float displacementAmount = 3f;
    public int floaterCount = 1;
    public float waterDrag = 0.99f;
    public float waterAngularDrag = 0.5f;

    public LowPolyWater.LowPolyWater lowPolyWater;

    void Start()
    {
        lowPolyWater = FindAnyObjectByType<LowPolyWater.LowPolyWater>();

        if (lowPolyWater == null)
        {
            Debug.LogError("LowPolyWater not found or not assigned!");
        }
    }

    private void FixedUpdate()
    {
        rigidBody.AddForceAtPosition(Physics.gravity / floaterCount, transform.position, ForceMode.Acceleration);
        HandleWaterInteraction();
    }

    private void HandleWaterInteraction()
    {
        if (lowPolyWater != null)
        {
            Vector3 currentPosition = transform.position;
            Vector3 waveHeightVector = lowPolyWater.GetWaveHeight(currentPosition);
            float waveHeight = waveHeightVector.y * 1;

            if (transform.position.y < waveHeight)
            {
                float displacementMultiplier = Mathf.Clamp01((waveHeight - transform.position.y) / depthBeforeSubmerget) * displacementAmount;
                rigidBody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), transform.position, ForceMode.Acceleration);
                rigidBody.AddForce(displacementMultiplier * -rigidBody.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
                rigidBody.AddTorque(displacementMultiplier * -rigidBody.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            }
        }
    }
}