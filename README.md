# Cube Temperature Converison
The solution constitutes a restful Web Api and a MVC Web App written in C# using visual studio on a Mac.
 
## Web Api
I've aimed to create a restfully correct api using the onion architectural approach whilst following SOLID principles. A full OAS spec accompanies the api implemented with swagger.

NUnit test projects have been created for the api projects however Spec flow tests are missing and normally would be created for the various functional routes through the Api.
 
## MVC App
The mvc app is basic as the solution is supposed to be an MVP.  It uses ajax to request a conversion from the mvc controller, the controller makes a http get request to the api endpoint and updates the screen with the result.

An example unit test project accompanies the solution but not all unit tests have been completed.

## Comments
Firstly I must point out that I am using a mac for development which is completely new to me.  I have to say I'm not a fan and have found it has slowed me down considerably compared to developing on a windows machine.
Secondly, the biggest take away from this exercise is just how rusty my frontend work is as more recently I have been working on middle / back end api's and architecture designs.

For the purposes of time I have not created spec flow tests, postman tests and not produced unit tests that would provide complete coverage, however the tests in place should be indicative of the type of tests I would normally create.

A few assumptions for an MVP solution, I've hard wired a user name, from a config file for the purpose of demonstrating its usage.  This would normally come from an existing authentication process. Likewise the api would normally be secured but isn't currently. 

I've implemented the api in a manner that should allow simple extension for adding in different units for conversions so that converting between distance, time, weight etc should be relatively simple to do.


