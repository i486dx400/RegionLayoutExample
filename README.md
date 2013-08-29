Deprecated: Use https://github.com/i486dx400/MultiRegionPresenter.git


Region Layout Example
============

This demonstrates how to define multiple regions on the screen and dynamically fill the regions with different layouts at runtime.

After the splash screen, a loading screen is displayed.  It will remain until the LoadFinishedCommand is called, and then continue to the region layout.

The region layout, in this example, has three regions: navigation, main, and popup.  The back button functionality has also been overridden to return from the popup region but not the other two regions.

Uses MvvmCross and creates an android app.


Before building, use NuGet to pull in these packages for each project:

RegionEx.Core
 - MvvmCross

RegionEx.Droid
 - MvvmCross 
 - MvvmCross Fragging
 - MvvmCross Visibility Plugin
