using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using OpenAI;

public class AIDialogue : MonoBehaviour
{
    [SerializeField] Text _text;
    [SerializeField] GameObject _bilboard; // Добавляем ссылку на Canvas

    
    async void Start()
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
                 Debug.Log(result.ToString());

             },
             () => {
                 Debug.Log("OpenAI request complete");
                 Invoke("CloseCanvas", 3f); // Вызываем функцию CloseCanvas через 2 секунды
             },
             new CancellationTokenSource()
        );
    }

    void CloseCanvas()
    {
        // Закрываем Canvas
        if (_bilboard != null)
        {
            _text.gameObject.SetActive(false);
            _bilboard.SetActive(false);
        }
    }
}

/*public class AIDialogue : MonoBehaviour
{
    [SerializeField] Text _text;
    async void Start()
    {
        _text.text = "";
        await SendRequest();
    }
    
    
    private async Task SendRequest()
    {
        var openai = new OpenAIApi("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");

        var request = new CreateCompletionRequest{
            Model="text-davinci-003",
            Prompt="Say this is a test",
        };
        var response = await openai.CreateCompletion(request);
        Debug.Log(response.ToString());
    }
    
}*/