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

        string userAssignedClientId = "32af5110-5295-4bda-9929-d568fc22d564";
        var credential = new DefaultAzureCredential(
            new DefaultAzureCredentialOptions
            {
                ManagedIdentityClientId = userAssignedClientId
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




