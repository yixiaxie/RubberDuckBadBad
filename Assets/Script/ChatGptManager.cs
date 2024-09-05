using System.Collections.Generic;
using System.IO;
using UnityEngine;
using OpenAI;
using System.Threading.Tasks;


[System.Serializable]
public class AuthData
{
    public string apiKey;
    public string organizationId;
}

public class ChatGptManager : MonoBehaviour
{
    public static ChatGptManager Instance;  // Singleton instance


    private OpenAIApi openAI;
    private List<ChatMessage> messages = new List<ChatMessage>();
    private AuthData authData;

    // Start is called before the first frame update
    void Start()
    {
        LoadAuthData();
        if (authData != null)
        {
            openAI = new OpenAIApi(authData.apiKey, authData.organizationId);
            Debug.Log("API Key: " + authData.apiKey);
            Debug.Log("Organization ID: " + authData.organizationId);
        }
        else
        {
            Debug.LogError("Failed to load authentication data.");
        }
    }

    void LoadAuthData()
    {
        string filePath = Path.Combine(Application.dataPath, "config", "auth.json");
        Debug.Log("Looking for auth file at: " + filePath);
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            Debug.Log("Auth file content: " + json);
            authData = JsonUtility.FromJson<AuthData>(json);

            if (authData != null)
            {
                Debug.Log("Auth data loaded: API Key = " + authData.apiKey + ", Org ID = " + authData.organizationId);
            }
            else
            {
                Debug.LogError("Failed to parse auth data.");
            }
        }
        else
        {
            Debug.LogError("Auth file not found.");
        }
    }



    public async Task<string> AskChatGPT(string duckInfo)
    {
        try
        {
            string prompt = $"Your role: You are a Purple giant squid NPC on the beach. You are very knowledgeable but nonsensical. User: the user is our player, AAA King of Ducks. Each day AAA King of Ducks releases some little ducks at dawn and recycles them at dusk. The rubber duckies will drift individually with the movement of the currents. Ducks that come back will be attached with some attachments. Then the player will collect them and show some of them to you to know the story behind. Your task: when you get the duck, you need to respond to the player with its information and expand a reasonable adventure story. The name, color, attached thing and related information are provided in {duckInfo}. Make the story around this information. Your tone: be conversational, informative yet playful and humorous.";

            // Create and send the prompt
            ChatMessage newMessage = new ChatMessage
            {
                Role = "user",
                Content = prompt
            };
            messages.Add(newMessage);

            var request = new CreateChatCompletionRequest
            {
                Messages = messages,
                Model = "gpt-3.5-turbo"
            };

            var response = await openAI.CreateChatCompletion(request);

            if (response.Choices != null && response.Choices.Count > 0)
            {
                var chatResponse = response.Choices[0].Message;
                messages.Add(chatResponse);

                return chatResponse.Content;  // Return the NPC's response as a string
            }
            else
            {
                Debug.LogWarning("No choices received from GPT.");
                return "I am confused... No story for this duck.";
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error occurred while communicating with GPT: {ex.Message}");
            return "An error occurred while trying to get the duck's story.";
        }
    }



    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;  // Assign this instance to the singleton
            DontDestroyOnLoad(gameObject);  // Prevent this object from being destroyed across scenes
        }
        else
        {
            Destroy(gameObject);  // Destroy duplicate instances if more than one exists
        }
    }



    // Update is called once per frame
    void Update()
    {
        // 
    }
}
