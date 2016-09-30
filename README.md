# MoreDotNet

[![Build status](https://ci.appveyor.com/api/projects/status/41edqunjstgy8vv5?svg=true)](https://ci.appveyor.com/project/Teodor92/moredotnet)
[![NuGet version](https://badge.fury.io/nu/MoreDotNet.svg)](https://badge.fury.io/nu/MoreDotNet)


## Summary

The project focuses on providing handy extension methods for:
* Collections
* Common DotNet types like string, int, object, Color, Bitmap etc.
* Wrappers for transforming common static methods to instance methods
Example:
```
string.IsNullOrWhiteSpace(testStringVar)
```
Is transformed to:
```
testStringVar.IsNullOrWhiteSpace()
```

## Installation

NOTE: The package is still under development and some bugs may exist!

To install via NuGet use:

```
Install-Package MoreDotNet
```
