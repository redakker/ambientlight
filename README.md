# AmbientLight

This small Windows form program is created to analyze the PC screen and calculate an average color. This calculated color can be sent as a webhook or in an MQTT message.
The output color data can be an RGB color code (128,234,55) or a HEX code (#D36AF4)

![alt text](https://raw.githubusercontent.com/redakker/ambientlight/main/AmbientLight/material/ui.JPG)

## What is it for?

This tool can be used to create an ambient light behind your PC monitor. Any remote controlled light can be used as light source.
For example you can use a microcontroller and LED strip with https://github.com/Aircoookie/WLED installed on it.

Demo:
![alt text](https://raw.githubusercontent.com/redakker/ambientlight/main/AmbientLight/material/demo.gif)

## Features

- calculate the average color of the screen
- shows the calculated screen on the UI
- calculate the color manually
- minimize to tray option
- send the color data over MQTT
- send the color data by calling a webhook
- set send frequiency between 200ms and 15s 
- skip the dark pixels (if R and G and B component are under 100)
- save config to a file (C:\Users\ [username] \AppData\Roaming\AmbientLight\config.json)

## Todos / Known issues

- currently, it analyzes **primary** screen only
- it has no output (debug, error log)
- TODO: divide the screen to segments and send more colors for LED strip. On WLED it is possible to have segments too. 

## Usage

Download the release version from here: https://github.com/redakker/ambientlight/releases/tag/release

- run in your Windows system
- set the MQTT credentials or the Webhook
- set the desired checkboxes
- change the send frequency if needed
- press apply settings

If the "Running" checkbox is set then the calculated RGB or HEX code is sent periodically with a set frequency.

## Examples

### Control WLED
Configure a webhook which calls the WLED microcontoller's API. The webhook is similar to this

http:// [WLED_IP_ADDRESS] /win&T=1&FX=0&SX=0&R={R}&G={G}&B={B}

### Control LEDs with Home Assistant

Configure an automation which listents on an MQTT topic. Example:
- topic: /ambient/color
- message: {R},{G},{B}

Configure an action for this automation which applies the RGB color for the chosen lights

## For developers

This software is developed in Visual Studio 2022. After download the repository, open the solution file and it will be ready to run.

Environment: .NET 6


This is my first .NET project so please be nice to me if you find some mistake. :)

Buy me a coffee: https://www.buymeacoffee.com/redakker


