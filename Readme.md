![FlexmapperLogo](_content/flexmapper.logo.jpg)

# FlexMapper - map models flexible ![License](https://img.shields.io/github/license/SchwabenCode/FlexMapper.png?style=flat-square)
**by [SchwabenCode.com](http://www.schwabencode.com) - Benjamin Abt**

| **VERSIONING** | Build State | NuGet Stable |
|---|---|---|
| master | ![AppVeyorMaster](https://img.shields.io/appveyor/ci/BenjaminAbt/FlexMapper/master.png?style=flat-square) | ![NuGetStable](https://img.shields.io/nuget/v/FlexMapper.png?style=flat-square)  |
| develop | ![AppVeyorDevelop](https://img.shields.io/appveyor/ci/BenjaminAbt/FlexMapper/develop.png?style=flat-square) | ![NuGetPre](https://img.shields.io/nuget/vpre/FlexMapper.png?style=flat-square) |

![NuGetDownloads](https://img.shields.io/nuget/dt/FlexMapper.png?style=flat-square) | ![GitHubRelease](https://img.shields.io/github/release/SchwabenCode/FlexMapper.png?style=flat-square) | ![GitHubRelease](https://img.shields.io/github/issues/SchwabenCode/FlexMapper.png?style=flat-square)

## Website
Checkout the official Page [http://schwabencode.com/projects/FlexMapper](http://schwabencode.com/projects/FlexMapper)

## Project description
FlexMapper is the counterpart to [AutoMapper](http://automapper.org/).
While AutoMapper uses primary a lot of Reflection stuff to map the values of two classes or object, FlexMapper focuses the pointedly manual mapping.

AutoMapper is a great solution if you just want to map simple objects, like ViewModels or data-transfer objects.
But if you're focussed on performance and want to use AutoMapper with contexts like databases or unmanaged connections, AutoMapper is complex to use and hard to test.

## Example

Mapping from entity Person to view model PersonViewModel

#### Person class
```cs
class Person
{
    public String Name { get; set; }

    public DateTime DateOfBirth { get; set; }
}
```

#### PersonViewModel class
```cs
class PersonViewModel
{
    public String Name { get; set; }

    public String DateOfBirth { get; set; }
}
```

#### PersonMapper implementation
```cs
internal class PersonMapper : FlexMapper<Person, PersonViewModel>, IPersonMapper
{
    const string ISO8601DateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";

    /// <summary>
    /// Map from <see cref="Person"/> to <see cref="PersonViewModel"/>
    /// </summary>
    public override PersonViewModel Map( Person t1, PersonViewModel t2 )
    {
        t2.Name = t1.Name;
        t2.DateOfBirth = t1.DateOfBirth.ToString( ISO8601DateTimeFormat ); // Json -> ISO 8601

        return t2;
    }

    /// <summary>
    /// Map from <see cref="PersonViewModel"/> to <see cref="Person"/>
    /// </summary>
    public override Person Map( PersonViewModel t1, Person t2 )
    {
        t2.Name = t1.Name;
        t2.DateOfBirth = DateTime.ParseExact( t1.DateOfBirth, ISO8601DateTimeFormat, null ).ToUniversalTime(); // Json -> ISO 8601

        return t2;
    }
}
```

#### PersonMapper interface
```cs
internal interface IPersonMapper : IFlexMapper<Person, PersonViewModel>
{

}
```

#### Usage
```cs
// Arrange
Person person = GetTestPerson();
IPersonMapper personMapper = new PersonMapper();

// Act
PersonViewModel test = personMapper.Map( person );
```
See the unit test project for full code.

## Give Thanks

If you like the library and saved you time, than maybe respect this with a small donation to the [animal shelter of Stuttgart](http://www.tierheim-stuttgart.de/).

If you want to thank me personally, take a look at [my personal Amazon wishlist](http://www.amazon.de/gp/registry/wishlist/H6KLKT7UMI7Z/).

It would be also very nice when you just write me, if you like this implementation and tell me what you've started!

## License
[MIT License](https://github.com/SchwabenCode/FlexMapper/blob/master/LICENSE.md)

> Copyright (c) 2015 Benjamin Abt
> 
> Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
> 
> The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
> 
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

## NuGet
```
Install-Package FlexMapper
```
or visit [FlexMapper on NuGet](https://www.nuget.org/packages/FlexMapper/)

## Branches
- [master](https://github.com/SchwabenCode/FlexMapper/tree/master): stable
- [develop](https://github.com/SchwabenCode/FlexMapper/tree/develop): used during development

## Remarks
This library was created on the basis of my own needs. I am not responsible for integration issues, errors or any damage.
On usage problems, please use public forums. For bugs and features please fork to your own branch, fix it and create a pull request or use the [issue tab](https://github.com/SchwabenCode/FlexMapper/issues).

Thank you and good luck with your software.
