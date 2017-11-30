# Using HTTP Methods (GET, POST, PUT, etc.) in Web API

## Selecting The Appropriate Method:
C - Create - POST

R - Read - GET

U - Update - PUT

D - Delete - DELETE

### The algorithm ASP.NET uses to calculate the "default" method for a given action goes like this:

- If there is an attribute applied (via [HttpGet], [HttpPost], [HttpPut], [AcceptVerbs], etc), the action will accept the specified HTTP method(s).
- If the name of the controller action starts the words "Get", "Post", "Put", "Delete", "Patch", "Options", or "Head", use the corresponding HTTP method.
- Otherwise, the action supports the POST method.

### Based Token Authentication
#### Grant Types:
- Password Grant Type: Provides the ability to get an Access Token based on a username and password
- Refresh Grant Type: Provides the ability to generate another Access Token based on a special Refresh Token.
- Client Credentials Grant Type: Provides the ability to exchange an API Key for an Access Token