using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using OpenAI;

public class AIDialogue : MonoBehaviour
{
    [SerializeField] Text _text;
    [SerializeField] Canvas _canvas; // Добавляем ссылку на Canvas
    [SerializeField] GameObject _banner; // Добавляем ссылку на Canvas

    void Start()
    {
        _text.text = "";
        SendRequest();
    }

    async void SendRequest()
    {
        var openai = new OpenAIApi("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");

        var req = new CreateChatCompletionRequest
        {
            Model = "gpt-3.5-turbo",
            Messages = new List<ChatMessage>
            {
                new ChatMessage()
                {
                    Role = "user",
                    Content = "Imagine you're a game character, an adventurer named Gora seeking treasure. Write a dialog box text of her reaction to first arriving on an island, no more than 20 words, with some slang."
                }
            },
            Temperature = 0.7f,
        };

        openai.CreateChatCompletionAsync(req,
            (responses) => {
                var result = string.Join("", responses.Select(response => response.Choices[0].Delta.Content));
                _text.text = result;
            },
            () => {
                Debug.Log("OpenAI request complete");
                Invoke("CloseCanvas", 2f); // Вызываем функцию CloseCanvas через 2 секунды
            },
            new CancellationTokenSource()
        );
    }

    void CloseCanvas()
    {
        // Закрываем Canvas
        if (_canvas != null)
        {
            _canvas.enabled = false;
            _banner.SetActive(false);
        }
    }
}