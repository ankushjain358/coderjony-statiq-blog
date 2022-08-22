Title: Understanding Android SDK ecosystem
Published: 07/08/2021
Author: Ankush Jain
IsActive: true
ImageFolder: understanding-android-sdk-ecosystem
Tags:
  - Android
---
Android SDK has a variety of tools that helps you to develop a mobile application for the Android platform. These tools have been classified into 2 groups.
*   SDK Platforms (Platform dependent components)
*   SDK Tools (Platform independent components)

Here, consider the platform as an Android release such as **Android 11 (API level 30)** or **Android 10 (API level 29)**.

![Classification of Android SDK](/img/blogs/understanding-android-sdk-ecosystem/android-sdk.png)

## 1. SDK Platforms <sub><sup>(Platform dependent components)</sup></sub>

These tools are platform-dependent and are updated whenever a new version of Android is released in the market. This includes the following components:
- Updated framework libraries
- Updated source code
- Updated system images 

For example, whenever there is a new Android release, let's say **Android 12 (API Level 31)**, then these components of Android SDK will also be updated to support the latest features of the new Android release.

### 1.1 Android SDK Platform <sub><sup>(A container for multiple packages)</sup></sub>
**Android SDK Platform** refers to a package available for a specific android release such as **Android 11 (API level 30)** or **Android 10 (API level 29)**.

Each SDK Platform version includes the following packages.

- **Android SDK Platform** package - This is required to compile your app for that version.
- **System Image** packages - At least one of these is required to run that version on the Android Emulator.
- **Sources for Android** package - This includes the source files for the platform.

This image shows different SDK Platforms and their components. 

![Android SDK Platforms](/img/blogs/understanding-android-sdk-ecosystem/sdk-platforms.png)

## 2. SDK Tools <sub><sup>(Platform independent components)</sup></sub>
These are platform-independent and are required no matter which Android platform you are developing. It includes the complete set of development and debugging tools for the Android SDK like an `emulator`, `apkanalyzer`, `avdmanager`, `sdkmanager`, etc.

These tools have been grouped and categorized in the below categories:
*   Command Line Tools
*   Build Tools
*   Platform Tools
*   Emulator


> Though SDK Tools are platform-independent, but still we should verify the minimum supported version while developing for specific Android Platforms such as **Android 11 (API level 30)**, **Android 10 (API level 29)**, etc.

![Android SDK Tools](/img/blogs/understanding-android-sdk-ecosystem/sdk-tools.png)

### 2.1 Command Line Tools
The Android SDK Command-Line Tools package contains various tools for building and debugging Android apps. Command-line tools include `apkanalyzer`, `avdmanager`, `sdkmanager`, `screenshot2`, `lint`, `retrace`.

These tools are located at `<sdk_root>/cmdline-tools/version/bin/`

### 2.2 Android SDK Build Tools
Android SDK Build-Tools is a component of the Android SDK required for building Android apps. Build tools include `aapt2`, `apksigner`, `zipalign`, etc.

These tools are located at `<sdk_root>/build-tools/` directory. The output of the build tool is an APK file.

### 2.3 Android SDK Platform Tools
**Android SDK Platform Tools** is a component for the Android SDK required to support the features of the latest Android platform. 

> **Important:** Each update of the Android Platform Tools is backward compatible. So, some new features in these tools (in other words new features of the latest android release) are available only for recent versions of Android, but the app will still work on older devices. So for the development, you need to keep only one version of the SDK Platform-Tools.

Examples of the platform-tools include `Android Debug Bridge (adb)`, `etc1tool`, `logcat`, `fastboot`, etc. 

These tools are located at `<sdk_root>/platform-tools`.

### 2.4 Android Emulator
The Android Emulator simulates Android devices on your computer so that you can test your application on a variety of devices and Android API levels without needing to have each physical device.

We use `avdmanager` tool to create an Android Virtual Device. This `avd` further depends on the platform-specific system image. We use `emulator` utility to run these virtual devices. Emulator tools include `mksdcard` and `emulator`.

Emulator tools are located at `<sdk_root>/emulator/`

## That's all

I hope you have enjoyed this article. Your valuable feedback, questions, or comments about this article are always welcome.

                
