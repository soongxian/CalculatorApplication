# CalculatorApplication

Question
----------------
Develop a calculator application service using the C# .NET Core that accepts XML data via HTTP POST, performs specified mathematical operations, and returns the result as XML over HTTP.
- The service should demonstrate serialization, inheritance, encapsulation, and interface design principles.
- It must be designed to handle various XML inputs with minimal changes to the C# code.
- Implement Test-Driven Development (TDD) to validate that the calculator functions correctly.

```
<?xml version="1.0" encoding="UTF-8"?>
<Maths>
  <Operation ID="Plus">
    <Value>2</Value>
    <Value>3</Value>
    <Operation ID="Multiplication">
      <Value>4</Value>
      <Value>5</Value>
    </Operation>
  </Operation>
</Maths>
```
