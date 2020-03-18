# CoCo .NET CORE SDK

SDK for implementing Conversational Components from CoCoHub in your Bot: 
[https://conversationalcomponents.com](https://conversationalcomponents.com)

## Installation:

```
dotnet add package CoCoSDK --version 1.0.1
```

## SDK Classes:
* CoCoContext - CoCo component response object, contains:
     - public string action_name - Response action name.

     - public string response - Bot response.

     - public bool component_done - Component done flag. True when component accomplished it's goal.

     - public bool conmponent_failed - Component failed flag. True when component could not acomplish it's goal. 

     - public bool out_of_context - True when conversation went out of component conversation context.

     - public float confidence - Answer confidance.

     - public float response_time - Bot response time.

     - public Dictionary<string, string> updated_context - Conversation context parameters.

* CoCo - Conversational Components SDK functions class, contains: 
  ```
  public CoCoContext Exchange(string ComponentId, string SessionId, string UserInput, Dictionary<string, string>             Context=null)
  ```      
    - ComponentId - Target CoCo Component from CoCoHub.
    - SessionId - Current session ID.
    - UserInput - User text input.
    - Contect - Context variables.

  
  
