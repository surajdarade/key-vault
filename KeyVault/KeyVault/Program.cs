using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async () =>
{
    var vaultUri = new Uri("https://YOUR-VAULT-NAME.vault.azure.net/");

    var client = new SecretClient(vaultUri, new DefaultAzureCredential());

    var secret = await client.GetSecretAsync("AssignMate--CosmosConnection");

    return $"Secret value: {secret.Value.Value}";
});

app.Run();