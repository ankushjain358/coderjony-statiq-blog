Title: Useful Ionic-CLI Commands for Android Application Development using Ionic 4 and Cordova
Published: 04/07/2019
Author: Ankush Jain
IsActive: true
Tags:
  - Ionic
---
As I was developing an Android application using `Ionic 4`, I found a few commands quite useful during development. I thought to make a note of those useful commands here.

* `ionic start [<name>] [<template>]` - Create a new project.
* `ionic serve` - Open up the Ionic application in the browser.
* `ionic cordova run android` - Run the Ionic application in either emulator or connected Android device.
* `ionic cordova emulate android` - Emulate an Ionic project on a simulator or emulator.
* `ionic cordova build android` - Build the ionic application & generates a debug `.apk` file.
* `ionic cordova build android --prod --release` - Build the ionic application & generate a release `.apk` file.
* `ionic cordova platform add android` - Add Android as a platform in an Ionic application.
* `ionic cordova prepare` - Install platforms and plugins listed in config.xml of the Ionic Cordova application.
* `ionic g` - Generate pipes, components, pages, directives, providers, and tabs.

You can also find a complete list of Ionic CLI commands on its official website. Here is the link - [https://ionicframework.com/docs/v3/cli/commands.html](https://ionicframework.com/docs/v3/cli/commands.html)

                