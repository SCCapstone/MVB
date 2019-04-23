# "Message in a Virtual Bottle" Oculus Go Virtual Reality App

This project reflects a student's experience at the University of South Carolina (USC) through the use of an Oculus Go virtual reality (VR) headset. The app gives imagery and audio descriptions of student life at USC in VR; it covers a student's journey and showcases the main areas of campus and the Columbia, SC area. The app is primarily designed for MBA students at the Darla Moore School of Business and incoming / prospective undergraduate students in the Department of Computer Science and Engineering as well as the Darla Moore School of Business. It could also be used for distance education students to give them a feel of a student's experience at the university. 

[About the Developers](https://sccapstone.github.io/MVB/about.html)

# Installation for Development
## Prerequisites
* Clone the MVB Repository
* Download the [Latest Version of Unity](https://unity3d.com/get-unity/download)
* Download [Android Studio](https://developer.android.com/studio/) <br/>
When installing Unity, make sure `Android Build Support` is selected.

### Setup Android Studio
* Open Android Studio and click `Configure` at the bottom right and select `SDK Manager`.
* Under `SDK Platforms`, make sure to check and install `API Level` 21 - 28 or from Android 5.0 up to the latest. (Currently 7) and click Apply. Installation can take up to several hours.

* Move over to `SDK Tools` and select `Show Package Details` and install 28.0.2 or the latest. 
* Make sure under `LLDB` latest version is installed.
* Install `Android SDK Platform-Tools`, `Android SDK Tools` and `NDK`
* After installation, go back to `Configure` Menu and select `Project Defaults` then `Project Structure`
* Save the location directory of `Android SDK location`, `JDK location`, and `Android NDK location` for later use. (Notepad)
* Setting `Environment Variables`. On Windows machine, search for “Environment Variables”. This should take you to Control Panel > System Properties, Go to the Advanced Tab, then to the Environment Variables button in the lower right.
* In the top section, set/modify/add the following variables:
* `Set the environment variable JAVA_HOME to the JDK location`
* `Set the environment variable ANDROID_HOME to the Android SDK location.`
* `Set the environment variable ANDROID_NDK_HOME to the Android NDK location.`
* `Add the JDK tools directory to your PATH, ie C:\Program Files\Android Studio\jre\bin`

### Setup Unity to Build for Android
* Go to **File > Build Settings**
* Select Android and then **Switch Platform.** (If you did not add Android support when you first installed Unity, you will have to do so now, then restart Unity).
* Close out and go to **Edit > Preferences** then **External Tools** Tab
** Scroll down to Android section and set `SDK, JDK, NDK` paths from earlier ten close
* Now go to **Edit > Project Settings > Player**
* Scroll to **XR Settings** and choose **Oculus** within the **Virtual Reality SDKs** box (Make sure **Virtual Reality SDK** is ticked)

### Setup Android Debug Bridge (adb)
**This step is *required* to get the app onto the Oculus Go

* Download and install the [Occulus Go ADB Driver](https://developer.oculus.com/downloads/package/oculus-go-adb-drivers/)
* Unzip the file and Right click on the **.inf file** and **install.

### Connecting the Oculus Go to Build
* Connect the Oculus Go to PC via USB
* Run `adb devices` to make sure the Oculus Go has been connected
* In Unity, go to **File > Build Settings** and Build your scenes
* Save your APK somewhere for your builds and copy that build to where you installed the ADB from last step
* then **Run** `adb install [buildname].apk
* After you see, **SUCCESS** on the screen, that means it has downloaded to your GO.
* Inside your GO, Go to **Library > Unknown Sources** and you should see your Built app there.

### Further Reference for Development
* [Video: How to Build an Oculus Go App with Unity](https://www.youtube.com/watch?v=LSypZfOChYE)
* [Article: How To Build an App for the Oculus Go From Start To Finish (with Unity)](https://medium.com/inborn-experience/how-to-build-an-app-for-the-oculus-go-from-start-to-finish-with-unity-cb72d931ddae)

### Testings
* The Unity Test Runner currently does not seem to have much support for VR/Oculus Go testings; therefore, the tests are without the VR inputs and setups
* The tests are located under Assets/Tests directory.
* Current test are scene switching when button is clicked and check whether the door is opened or closed. 
* All tests are done through the built-in Unity Test Runner. 
* To access Unity Test Runner, go to Window > General > Test Runner, then select Play Mode then Run All.
* [More information on the Unity Test Runner](https://docs.unity3d.com/Manual/testing-editortestsrunner.html)


## Developers

* **Franco Godoy**
* **Sadad Khan**
* **Andy Michels**
* **Paolo Milan**
* **Allen Sanamandra**
* **Kenny Richardson**

## Contributing

* **Dr. Kirk Fielder**

## Acknowledgments

* **Dr. Jose Vidal**
