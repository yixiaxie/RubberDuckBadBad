using System.Collections.Generic;
using UnityEngine;
using OpenAI;

public class ChatGptManager : MonoBehaviour
{
    private OpenAIApi openAI;
    private List<ChatMessage> messages = new List<ChatMessage>();

    // Start is called before the first frame update
    void Start()
    {
        // 
        openAI = new OpenAIApi("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", "org-x0T0HWeTAHSUf2sqP3V7PxGx");
    }

    public async void AskChatGPT(string duckInfo)
    {
        try
        {
            // 
            string prompt = $"Your role: You are a Purple giant squid NPC on the beach. You are very knowledgeable but nonsensical. User: the user is our player, AAA King of Ducks.Each day AAA King of Ducks releases some little ducks at dawn and recycles them at dusk. The rubber duckies will drift individually with the movement of the currents. Ducks that come back will be attached with some attachments.Then the player will collect them and show some of them to you to know the story behind. Your task: when you get the duck, you need to response to the player its information and expand a reasonable adventure story of it. Remember to make the story around the {duckInfo} provided.Your tone: be conversational, informative yet playful and humorous.";

            //
            ChatMessage newMessage = new ChatMessage
            {
                Role = "user",
                Content = prompt
            };

            messages.Add(newMessage);

            // 
            var request = new CreateChatCompletionRequest
            {
                Messages = messages,
                Model = "gpt-3.5-turbo"
            };

            // 
            var response = await openAI.CreateChatCompletion(request);

            // 
            if (response.Choices != null && response.Choices.Count > 0)
            {
                var chatResponse = response.Choices[0].Message;
                messages.Add(chatResponse);

                Debug.Log(chatResponse.Content);
            }
            else
            {
                Debug.LogWarning("No choices received from GPT.");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error occurred while communicating with GPT: {ex.Message}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 
    }
}
