# AspNetCore.OAuth.Line

[![Version](https://img.shields.io/nuget/vpre/AspNetCore.OAuth.Line.svg)](https://www.nuget.org/packages/AspNetCore.OAuth.Line)
[![Downloads](https://img.shields.io/nuget/dt/AspNetCore.OAuth.Line.svg)](https://www.nuget.org/packages/AspNetCore.OAuth.Line)
[![.NET Core](https://img.shields.io/badge/.NET%20Core-%3E%3D%203.1-red.svg)](#)
[![.NET](https://img.shields.io/badge/.NET%205-%3E%3D%205.0-red.svg)](#)

## Description

**AspNetCore.OAuth.Line** is a LINE authentication security middleware that you can use in your ASP.NET Core application. It is a reference to *Aspnet-Contrib*'s [AspNet.Security.OAuth.Line](https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers/tree/dev/src/AspNet.Security.OAuth.Line) to support version 3.1 mainly.

## Usage

1. Create a [LINE Login channel](https://developers.line.biz/en/docs/line-login/getting-started/#step-2-create-channel) and configure it for getting channel-id & secret.

2. Add the AspNetCore.OAuth.Line package to your project.
```bash
dotnet add package AspNetCore.OAuth.Line
```

3. Add `using AspNet.Security.OAuth.Line` at the top in your `Startup` class or others that you use the `AddAuthentication` method.

4. Call AddLine() method of AuthenticationBuilder and configure it like this
```csharp
services.AddAuthentication(options => /* Auth configuration */)
        .AddLine(options =>
        {
            options.ClientId = "my-channel-id";
            options.ClientSecret = "my-channel-secret";
        });
```

5. Enjoy it!

## Optional Settings

| Property Name | Property Type | Description | Default Value |
|:--|:--|:--|:--|
| `Prompt` | `bool` | Used to force the consent screen to be displayed even if the user has already granted all requested permissions. | `false` |
| `UserEmailsEndpoint` | `string` | The address of the endpoint exposing the email addresses associated with the logged in user. | `LineAuthenticationDefaults.UserEmailsEndpoint` |

## LINE Documentation

- [English](https://developers.line.biz/en/docs/line-login/integrate-line-login)
- [繁體中文](https://developers.line.biz/zh-hant/docs/line-login/integrate-line-login)

## License

This project is licensed under the [Apache License](https://www.apache.org/licenses/LICENSE-2.0.html).

## Note

**AspNetCore.OAuth.Line** is specifically aimed at the version of the *.NET Core 3.1* Application. Although it also supports version *.NET 5*, it is recommended that you use Aspnet-Contrib's [AspNet.Security.OAuth.Line](https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers/tree/dev/src/AspNet.Security.OAuth.Line) instead If your application is above *.NET 5*.
