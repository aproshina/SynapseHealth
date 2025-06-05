This project is a minimal ASP.NET Core web application that uses OpenAI
to extract structured medical device order data from free-form text. 


## **Usage**
.NET 8 SDK
An OpenAI API key (store it as OPENAI_API_KEY environment variable or edit appsettings file)

**To Run:**

Download the provided .zip file containing the project.
Open command prompt
Navigate to the project folder. For example:
	cd ..\SynapseHealth\SynapseHealth\bin\Release\net8.0
Run application:
	SynapseHealth.exe
Open the web UI
	http://localhost:5101/



**General thoughts**

This is starting basic project to test templates. It can be grown in functionality - like file export of runs with results, option to run sets of inputs for testing from the file, history of prompts and so on.
Ultimatly it can allow testing of prompts on predefined sets of data, giving results, providing improvements and revalidating them on the same set. 
Prompt results would be more usable if json output would be defined. Certain things like "components" vs "features" vs "accessories" can be hard to explain for stable results.



	
