# DocumentDistance

The `DocumentDistance` project is a C# class that provides a method to calculate the document distance (angle) between two text documents. The document distance is a measure of similarity between two documents based on their word frequencies. The lower the angle, the more similar the documents are.

## Table of Contents

- [Introduction](#introduction)
- [Usage](#usage)
- [Method](#method)
- [Installation](#installation)
- [Examples](#examples)
- [License](#license)

## Introduction

When working with text documents, it's often useful to determine how similar two documents are. The `DocDistance` class allows you to calculate the document distance between two text documents. This distance is calculated based on the cosine similarity between the word frequencies of the documents. The result is a value between 0 and 180 degrees, where lower values indicate higher similarity.

## Usage

To use the `DocDistance` class, follow these steps:

1. Include the `DocDistance.cs` file in your project.
2. Use the `CalculateDistance` method to calculate the document distance between two documents.

Example:

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        string doc1FilePath = "path/to/document1.txt";
        string doc2FilePath = "path/to/document2.txt";

        double distance = DocDistance.CalculateDistance(doc1FilePath, doc2FilePath);
        Console.WriteLine($"Document distance: {distance} degrees");
    }
}
```

Make sure to replace `"path/to/document1.txt"` and `"path/to/document2.txt"` with the actual file paths of the documents you want to compare.

## Method

The `DocDistance` class provides the following method:

### `CalculateDistance(string doc1FilePath, string doc2FilePath)`

Calculates the document distance between two text documents.

- Parameters:
  - `doc1FilePath`: The path to the first document.
  - `doc2FilePath`: The path to the second document.

- Returns:
  - A double value representing the document distance in degrees.

## Installation

1. Download the `DocDistance.cs` file from this repository.
2. Add the file to your C# project.

## Examples

Check the [Examples](Examples/) directory for sample text documents and example usage of the `DocDistance` class.

## License

This project is distributed under the MIT License. Feel free to use and modify it according to your needs.

```plaintext
MIT License

...

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
...
```

**Note:** The included comments within the code provide additional information about the functionality and logic of the `DocDistance` class.

---

Feel free to incorporate and adapt this `DocumentDistance` class into your project to calculate the similarity between two text documents based on their word frequencies. If you encounter any issues or have suggestions for improvements, feel free to contribute or reach out to the project maintainers.
