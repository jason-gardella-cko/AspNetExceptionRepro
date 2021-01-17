# AspNetCoreExceptionRepro
This repo contains a simple ASP.NET Core Web Api reproducing `Request.ReadFormAsync` throwing an `InvalidOperationException`
when a form value contains the URL-encoded null character `%00`.

## Reproduction Steps
Run the API with `dotnet run` or through your IDE.

Run the following curl command to send a request which contains a null character in a form value and produces the exception with a 500 response:

```
curl -vk -d "some_form_data=client_secret=blah%00" -H "Content-Type: application/x-www-form-urlencoded" -X POST https://localhost:5001/repro
```

Run the following curl command to send a request which does not contain a null character returns a 200.

```
curl -vk -d "some_form_data=client_secret=blah" -H "Content-Type: application/x-www-form-urlencoded" -X POST https://localhost:5001/repro
```