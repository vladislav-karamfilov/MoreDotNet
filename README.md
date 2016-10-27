# MoreDotNet

[![Build status](https://ci.appveyor.com/api/projects/status/41edqunjstgy8vv5?svg=true)](https://ci.appveyor.com/project/Teodor92/moredotnet)
[![NuGet version](https://badge.fury.io/nu/MoreDotNet.svg)](https://badge.fury.io/nu/MoreDotNet)


## Summary

The project focuses on providing handy extension methods for:
* Collections
* Common DotNet types like string, int, object, Color, Bitmap etc.
* Wrappers for transforming common static methods to instance methods
Example:
```cs
string.IsNullOrWhiteSpace(testStringVar)
```
Is transformed to:
```cs
testStringVar.IsNullOrWhiteSpace()
```

## Installation

NOTE: The package is still under development and some bugs may exist!

You can install this library using NuGet into your project:

```
Install-Package MoreDotNet
```

## License

Code by Teodor Kurtev. Copyright 2016 Teodor Kurtev.

This package has MIT license. Refer to the LICENSE for detailed information.

## License

Code by Teodor Kurtev. Copyright 2016 Teodor Kurtev.

This package has MIT license. Refer to the [LICENSE](https://github.com/Teodor92/MoreDotNet/blob/master/LICENSE) for detailed information.

## Any questions, comments or additions?

If you have a feature request or bug report, leave an issue on the [issues page](https://github.com/Teodor92/MoreDotNet/issues) or send a [pull request](https://github.com/Teodor92/MoreDotNet/pulls). For general questions and comments, use the [StackOverflow](http://stackoverflow.com/) forum.