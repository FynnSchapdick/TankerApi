# TankerApi

TankerApi is a C# Wrapper for Tankerkönig, a gasoline API for german stations. More information about the [Tankerkönig-API](https://creativecommons.tankerkoenig.de/swagger/)

Example of use:

```
string apiKey = "cffa4fb8-7a16-cd85-7946-263722530f15"; // default api-key from swagger

TankerKoenig tanker = new TankerKoenig(apiKey);
            
SearchRequest request = new SearchRequest("23730");

var response = await tanker.SendAsync(request);
```
