# Muthant Mapper

Muthant Mapper is a library used to map object to object, avoiding this boring process.

## Get start

### Package Manager
``` csharp
  NuGet\Install-Package Muthant-Mapper -Version 1.1.0.2
```

### .NET CLI

``` csharp
  dotnet add package Muthant-Mapper --version 1.1.0.2
```

## Configuration
At Program.cs file add the method AddMuthant. 

```csharp
  builder.Services.AddMuthant();



```
## Use the power of Muthant Mapper

Use the muthant is very simple, inject the MuthantMapper in you service.

``` csharp
 public class Service
 {
     private readonly MuthantMapper _muthantMapper;

     public WitnessService(MuthantMapper muthantMapper)
     {
         _muthantMapper = muthantMapper;
     }
}

```

### Use the method Transmute to map you objects

``` csharp
  var companyDTO = _muthantMapper.Transmute<companyDTO>(company);
```

### Collections

``` csharp
  var companyDTO = _muthantMapper.Transmute<IEnumerable<companyDTO>>(company);
```

## Configure the profile

You can configure a profile if you need map properties with different names. All you need is create a profile that inherits from Profile and use the method CreateMutation inside the constructor. The first parameter is the class source and the last is the destiny. Channing the methods From and To identify the properties correspondents. The methods From and To are type safety, that is to say the properties need to be of the same types. 
``` csharp
 public class MuthantProfile : Profile
{
    public MuthantProfile() 
    {
        CreateMutation<Company, CompanyDTO>()
          .From(company => company.Name).To(dto => dto.FullName);
          .From(company => company.Id).To(dto => dto.CompanyId);
    }
}
```

### Configure your profile on MuthantMapper

``` csharp
 builder.Services.AddMuthant<MuthantProfile>();
```


 





