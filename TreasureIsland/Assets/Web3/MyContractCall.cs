using System;
using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Web3Unity.Scripts.Library.Ethers.Contracts;
using Newtonsoft.Json;
using TMPro;
using Web3Unity.Scripts.Library.Ethers.Providers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_WEBGL
public class WebGLContractRead : MonoBehaviour
{
    [SerializeField] private Text _balance;

    public void Start()
    {
        UpdateBalance();
    }

    async public void UpdateBalance()
    {
        var provider = new JsonRpcProvider("https://api.baobab.klaytn.net:8651/");
        string account = PlayerPrefs.GetString("Account");
        HexBigInteger balance = await provider.GetBalance(account.ToString()); // // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //HexBigInteger balance = await provider.GetBalance("0x89195F66d351f9deD420632edd174940E692b3ee");
        string balancestring = "";
        balancestring = balance.ToString().Substring(0, balance.ToString().Length - 18);
        if (balancestring != "")
        {
            _balance.text = balancestring + " KLAY";
        }
    }

    public async void RiskGame()
    {
        string contractAbi = "[ 	{ 		\"inputs\": [], 		\"stateMutability\": \"nonpayable\", 		\"type\": \"constructor\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"address\", 				\"name\": \"have\", 				\"type\": \"address\" 			}, 			{ 				\"internalType\": \"address\", 				\"name\": \"want\", 				\"type\": \"address\" 			} 		], 		\"name\": \"OnlyCoordinatorCanFulfill\", 		\"type\": \"error\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"requestId\", 				\"type\": \"uint256\" 			}, 			{ 				\"internalType\": \"uint256[]\", 				\"name\": \"randomWords\", 				\"type\": \"uint256[]\" 			} 		], 		\"name\": \"rawFulfillRandomWords\", 		\"outputs\": [], 		\"stateMutability\": \"nonpayable\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"requestRoulete\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"requestId\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"payable\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"sRandomWord000\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"sRandomWord1\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"sRandomWord2\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"sRandomWord3\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"uint64\", 				\"name\": \"sum\", 				\"type\": \"uint64\" 			} 		], 		\"name\": \"sendMoney\", 		\"outputs\": [], 		\"stateMutability\": \"payable\", 		\"type\": \"function\" 	}, 	{ 		\"stateMutability\": \"payable\", 		\"type\": \"receive\" 	} ]";
        string contractAddress = "0xFC7Cd4E7c74CA34ADa5E4129BC405b96A0C21196";
        string method = "sRandomWord000";
        var provider = new JsonRpcProvider("https://api.baobab.klaytn.net:8651/");
        
        var contract = new Contract(contractAbi, contractAddress, provider);
        var calldata = await contract.Call(method, new object[] { });
        
        int.TryParse(calldata[0].ToString(), out int result);
        Debug.Log("Result: " + result);

        if (result == 1)
        {
            SceneManager.LoadScene("Die");
            Debug.Log("You Die!");
        } else if (result == 2)
        {
            SceneManager.LoadScene("ComingSoon");
            Debug.Log("You Win!");
        }
        else
        {
            Debug.Log("Logic Error");
        }
    }
    

    async public Task<int[]> CheckVariable()
    {
        string contractAbi = "[ 	{ 		\"inputs\": [], 		\"stateMutability\": \"nonpayable\", 		\"type\": \"constructor\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"address\", 				\"name\": \"have\", 				\"type\": \"address\" 			}, 			{ 				\"internalType\": \"address\", 				\"name\": \"want\", 				\"type\": \"address\" 			} 		], 		\"name\": \"OnlyCoordinatorCanFulfill\", 		\"type\": \"error\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"requestId\", 				\"type\": \"uint256\" 			}, 			{ 				\"internalType\": \"uint256[]\", 				\"name\": \"randomWords\", 				\"type\": \"uint256[]\" 			} 		], 		\"name\": \"rawFulfillRandomWords\", 		\"outputs\": [], 		\"stateMutability\": \"nonpayable\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"requestRoulete\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"requestId\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"payable\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"sRandomWord000\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"sRandomWord1\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"sRandomWord2\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"sRandomWord3\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"uint64\", 				\"name\": \"sum\", 				\"type\": \"uint64\" 			} 		], 		\"name\": \"sendMoney\", 		\"outputs\": [], 		\"stateMutability\": \"payable\", 		\"type\": \"function\" 	}, 	{ 		\"stateMutability\": \"payable\", 		\"type\": \"receive\" 	} ]";
        // address of contract
        string contractAddress = "0xFC7Cd4E7c74CA34ADa5E4129BC405b96A0C21196";
        string method1 = "sRandomWord1";
        string method2 = "sRandomWord2";
        string method3 = "sRandomWord3";
        
        // you can use this to create a provider for hardcoding and parse this instead of rpc get instance
        var provider = new JsonRpcProvider("https://api.baobab.klaytn.net:8651/");
        var contract = new Contract(contractAbi, contractAddress, provider);
        
        var calldata1 = await contract.Call(method1, new object[] {});
        var calldata2 = await contract.Call(method2, new object[] {});
        var calldata3 = await contract.Call(method3, new object[] {});


        // display response in game
        print("Contract Variable Total: " + calldata1[0] + " " + calldata2[0] + " " + calldata3[0]);
        
        int.TryParse(calldata1[0].ToString(), out int result1);
        int.TryParse(calldata2[0].ToString(), out int result2);
        int.TryParse(calldata3[0].ToString(), out int result3);

        int[] result = { result1, result2, result3 };
        return result;
        

    }
    async public Task GetRndValue()
    {
        string contractAbi = "[ 	{ 		\"inputs\": [], 		\"stateMutability\": \"nonpayable\", 		\"type\": \"constructor\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"address\", 				\"name\": \"have\", 				\"type\": \"address\" 			}, 			{ 				\"internalType\": \"address\", 				\"name\": \"want\", 				\"type\": \"address\" 			} 		], 		\"name\": \"OnlyCoordinatorCanFulfill\", 		\"type\": \"error\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"requestId\", 				\"type\": \"uint256\" 			}, 			{ 				\"internalType\": \"uint256[]\", 				\"name\": \"randomWords\", 				\"type\": \"uint256[]\" 			} 		], 		\"name\": \"rawFulfillRandomWords\", 		\"outputs\": [], 		\"stateMutability\": \"nonpayable\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"requestRoulete\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"requestId\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"payable\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"sRandomWord000\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"sRandomWord1\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"sRandomWord2\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"sRandomWord3\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"uint64\", 				\"name\": \"sum\", 				\"type\": \"uint64\" 			} 		], 		\"name\": \"sendMoney\", 		\"outputs\": [], 		\"stateMutability\": \"payable\", 		\"type\": \"function\" 	}, 	{ 		\"stateMutability\": \"payable\", 		\"type\": \"receive\" 	} ]";
        // address of contract
        string contractAddress = "0xFC7Cd4E7c74CA34ADa5E4129BC405b96A0C21196";
        string method = "requestRoulete";
        
        string[] obj = {};
        string args = JsonConvert.SerializeObject(obj);
        
        string response = await Web3GL.SendContract(method, contractAbi, contractAddress, args, "1000000000000000000", "300000", "");
        UpdateBalance();
        // display response in game
        print("Please check the contract variable again in a few seconds once the chain has processed the request!");
    }
    async public void GetMoney()
    {
        string contractAbi = "[ 	{ 		\"inputs\": [], 		\"stateMutability\": \"nonpayable\", 		\"type\": \"constructor\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"address\", 				\"name\": \"have\", 				\"type\": \"address\" 			}, 			{ 				\"internalType\": \"address\", 				\"name\": \"want\", 				\"type\": \"address\" 			} 		], 		\"name\": \"OnlyCoordinatorCanFulfill\", 		\"type\": \"error\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"requestId\", 				\"type\": \"uint256\" 			}, 			{ 				\"internalType\": \"uint256[]\", 				\"name\": \"randomWords\", 				\"type\": \"uint256[]\" 			} 		], 		\"name\": \"rawFulfillRandomWords\", 		\"outputs\": [], 		\"stateMutability\": \"nonpayable\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"requestRoulete\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"requestId\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"payable\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"sRandomWord000\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"sRandomWord1\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"sRandomWord2\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"sRandomWord3\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"uint64\", 				\"name\": \"sum\", 				\"type\": \"uint64\" 			} 		], 		\"name\": \"sendMoney\", 		\"outputs\": [], 		\"stateMutability\": \"payable\", 		\"type\": \"function\" 	}, 	{ 		\"stateMutability\": \"payable\", 		\"type\": \"receive\" 	} ]";
        // address of contract
        string contractAddress = "0xFC7Cd4E7c74CA34ADa5E4129BC405b96A0C21196";
        string method = "sendMoney";

        string sum = "100000000000000000";
        string[] obj = {sum};
        string args = JsonConvert.SerializeObject(obj);
        
        string response = await Web3GL.SendContract(method, contractAbi, contractAddress, args, "0", "300000", "");
        UpdateBalance();
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("GameScene");

    }
    public void LoadOceanScene()
    {
        SceneManager.LoadScene("OceanMap");

    }
}
#endif