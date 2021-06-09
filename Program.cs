﻿using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Program
{
    private const string _clientId = "";
    private const string _tenantId = "";

    public static async Task Main(string[] args)
    {
        IPublicClientApplication app;

        app = PublicClientApplicationBuilder
            .Create(_clientId)
            .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
            .WithRedirectUri("http://localhost")
            .Build();

        List<string> scopes = new List<string>
        {
            "user.read"
        };

        DeviceCodeProvider provider = new DeviceCodeProvider(app, scopes);

        GraphServiceClient client = new GraphServiceClient(provider);

        User myProfile = await client.Me
            .Request()
            .GetAsync();

        Console.WriteLine($"Name:\t{myProfile.DisplayName}");
        Console.WriteLine($"AAD Id:\t{myProfile.Id}");
    }


}