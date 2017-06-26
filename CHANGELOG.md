# Changelog

## 1.1.2 (2017-06-26)

### Fixes

* Client Id updated

## 1.1.1 (2017-05-23)

### Fixes

* Code refactoring

	* Renamed WinForms namespace to Forms

	* Added Helpers namespace

		* FormHelper added

	* Added partial class file for CloudDripForm to handle events (CloudDripForm.Events.cs)

	* Restructured classes

		* private

		* constructor

		* public

	* Added Models namespace and moved Preferences and SoundCloudTrack to it

	* Added comments to SoundCloudTrack model

	* User class in SoundCloudTrack file moved inside of SoundCloudTrack class

	* Changed Begin method name to Start in Initializer class

### To do

* Next version (1.2)

	* Setting to open directory to downloaded mp3

	* Add checks to prevent crashing

	* Add download queue for downloading multiple tracks

	* Look into improving performance (slow downloads lag application)

## 1.1 (2017-05-07)

### New features

* Preferences form

	* Remember save path

	* Auto-paste from clipboard on startup

	* Proxy

	* Show download info (toggles textbox below progress bar)

* Mp3 metadata added

	* Title

	* Artist

	* Genre

	* Track cover

* Tracks are now saved with their name instead of their song id

### Minor changes

* Added CloudDrip icon to window

* Download progress

	* Progress bar has been added

	* Giant progress textbox has been slimmed and can be toggled

* Reduced CloudDrip window size

* `Exit` menu option added

* `About` menu option added with message box

* Removed maximize window on all forms

* Removed window resizing on all forms

* Renamed Settings to DownloadVars

* Added CloudDrip.Core.Serialize namespace for storing objects to be (de)serialized.

	* Preferences

	* SoundCloudTrack

* Implemented MultiTextWriter which allows me to use Console.WriteLine to display download progress in both the console and download info textbox

### Fixes

* Renamed names of form items (i.e. what's label3 referencing?)

* Finished code refactoring and commented more code

	* Moved `GetArtCover()` from WebHandler to Initializer's `ApplyMetadata` method

	* Moved a few local string setters into class properties (i.e. `stream_url` property in SoundCloudTrack now applies clientId)

	* Updated `OpenDownload` method in WebHandler to be much cleaner

	* Changed `DownloadListener` method to private and it's now called within `OpenDownload` method

* Added `using(client = new WebClient())` since WebClient implements IDisposable

* Deserializer now a template class instead of SoundCloudTrack class strict

* Invalid save path will no longer crash application on download

### To do

* Add import functionality

* Restructure classes a little bit to get them into other namespaces. Not everything needs to be in CloudDrip.Core

* Add more checks to prevent application crashing

	* If there's an issue using a proxy, the program will crash

	* If the SoundCloud URL doesn't work, the program will crash

## 1.1-alpha-2 (2017-05-02)

### Minor changes

* Added CloudDrip icon to window

### Fixes

* Finished code refactoring and commented more code

	* Moved `GetArtCover()` from WebHandler to Initializer's `ApplyMetadata` method

	* Moved a few local string setters into class properties (i.e. `stream_url` property in SoundCloudTrack now applies clientId)

	* Updated `OpenDownload` method in WebHandler to be much cleaner

	* Changed `DownloadListener` method to private and it's now called within `OpenDownload` method

* Added `using(client = new WebClient)` since WebClient implements IDisposable

* Deserializer now a template class instead of SoundCloudTrack class strict

### To do

* Import form for downloading multiple tracks via CSV file

* Preferences for remembering save directory, auto-paste, etc.

## 1.1-alpha (2017-04-30)

### New features

* Mp3 metadata added

	* Title

	* Artist

	* Genre

	* Track cover

* Tracks are now saved with their name instead of their song id

### Minor changess

* Download progress textbox changed to progress bar

* Reduced CloudDrip window size due to removal of DL progress textbox

### Fixes

* Renamed names of form items (i.e. what's label3 referencing?)

### To do

* Add CloudDrip icon

* Refactor

	* Some class methods are doing operations other class methods should handle

	* Comment code

* Import form for downloading multiple tracks via CSV file

* Preferences for remembering save directory, auto-paste, etc.
