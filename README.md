# AspNetCore.OAuth.Line

[![Version](https://img.shields.io/nuget/vpre/AspNetCore.OAuth.Line.svg)](https://www.nuget.org/packages/AspNetCore.OAuth.Line)
[![Downloads](https://img.shields.io/nuget/dt/AspNetCore.OAuth.Line.svg)](https://www.nuget.org/packages/AspNetCore.OAuth.Line)
[![.NET Core](https://img.shields.io/badge/.NET%20Core-%3E%3D%203.1-red.svg)](#)
[![.NET](https://img.shields.io/badge/.NET%205-%3E%3D%205.0-red.svg)](#)

## Description

**AspNetCore.OAuth.Line** is a LINE authentication security middleware that you can use in your ASP.NET Core application(specially made for version 3.1).


## Usage

1. Add the AspNetCore.OAuth.Line package to your project.
```bash
dotnet add package AspNetCore.OAuth.Line
```

2. Add `using AspNet.Security.OAuth.Line` at the top in your `Startup` class or others that you use the `AddAuthentication` method.

3. Call AddLine() method of AuthenticationBuilder and configure it like this
```csharp
services.AddAuthentication(options => /* Auth configuration */)
        .AddLine(options =>
        {
            options.ClientId = "my-channel-id";
            options.ClientSecret = "my-channel-secret";
        });
```

4. Enjoy it!

## Optional Settings

| Property Name | Property Type | Description | Default Value |
|:--|:--|:--|:--|
| `Prompt` | `bool` | Used to force the consent screen to be displayed even if the user has already granted all requested permissions. | `false` |
| `UserEmailsEndpoint` | `string` | The address of the endpoint exposing the email addresses associated with the logged in user. | `LineAuthenticationDefaults.UserEmailsEndpoint` |


## Note

**AspNetCore.OAuth.Line** is a reference to Aspnet-Contrib's [AspNet.Security.OAuth.Line](https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers/tree/dev/src/AspNet.Security.OAuth.Line) which supports NET 5 only.
