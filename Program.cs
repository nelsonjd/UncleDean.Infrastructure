// See https://aka.ms/new-console-template for more information
namespace UncleDean.Infrastructure;

using System;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

class Program
{
    static async Task Main(string[] args)
    { 
        Console.WriteLine("Hello, World!");

        var clientId = Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");
        
        var credential = new DefaultAzureCredential(
            new DefaultAzureCredentialOptions
            {
                ManagedIdentityClientId = clientId
            }
        );

        ArmClient client = new ArmClient(credential);

        SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
        ResourceGroupCollection collection = subscription.GetResourceGroups();

        await foreach (ResourceGroupResource resourceGroup in collection)
        {
            Console.WriteLine(resourceGroup.Data.Name);
        }

    }
}




