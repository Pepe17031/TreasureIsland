using System.Collections;
using UnityEngine;

public class RouleteController : MonoBehaviour
{
    public RouleteAnmation rouleteAnimation1;
    public RouleteAnmation rouleteAnimation2;
    public RouleteAnmation rouleteAnimation3;
    public Transform islandTransform;
    public GameObject minwinObjectPrefab; // Предполагается, что у вас есть префаб для дочернего объекта
    public GameObject midwinObjectPrefab; // Предполагается, что у вас есть префаб для дочернего объекта
    public GameObject maxwinObjectPrefab; // Предполагается, что у вас есть префаб для дочернего объекта

    public GameObject loseObjectPrefab; // Предполагается, что у вас есть префаб для дочернего объекта
    public GameObject ParticlePrefab; // Предполагается, что у вас есть префаб для дочернего объекта
    public GameObject deletable; // Предполагается, что у вас есть префаб для дочернего объекта

    public AudioSource _spinBip;
    public AudioSource _spinLose;
    public GameObject _enterButton; // Предполагается, что у вас есть префаб для дочернего объекта


    private async void Start()
    {
        _enterButton.SetActive(false);
        WebGLContractRead contractScript = FindFirstObjectByType<WebGLContractRead>();
        if (contractScript != null)
        {
            deletable.gameObject.SetActive(false);
            _spinBip.Play();
            await contractScript.GetRndValue(); // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            int[] result = await contractScript.CheckVariable();
            rouleteAnimation1.StopAnination(result[0]); // Замените 2 на нужное вам значение
            rouleteAnimation2.StopAnination(result[1]); // Замените 2 на нужное вам значение
            rouleteAnimation3.StopAnination(result[2]); // Замените 2 на нужное вам значение
            if (result[0] == result[1])
            {
                _spinBip.Stop();

                GameObject particleobj = Instantiate(ParticlePrefab, islandTransform.position, Quaternion.identity);
                particleobj.transform.parent = islandTransform;
                particleobj.transform.Rotate(-90f, 0f, 0f);
                particleobj.transform.localScale = new Vector3(1f, 1f, 1f);


                Debug.Log("You Win!");
                _enterButton.SetActive(true);

                if (result[0] == 1)
                {
                    GameObject winObject = Instantiate(minwinObjectPrefab, islandTransform.position, Quaternion.identity);
                    winObject.transform.parent = islandTransform;
                    winObject.transform.localScale = new Vector3(1f, 1f, 1f);
                } else if (result[0] == 2)
                {
                    GameObject winObject = Instantiate(midwinObjectPrefab, islandTransform.position, Quaternion.identity);
                    winObject.transform.parent = islandTransform;
                    winObject.transform.localScale = new Vector3(1f, 1f, 1f);

                }
                else
                {
                    GameObject winObject = Instantiate(maxwinObjectPrefab, islandTransform.position, Quaternion.identity);
                    winObject.transform.parent = islandTransform;
                    winObject.transform.localScale = new Vector3(1f, 1f, 1f);
                }

            }
            else
            {
                _spinBip.Stop();

                Debug.Log("You Lose!");
                //islandTransform.Rotate(0f, 0f, 180f);
                deletable.gameObject.SetActive(false);
                _spinLose.Play();

                GameObject loseObject = Instantiate(loseObjectPrefab, islandTransform.position, Quaternion.identity);
                loseObject.transform.parent = islandTransform;
                loseObject.transform.localScale = new Vector3(1f, 1f, 1f);


            }
        }
    }


}
