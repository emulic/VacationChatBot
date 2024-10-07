# TestConsole

`Daenet.PluginTestConsole` is a simple console library application designed for the development and testing of Semantic Kernel plugins. While testing plugins is not a particularly complex task, it requires several repetitive steps such as loading plugins, configuring them, implementing a chat loop, maintaining message history, executing plugin functions, and more. Although these tasks are straightforward, they can become tedious when repeated frequently.

To streamline this process and accelerate development, we have created a library that simplifies the implementation of a testing console application. This console application can be used to quickly learn how to develop Semantic Kernel plugins and speed up the development process.

## Getting Started

To implement a plugin, follow these steps:

1. **Create a Console Application**: 
   Start by creating a new console application.
   
2. **Add the Package Reference**: 
   Add a reference to the package `Daenet.PluginTestConsole`.

3. **Implement Plugin Code**: 
   Implement the plugin-specific logic within your console application.

## Plugin Implementation

A plugin is a class, and the methods within the class represent the plugin's functions, which are invoked by a large language model (LLM). Each plugin class must have a corresponding configuration class. The configuration class must have the same name as the plugin class, suffixed with the word `Config`.

### Examples

- For a plugin class named `MyPlugin`, the configuration class should be named `MyPluginConfig`.
- Similarly, if you have a plugin named `AbcPlugin`, its configuration class should be named `AbcPluginConfig`.

This is not a strict requirement of the Semantic Kernel (SK), but it is considered a best practice to ensure that each plugin has an associated configuration class. This structure helps maintain clarity and modularity in the plugin design.

## Bootstrapping

We provide the necessary bootstrap code to load and initialize all plugins, streamlining the entire process. By leveraging this bootstrap code, you can concentrate on developing the core functionality of your plugins while the framework takes care of the repetitive setup and initialization tasks.

Using `Daenet.PluginTestConsole` simplifies the development and testing of Semantic Kernel plugins, enabling you to focus on innovation rather than infrastructure.

## Plugin Configuration

Plugin configuration is managed in the `appsettings.json` file. Configuration details for each plugin are specified in two places within this file. All plugins must be listed under the `Plugins` section, ensuring that the framework can load and initialize them properly.


~~~json
  "Plugins": [
    {
	  "Name": "Plugin1",
	  "AssemblyQualifiedName": "Daenet.GptBot.PluginLib.Cpdm.Plugin1, PluginAssemblyName1",
	  "JsonConfiguration": {
		"Prop1": "https://",
		"Prop2": "testkey"
	  }
	},
	{
	  "Name": "Plugin2",
	  "AssemblyQualifiedName": "Daenet.GptBot.PluginLib.Cpdm.Plugin2, PluginAssemblyName2",
	  "JsonConfiguration": {
		"Prop1": "https://",
		"Prop2": "testkey"
	  }
	}
  ],
~~~


# Test Console Plugin: Function Documentation

The Test Console Plugin provides several utility functions designed to enhance the development and testing of Semantic Kernel plugins. These functions allow you to clear console output, manage conversation history, customize prompt appearances, and list available plugins. This documentation outlines the functions available and provides example use cases for each.

## Function Overview

### 1. `ClearConsole`

- **Description**: Clears all text currently displayed in the console.
- **Use Case**: Useful when starting fresh, ensuring that no previous messages or clutter remain in the console.
  
### 2. `ClearMessageHistory`

- **Description**: Deletes all messages from the conversation history but does not affect the text displayed in the console.
- **Use Case**: Ideal for resetting the conversation history while retaining previous console logs for reference.

### 3. `ListPlugins`

- **Description**: Retrieves a list of loaded plugins, with the option to display additional details for each plugin.
- **Use Case**: Helps developers quickly identify which plugins are available and, if required, fetch detailed information about each plugin.
- **Parameters**:
  - `details` (boolean, optional): If set to `true`, additional information about each plugin is displayed.

### 4. `SetSystemPromptColor`

- **Description**: Customizes the color of the system prompt in the console.
- **Use Case**: Allows users to personalize the appearance of the system prompt for better readability or personal preference.
- **Parameters**:
  - `color` (string): Defines the desired color of the system prompt. Available options:
    - `"Black"`, `"DarkBlue"`, `"DarkGreen"`, `"DarkCyan"`, `"DarkRed"`, `"DarkMagenta"`, `"DarkYellow"`, `"Gray"`, `"DarkGray"`, `"Blue"`, `"Green"`, `"Cyan"`, `"Red"`, `"Magenta"`, `"Yellow"`, `"White"`.

### 5. `SetUserPromptColor`

- **Description**: Changes the color of the user prompt/input.
- **Use Case**: Enables customization of the user prompt color for improved visibility or user preference.
- **Parameters**:
  - `color` (string): Defines the desired color for user input. The available options are the same as for `SetSystemPromptColor`.

### 6. `SetAssistantColor`

- **Description**: Adjusts the color of the assistant’s response messages in the console.
- **Use Case**: Distinguishes assistant messages from user inputs and system prompts through color customization.
- **Parameters**:
  - `color` (string): Specifies the desired color for assistant messages. Options are the same as those available for the system prompt.

### 7. `SetSystemPromptText`

- **Description**: Modifies the default text displayed in the system prompt.
- **Use Case**: Personalizes the system prompt text to meet specific testing or development needs.
- **Parameters**:
  - `promptText` (string): The custom text to be displayed as the system prompt.

# Implement the console test application

To work with plugins You will have to implement the plugin and to provide a host application.
Plugins are typically implemented in some library, which is refernced by the host application.
The solution *Daenet.PluginTestConsole.App* is a sample console application, which demonstrates
how to run the console with LLM functionality, which automatically loads your plugin.
The plugin in the sample application *Daenet.PluginTestConsole.App* is implemented in the class MyPlugin.
It provides a simple functionality to get information about running processes on the system.


~~~csharp
namespace Daenet.PluginTestConsole.App
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await TestConsole.RunAsync(args);
        }
    }
}
~~~

# Call to action

Please feel free to use it and extend it as you need.
Plugins are implemented inside the project *Daenet.GptBot.PluginLib*.