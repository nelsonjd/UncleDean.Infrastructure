// See https://aka.ms/new-console-template for more information
namespace UncleDean.Infrastructure;

using System;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.ContainerRegistry;
using Azure.ResourceManager.ContainerRegistry.Models;
using Azure.ResourceManager.Resources;
using Azure.Identity;

class Program
{
    static async Task Main(string[] args)
    { 
        Console.WriteLine("Hello, Uncle Dean Infrastructure!");


        string subscriptionId = "7ce36e93-1d4e-4045-a134-acdc3fbaaa01";

        string resourceGroupName = "Jordan_Resource_Group";

        string registryName = "jordanNelsonRegistry";
        
        ArmClient client = new ArmClient(new DefaultAzureCredential(), subscriptionId);

        AzureLocation location = AzureLocation.EastUS;

        SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
        var resourceGroup = (await subscription.GetResourceGroupAsync(resourceGroupName)).Value;

        var registryCollection = resourceGroup.GetContainerRegistries();


        var data = new ContainerRegistryData(location, new ContainerRegistrySku(ContainerRegistrySkuName.Basic))
        {
            IsAdminUserEnabled = true
        };




 

    }
}




