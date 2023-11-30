using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using OpenAI;
using UnityEngine.SceneManagement;

public class AIDialogue : MonoBehaviour
{
    [SerializeField] Text _text;
    [SerializeField] GameObject _bilboard; // Добавляем ссылку на Canvas

    
    async void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            Say();
        }
        else if (SceneManager.GetActiveScene().name == "Die")
        {
            Die();
        }
    }
    
    async void Say()
    {
        _text.gameObject.SetActive(false);
        _bilboard.SetActive(false);
        var openai = new OpenAIApi("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");

        var req = new CreateChatCompletionRequest
        {
            Model = "gpt-3.5-turbo",
            Messages = new List<ChatMessage>
            {
                new ChatMessage()
                {
                    Role = "user",
                    Content = "Imagine you are a game character, an adventurer looking for treasure. Write a dialog text of her reaction to her first arrival on the island, where you have to look around an abandoned village. The response should be no longer than 20 words."
                }
            },
            Temperature = 0.7f,
        };
        openai.CreateChatCompletionAsync(req,
            (responses) => {

                _text.gameObject.SetActive(true);
                _bilboard.gameObject.SetActive(true);

                var result = string.Join("", responses.Select(response => response.Choices[0].Delta.Content));
                _text.text = result;

            },
            () => {
                Debug.Log("OpenAI request complete");
                Invoke("CloseCanvas", 3f); // Вызываем функцию CloseCanvas через 2 секунды
            },
            new CancellationTokenSource()
        );
        
    }
    async public void Die()
    {
        _text.gameObject.SetActive(false);
        _bilboard.SetActive(false);
        var openai = new OpenAIApi("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");

        var req = new CreateChatCompletionRequest
        {
            Model = "gpt-3.5-turbo",
            Messages = new List<ChatMessage>
            {
                new ChatMessage()
                {
                    Role = "user",
                    Content = "Imagine you are a game character, an adventurer in search of treasure. Write a dialog text about the death of the character from a hidden trap, present the text on behalf of the narrator, The answer should be no longer than 20 words."
                }
            },
            Temperature = 0.7f,
        };

        openai.CreateChatCompletionAsync(req,
            (responses) => {
                _text.gameObject.SetActive(true);
                _bilboard.gameObject.SetActive(true);
                var result = string.Join("", responses.Select(response => response.Choices[0].Delta.Content));
                _text.text = result;

            },
            () => {
                Debug.Log("OpenAI request complete");
            },
            new CancellationTokenSource()
        );
    }

    void CloseCanvas()
    {
        if (_bilboard != null)
        {
            _text.gameObject.SetActive(false);
            _bilboard.SetActive(false);
        }
    }
}
