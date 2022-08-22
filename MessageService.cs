namespace AzureHelloFn;

public class MessageService
{
    public string ComposeMessage(string name) =>
        string.IsNullOrEmpty(name)
            ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
            : $"Hello, {name}. This HTTP triggered function executed successfully.";
}