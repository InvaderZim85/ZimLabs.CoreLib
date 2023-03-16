# ZimLabs.Core

Core library with some helpfull functions

## Changelog

- 2.3.0

    Added new function `CombineString(param string[] values)` which converts a list of string into a single string where every value gets its own line.

    **Example**

    ```csharp
    var result = Core.CombineString("Value1", "Value2", "Value3");

    Console.WriteLine(result);

    // Result
    // ------
    // Value1
    // Value2
    // Value3
    ```