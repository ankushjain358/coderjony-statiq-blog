Title: Theming in Android - Creating a Custom App Theme
Published: 27/10/2018
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
Android has by default many themes. For example, below are some existing themes in Android:

*   Theme.AppCompat

*   Theme.AppCompat.CompactMenu

*   Theme.AppCompat.Light.DarkActionBar

*   Theme.Material

*   Theme.Material.Light

*   Many more other themes....



All such pre-built android themes has several properties along with their default values. For example, all such themes will have properties like below:

*   windowBackground

*   windowActionBarOverlay

*   textColorPrimary

*   textColorSecondary

*   and so on



You can find a complete list of such default android properties here - [Android Themes Properties](https://chromium.googlesource.com/android_tools/+/25d57ead05d3dfef26e9c19b13ed10b0a69829cf/sdk/platforms/android-23/data/res/values/themes.xml).

Remember these properties are defined by Android system. It's native components i.e. TextView, ActionBar reads values from such properties. Though, you can override their value in your custom theme. But if you don't override any property, then it's default value will be used.

## Defining Custom Theme in Android

Below is an example, where we have created our own Android Theme by inheriting it from `Theme.AppCompat.Light.DarkActionBar` android theme. We just override few properties. See example code below:

```
    <resources>
        <!-- Base application theme. -->
        <style name="AppTheme" parent="Theme.AppCompat.Light.DarkActionBar">
            <!-- Customize your theme here. -->
            <item name="colorPrimary">#E91E63</item>
            <item name="colorPrimaryDark">#C2185B</item>
            <item name="colorAccent">#FF5252</item>
        </style>
    </resources>
    ```

 **We can apply themes in two ways:**

1.  **On Application Level -** By using Application Manifest XML
file.

2.  **On Activity Level -** By applying attribute on Activity class.



Below two articles helped me most in understanding the concept of theming in Android:

*   [Mastering Android Themes - Most Recommended](https://medium.com/mindorks/mastering-android-themes-chapter-1-4aadfa750ca7)

*   [Material Theme](https://docs.microsoft.com/en-us/xamarin/android/user-interface/material-theme)


                