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
        //var balance = await provider.GetBalance(account.ToString()); // // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        HexBigInteger  balance = await provider.GetBalance("0x89195F66d351f9deD420632edd174940E692b3ee"); 
        string balancestring = balance.ToString().Substring(0, balance.ToString().Length - 18);

        _balance.text = balancestring + " KLAY";
    }

    async public Task<int[]> CheckVariable()
    {
        string contractAbi = "[ 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"address\", 				\"name\": \"coordinator\", 				\"type\": \"address\" 			} 		], 		\"stateMutability\": \"nonpayable\", 		\"type\": \"constructor\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"address\", 				\"name\": \"have\", 				\"type\": \"address\" 			}, 			{ 				\"internalType\": \"address\", 				\"name\": \"want\", 				\"type\": \"address\" 			} 		], 		\"name\": \"OnlyCoordinatorCanFulfill\", 		\"type\": \"error\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"address\", 				\"name\": \"notOwner\", 				\"type\": \"address\" 			} 		], 		\"name\": \"OnlyOwner\", 		\"type\": \"error\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"requestId\", 				\"type\": \"uint256\" 			} 		], 		\"name\": \"cancelRequest\", 		\"outputs\": [], 		\"stateMutability\": \"nonpayable\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"requestId\", 				\"type\": \"uint256\" 			}, 			{ 				\"internalType\": \"uint256[]\", 				\"name\": \"randomWords\", 				\"type\": \"uint256[]\" 			} 		], 		\"name\": \"rawFulfillRandomWords\", 		\"outputs\": [], 		\"stateMutability\": \"nonpayable\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"bytes32\", 				\"name\": \"keyHash\", 				\"type\": \"bytes32\" 			}, 			{ 				\"internalType\": \"uint64\", 				\"name\": \"accId\", 				\"type\": \"uint64\" 			}, 			{ 				\"internalType\": \"uint32\", 				\"name\": \"callbackGasLimit\", 				\"type\": \"uint32\" 			}, 			{ 				\"internalType\": \"uint32\", 				\"name\": \"numWords\", 				\"type\": \"uint32\" 			} 		], 		\"name\": \"requestRandomWords\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"requestId\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"nonpayable\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"requestRoulete\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"requestId\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"payable\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"sRandomWord000\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"sRandomWord1\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"sRandomWord2\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"sRandomWord3\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"uint64\", 				\"name\": \"accId\", 				\"type\": \"uint64\" 			} 		], 		\"name\": \"withdrawTemporary\", 		\"outputs\": [], 		\"stateMutability\": \"nonpayable\", 		\"type\": \"function\" 	}, 	{ 		\"stateMutability\": \"payable\", 		\"type\": \"receive\" 	} ]";
        // address of contract
        string contractAddress = "0x1b2b97bEDF170b6F8c85d4D9E239b576757A6502";
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
        string contractAbi = "[ 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"address\", 				\"name\": \"coordinator\", 				\"type\": \"address\" 			} 		], 		\"stateMutability\": \"nonpayable\", 		\"type\": \"constructor\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"address\", 				\"name\": \"have\", 				\"type\": \"address\" 			}, 			{ 				\"internalType\": \"address\", 				\"name\": \"want\", 				\"type\": \"address\" 			} 		], 		\"name\": \"OnlyCoordinatorCanFulfill\", 		\"type\": \"error\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"address\", 				\"name\": \"notOwner\", 				\"type\": \"address\" 			} 		], 		\"name\": \"OnlyOwner\", 		\"type\": \"error\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"requestId\", 				\"type\": \"uint256\" 			} 		], 		\"name\": \"cancelRequest\", 		\"outputs\": [], 		\"stateMutability\": \"nonpayable\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"requestId\", 				\"type\": \"uint256\" 			}, 			{ 				\"internalType\": \"uint256[]\", 				\"name\": \"randomWords\", 				\"type\": \"uint256[]\" 			} 		], 		\"name\": \"rawFulfillRandomWords\", 		\"outputs\": [], 		\"stateMutability\": \"nonpayable\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"bytes32\", 				\"name\": \"keyHash\", 				\"type\": \"bytes32\" 			}, 			{ 				\"internalType\": \"uint64\", 				\"name\": \"accId\", 				\"type\": \"uint64\" 			}, 			{ 				\"internalType\": \"uint32\", 				\"name\": \"callbackGasLimit\", 				\"type\": \"uint32\" 			}, 			{ 				\"internalType\": \"uint32\", 				\"name\": \"numWords\", 				\"type\": \"uint32\" 			} 		], 		\"name\": \"requestRandomWords\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"requestId\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"nonpayable\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"requestRoulete\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"requestId\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"payable\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"sRandomWord000\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"sRandomWord1\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"sRandomWord2\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"sRandomWord3\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"uint64\", 				\"name\": \"accId\", 				\"type\": \"uint64\" 			} 		], 		\"name\": \"withdrawTemporary\", 		\"outputs\": [], 		\"stateMutability\": \"nonpayable\", 		\"type\": \"function\" 	}, 	{ 		\"stateMutability\": \"payable\", 		\"type\": \"receive\" 	} ]";
        // address of contract
        string contractAddress = "0x1b2b97bEDF170b6F8c85d4D9E239b576757A6502";
        string method = "requestRoulete";
        
        string[] obj = {};
        string args = JsonConvert.SerializeObject(obj);
        
        string response = await Web3GL.SendContract(method, contractAbi, contractAddress, args, "1000000000000000000", "300000", "");
        // display response in game
        print("Please check the contract variable again in a few seconds once the chain has processed the request!");
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Platformer");

    }
}
#endif