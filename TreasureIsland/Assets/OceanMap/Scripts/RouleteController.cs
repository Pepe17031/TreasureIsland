using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RouleteController : MonoBehaviour
{
    public RouleteAnmation rouleteAnimation1;
    public RouleteAnmation rouleteAnimation2;
    public RouleteAnmation rouleteAnimation3;

    private async void Start()
    {
        WebGLContractRead contractScript = FindFirstObjectByType<WebGLContractRead>();
        if (contractScript != null)
        {
            await contractScript.GetRndValue();
            int[] result = await contractScript.CheckVariable();
            rouleteAnimation1.StopAnination(result[0]); // Замените 2 на нужное вам значение
            rouleteAnimation2.StopAnination(result[1]); // Замените 2 на нужное вам значение
            rouleteAnimation3.StopAnination(result[2]); // Замените 2 на нужное вам значение
            if (result[0] == result[1] && result[1] == result[2])
            {
                Debug.Log("You Win!");
            }
            else
            {
                Debug.Log("You Lose!");

            }
        }
    }

}
