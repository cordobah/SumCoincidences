# SumCoincidences

## Introduction

This project is a .NET console solution to finds pairs of integers from a list that sum to a given value.

## Development Tools
### Install the following software:
- [.Net 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [VS Code](https://code.visualstudio.com/download) (optional)

### Download the code
-  Clone this repository [GitHub](https://github.com/cordobah/SumCoincidences.git)
```console
git clone https://github.com/cordobah/SumCoincidences.git
```

### Build the code and run
- Go to the folder \SumCoincidences and run the command dotnet build
- Go to the folder \SumCoincidences\bin\Debug\net6.0
- Execute the app SumCoincidences.exe

### Change the input values
- There is a file named [AnalyseSumData.json], in the folder \SumCoincidences\bin\Debug\net6.0. You are able to change the input values in this file.
- Format file:

```json

{
    "Numbers": [1,9,5,0,20,-4,12,16,7],
    "TargetSum": 12
}

```

  - "Numbers": List of integer to operate.
  - "TargetSum": Integer tha represent the target.

