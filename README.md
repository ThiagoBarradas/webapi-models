[![Build Status](https://barradas.visualstudio.com/Contributions/_apis/build/status/NugetPackage/WebApi%20Models?branchName=develop)](https://barradas.visualstudio.com/Contributions/_build/latest?definitionId=18&branchName=develop)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=ThiagoBarradas_webapi-models&metric=alert_status)](https://sonarcloud.io/dashboard?id=ThiagoBarradas_webapi-models)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=ThiagoBarradas_webapi-models&metric=coverage)](https://sonarcloud.io/dashboard?id=ThiagoBarradas_webapi-models)
[![NuGet Downloads](https://img.shields.io/nuget/dt/WebApi.Models.svg)](https://www.nuget.org/packages/WebApi.Models/)
[![NuGet Version](https://img.shields.io/nuget/v/WebApi.Models.svg)](https://www.nuget.org/packages/WebApi.Models/)

# WebApi.Models

Models to facilitate implementation and handling successful and error responses in web api.

# Sample

Sample - Entity to ApiResponse
```c#

var apiResponse = myEntity.ToApiResponse(HttpStatusCode.OK);

```

Sample with Exception
```c#

// Creating a exception with errors

var errors = new ErrorsReponse();

response.AddError("message1", "property1");
response.AddError("message2", "property2");

throw new BadRequestException(errors);

// On your exception handler 

var exceptionApiResponse = badRequestException.ToApiResponse();

```

> You need implements `ApiResponse` mapping to your web api framework response, like ASP.NET or NancyFx model.

Sample - Casting ApiResponse to HttpResponseMessage
```c#

public class BaseApiController : ApiController
{
    protected HttpResponseMessage CreateResponse(ApiResponse response)
    {
        var response = Request.CreateResponse(apiResponse.StatusCode, apiResponse.Content);
        apiResponse.Headers.ForEach(header => 
        {
            response.Headers.Add(header.Key, header.Value);
        });

        return response;
    }
}

public class MyController : BaseApiController
{
    [HttpGet]
    [Route("")]
    public HttpResponseMessage GetSomething()
    {
        // do something and get ApiResponse

        return this.CreateResponse(apiResponse);
    }
}
```

## Install via NuGet

```
PM> Install-Package WebApi.Models
```

## How can I contribute?
Please, refer to [CONTRIBUTING](.github/CONTRIBUTING.md)

## Found something strange or need a new feature?
Open a new Issue following our issue template [ISSUE_TEMPLATE](.github/ISSUE_TEMPLATE.md)

## Changelog
See in [nuget version history](https://www.nuget.org/packages/WebApi.Models)

## Did you like it? Please, make a donate :)

if you liked this project, please make a contribution and help to keep this and other initiatives, send me some Satochis.

BTC Wallet: `1G535x1rYdMo9CNdTGK3eG6XJddBHdaqfX`

![1G535x1rYdMo9CNdTGK3eG6XJddBHdaqfX](https://i.imgur.com/mN7ueoE.png)
