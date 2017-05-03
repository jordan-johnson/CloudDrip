# Changelog

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
