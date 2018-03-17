# Master branch status
Tool  | Status
-------- | :------------:
AppVeyor | [![Build status](https://ci.appveyor.com/api/projects/status/hr7xj9wr7l7awkkp/branch/master?svg=true)](https://ci.appveyor.com/project/Rychu-Pawel/regonvalidator/branch/master)
SonarCloud | [![reliability](https://sonarcloud.io/api/project_badges/measure?project=RegonValidator&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=RegonValidator) [![security](https://sonarcloud.io/api/project_badges/measure?project=RegonValidator&metric=security_rating)](https://sonarcloud.io/dashboard?id=RegonValidator) [![vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=RegonValidator&metric=vulnerabilities)](https://sonarcloud.io/dashboard?id=RegonValidator)
Nuget | [![Nuget](https://img.shields.io/nuget/v/rychusoft.validators.regonvalidator.svg?style=flat)](https://www.nuget.org/packages/Rychusoft.Validators.RegonValidator/)
Code coverage | [![coverage](https://sonarcloud.io/api/project_badges/measure?project=RegonValidator&metric=coverage)](https://sonarcloud.io/dashboard?id=RegonValidator)

# RegonValidator
Polish REGON number validator 

# Easy to use library for validating Polish REGON numbers:
```csharp
string regon = "575064641";
bool isValid = Rychusoft.Validators.RegonValidator.IsValid(regon);
```
