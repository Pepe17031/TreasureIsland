using System;
using Nethereum.Hex.HexTypes;
using Web3Unity.Scripts.Library.Ethers.Contracts;
using Newtonsoft.Json;
using TMPro;
using Web3Unity.Scripts.Library.Ethers.Providers;
using UnityEngine;
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
        var balance = await provider.GetBalance(account.ToString()); // ЗАМЕНИТЬ АДРЕСС 41622629575000000000
        //HexBigInteger  balance = await provider.GetBalance("0x89195F66d351f9deD420632edd174940E692b3ee"); // ЗАМЕНИТЬ АДРЕСС 41622629575000000000
        string balancestring = balance.ToString().Substring(0, balance.ToString().Length - 18);

        _balance.text = balancestring + " KLAY";
    }

    async public void CheckVariable()
    {
        string contractAbi = "[ { \"inputs\": [ { \"internalType\": \"uint8\", \"name\": \"_myArg\", \"type\": \"uint8\" } ], \"name\": \"requestRandomWordsDirect\", \"outputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"function\" }, { \"inputs\": [], \"name\": \"sRandomWord\", \"outputs\": [ { \"internalType\": \"uint256\", \"name\": \"\", \"type\": \"uint256\" } ], \"stateMutability\": \"view\", \"type\": \"function\" } ]";
        // address of contract
        string contractAddress = "0xAb12DDeE896813d636C49c04498B51f43d5484FC";
        string method = "sRandomWord";
        
        // you can use this to create a provider for hardcoding and parse this instead of rpc get instance
        var provider = new JsonRpcProvider("https://api.baobab.klaytn.net:8651/");
        var contract = new Contract(contractAbi, contractAddress, provider);
        
        Debug.Log("Contract: " + contract);
        var calldata = await contract.Call(method, new object[]
        {
            // if you need to add parameters you can do so, a call with no args is blank
            // arg1,
            // arg2
        });
        // display response in game
        print("Contract Variable Total: " + calldata[0]);
    }
    async public void GetRndValue()
    {
        string contractAbi = "[	{		\"inputs\": [			{				\"internalType\": \"address\",				\"name\": \"coordinator\",				\"type\": \"address\"			}		],		\"stateMutability\": \"nonpayable\",		\"type\": \"constructor\"	},	{		\"inputs\": [			{				\"internalType\": \"address\",				\"name\": \"have\",				\"type\": \"address\"			},			{				\"internalType\": \"address\",				\"name\": \"want\",				\"type\": \"address\"			}		],		\"name\": \"OnlyCoordinatorCanFulfill\",		\"type\": \"error\"	},	{		\"inputs\": [			{				\"internalType\": \"address\",				\"name\": \"notOwner\",				\"type\": \"address\"			}		],		\"name\": \"OnlyOwner\",		\"type\": \"error\"	},	{		\"inputs\": [			{				\"internalType\": \"uint256\",				\"name\": \"requestId\",				\"type\": \"uint256\"			}		],		\"name\": \"cancelRequest\",		\"outputs\": [],		\"stateMutability\": \"nonpayable\",		\"type\": \"function\"	},	{		\"inputs\": [			{				\"internalType\": \"uint256\",				\"name\": \"requestId\",				\"type\": \"uint256\"			},			{				\"internalType\": \"uint256[]\",				\"name\": \"randomWords\",				\"type\": \"uint256[]\"			}		],		\"name\": \"rawFulfillRandomWords\",		\"outputs\": [],		\"stateMutability\": \"nonpayable\",		\"type\": \"function\"	},	{		\"inputs\": [			{				\"internalType\": \"bytes32\",				\"name\": \"keyHash\",				\"type\": \"bytes32\"			},			{				\"internalType\": \"uint64\",				\"name\": \"accId\",				\"type\": \"uint64\"			},			{				\"internalType\": \"uint32\",				\"name\": \"callbackGasLimit\",				\"type\": \"uint32\"			},			{				\"internalType\": \"uint32\",				\"name\": \"numWords\",				\"type\": \"uint32\"			}		],		\"name\": \"requestRandomWords\",		\"outputs\": [			{				\"internalType\": \"uint256\",				\"name\": \"requestId\",				\"type\": \"uint256\"			}		],		\"stateMutability\": \"nonpayable\",		\"type\": \"function\"	},	{		\"inputs\": [			{				\"internalType\": \"uint32\",				\"name\": \"numWords\",				\"type\": \"uint32\"			}		],		\"name\": \"requestRandomWordsDirect\",		\"outputs\": [			{				\"internalType\": \"uint256\",				\"name\": \"requestId\",				\"type\": \"uint256\"			}		],		\"stateMutability\": \"payable\",		\"type\": \"function\"	},	{		\"inputs\": [],		\"name\": \"sRandomWord\",		\"outputs\": [			{				\"internalType\": \"uint256\",				\"name\": \"\",				\"type\": \"uint256\"			}		],		\"stateMutability\": \"view\",		\"type\": \"function\"	},	{		\"inputs\": [			{				\"internalType\": \"uint64\",				\"name\": \"accId\",				\"type\": \"uint64\"			}		],		\"name\": \"withdrawTemporary\",		\"outputs\": [],		\"stateMutability\": \"nonpayable\",		\"type\": \"function\"	},	{		\"stateMutability\": \"payable\",		\"type\": \"receive\"	}]";
        // address of contract
        string contractAddress = "0xAb12DDeE896813d636C49c04498B51f43d5484FC";
        string method = "requestRandomWordsDirect";
        
        string numWords = "1";
        string[] obj = {numWords};
        string args = JsonConvert.SerializeObject(obj);
        
        string response = await Web3GL.SendContract(method, contractAbi, contractAddress, args, "1000000000000000000", "300000", "");
        
        // display response in game
        print("Please check the contract variable again in a few seconds once the chain has processed the request!");
    }
}
#endif