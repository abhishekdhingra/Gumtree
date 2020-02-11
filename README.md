# Gumtree Automation Framework

## Usage

### Pre-requisites:
1. This project is based on .NET Framework and will require an installation of at least version 4.6.1.
2. This project can be built and run using Visual Studio. 
3. NUnit.3.12.0 is the Test Runner for running the tests.
4. Specflow 3.0.224 for writing the BDD tests.
5. The latest chrome browser (version 79 or more) should be installed to execute the tests on chrome browser.

NOTE- If tests are not getting identified in the Visual studio Test explorer then delete all the temporary files in %temp% folder.

### Framework design features:
1. The framework will execute the automated tests in parellel defined in multiple feature files.
2. The automated tests runusing chrome browser only. But code is structured to include other browsers if required later on.
3. The application url, selenium wait time and browser type is configured in the App.config file.

### Executing Using Visual Studio
1. Open the visual studio solution file `Gumtree.Tests.sln`
2. Restore nuget packages by: Solution>Restore NuGet Packages
3. Build solution
4. Run tests using the test explorer: Test>Windows>Test Explorer