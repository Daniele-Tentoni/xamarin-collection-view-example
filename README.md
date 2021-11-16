# Collection View example

Created to show un unexpected behaviour using Collection View control from Xamarin Forms library.

## How to reproduce

1. Clean the starter Shell template leaving only Collection View page
2. Add many elements to the Collection View
3. Add an Header to Collection View with a Control like a Picker (not a Label, with a Label it's working)

![Simulator Screen Shot - iPod touch (7th generation) - 2021-11-16 at 22 05 55](https://user-images.githubusercontent.com/11157241/142066286-1ad16927-2d74-4c07-8101-d4bfaebfd00a.png)

## How I mitigated

1. Rotating the emulator

![Simulator Screen Shot - iPod touch (7th generation) - 2021-11-16 at 22 06 00](https://user-images.githubusercontent.com/11157241/142066305-4560d22c-c640-4b4c-b218-237947334659.png)
![Simulator Screen Shot - iPod touch (7th generation) - 2021-11-16 at 22 06 06](https://user-images.githubusercontent.com/11157241/142066316-d6766c27-92dc-4fc6-9c06-6b0037cb0089.png)


## Platforms

Only on iOS.
