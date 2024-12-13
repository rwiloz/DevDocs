---
title: "Example Reference"
description: "Reference pages are ideal for outlining how things work in terse and clear terms."
menu:
  g3:
    weight: 0
summary: ""
date: 2023-09-07T16:13:18+02:00
lastmod: 2023-09-07T16:13:18+02:00
draft: false
#weight: 910
toc: true
seo:
  title: "" # custom title (optional)
  description: "" # custom description (recommended)
  canonical: "" # custom canonical URL (optional)
  robots: "" # custom robot tags (optional)
---

# Flow Data Helpers

## Dialog Helpers

### XML Mapping

Helps map from a the case schema to an xsd as the inital setup
The export will create a CSV of the connect configuration

### HTML Mapping

Helps map from a the case schema to a HTML template used to create a PDF
Sections add login to show or hide parts of the template

## Default Mapping

|            |                                                                                                |
| ---------- | ---------------------------------------------------------------------------------------------- |
| **YAML**   | Display the current process config in YAML, it can be used to edit or copy & paste sections    |
| **Data**   | The main configuratipn dialog, more below                                                      |
| **Shared** | Data cna be mapped to a "shared" area like variables that tehn can be using in other processes |
| **Output** | Used to translate the default process output                                                   |
|            |                                                                                                |

## Data Mapping

### Conditions

Conditions are used to allow or stop the mapping. Conditons use similar formulas to Calculcations (below) but must return a true or false.

```
Get("case.addMerchant.amex")=="True"
```

### Source Type

|                       |                                                                                                                                                                                                                 |
| --------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Case Data**         | The default                                                                                                                                                                                                     |
| **Case Property**     | Allows access to system information outside of the acutal case data, these include<ul><li> caseId</li><li>caseType</li><li>owner</li><li>status (also in case data)</li><li>created</li><li>completed</li></ul> |
| **Input**             |                                                                                                                                                                                                                 |
| **Calculation**       | See below                                                                                                                                                                                                       |
| **Shared**            | Trigger Data                                                                                                                                                                                                    |
| **Paramater**         | Trigger Data                                                                                                                                                                                                    |
| **Text: Static Text** |                                                                                                                                                                                                                 |
| **Special**           |                                                                                                                                                                                                                 |
| **Heading**           | Used to break up the configuation on the LHS of the data mapping dialog                                                                                                                                         |
|                       |                                                                                                                                                                                                                 |

### Array Source

The array source is used to break up the source, the array source is interated for each item, the source is then used to access the data using a property with the same name are the array

Array Source example

```
terminalAltLocations[].providers[]
```

Source (providers is a signle item of providers[])

```
Get("providers.profession.aphra") == "Y" && (Get("providers.ahpraInfo.surname") != Get("providers.surname") || (HasValue("providers.ahpraInfo.middleName") ? (Get("providers.ahpraInfo.firstName") + " " + Get("providers.ahpraInfo.middleName")) != Get("providers.givenNames") : Get("providers.ahpraInfo.firstName") != Get("providers.givenNames"))) ? "" : "Yes"
```

### Source

Used in conjunction with the source type

The source cam also start with input. or param. (old logic)

### Special Source Prefixes

#### NextRef

Gets the next reference number/counter, example below uses the SingleMerch "GetNext" counter which is configured as

```
NextRef:SingleMerch
```

Examples of GetNext config
|Name|Prefix|Final Length|Counter
|--|--|--|--|
|Amend|C|9|126413
|SingleMerch|A|9|102703
|MultiMerch|M|9|102664
|ChangeOwner|Z|9|101012

#### Now

The current date and time

#### ExtractFile

Extacts the most recent file associated with the source, returning the filename

Options:

- base64, as base64 data

#### FileUrlData

Extacts the most recent file associated with the source, returning the data in URL base 64 format

#### ExtractFileDate

Extacts the date and time of most recent file associated with the source

#### ExtractSignaure

Extacts signature data to a file (normally SVG data)

Options can also be added in this format

```
SpecialCode,option1,option2:
```

Options:

- base64, as base64 data
- png, as a png image
- 999x999, image size in pixels

Example for a Special Prefix

```
extractSignature,64,png,500x300:director1.directorSign
```

### Calculation (formulas)

You can use .Net C# code to calulate a result (or condition true/false), however if you reference a property that doesn't exist it can blow up. For that reason it's good to use the Get() below to ensure it can be processed.

Examples

```
case.amex.requested?"Y":""
```

A condition formula with C# functions

```
case.practicePhone.StartsWith("02") || case.practicePhone.StartsWith("03") || case.practicePhone.StartsWith("07") || case.practicePhone.StartsWith("08")
```

Additonal inbuilt functions

| Function        | Description                                                                              |
| --------------- | ---------------------------------------------------------------------------------------- |
| Get()           | Returns the property value or null (wont blow up if the property value doesn't exist)    |
| GetNum()        | Returns the decimal value of the the data                                                |
| GetInt()        | Returns the integer value of the the data                                                |
| GetBool()       | Returns the boolean value of the the data                                                |
| HasValue()      | Returns true if the property has a value, or false if it is null or blank (empty String) |
| IsNull()        | Returns true of the property is null or doesnt have a value                              |
| IsNotNull()     | Opposite of IsNull()                                                                     |
| IsNullOrEmpty() | Returns true of the property is null, doesnt have a value or is an empty string (Blank)  |
| Count()         | Used to count how many items are in an array                                             |
| IsValid()       | Checks the validation rules in the schema, (still WIP)                                   |

### Formating the data

NB Any formating will cause the data to be converted to a string first. If you require objects as the output, don't use formating

| format Prefix            | Description                                                                        |
| ------------------------ | ---------------------------------------------------------------------------------- |
| LOOKUP                   | Returns the description for the value using the lookup defined in the schema (WIP) |
| LOOKUP:_[lookupname]_    | Returns the description for the value using a lookup                               |
| LOOKUPREV:_[lookupname]_ | Returns the value for the description using a lookup (Reverse lookup)              |
| contains dd or mm        | Returns the value formated as Date/Time                                            |
| TITLE                    | converts the data to title case                                                    |
| UPPER                    | converts the data to upper case                                                    |
| LOWER                    | converts the data to lower case                                                    |
| TEXT:_[format]_          | formats the data using the text format                                             |
| NUM:_[format]_           | formats the data using the number format, Eg #,##0.00                              |
| _[format]_               | automatic text or number formating                                                 |
| CALC:                    | a special format at the will use a calculation/formula instead                     |

Old formating
|format Prefix|Description|
|--|--|
|=VALUE|returns Y of the data matches the VALUE or it will return N|

Example

```
Format dd/mm/yyyy for a date

```

Complex Example, the source creates the data, in this example that was the file data, this is a special case where CALC was used to rename the file, not calculate the data

```
CALC:case.reference+"_"+case.abnInfo.abn+"_IC_"+(providers.profession.providerAllocatedBy=="Medicare"?providers.medicareProviderNumber:((Get("providers.profession.hicapsNumberSupport")=="Y" && Get("providers.issuedNumberType")=="Medibank") || (Get("providers.profession.hicapsNumberSupport")=="N" && Get("providers.profession.providerAllocatedBy").Contains("Medibank")))?providers.medibankProviderNumber:providers.issuedNumberType=="Yes"?providers.hicapsProviderNumber:"Request")+"_0"+providers._id+"_"+DateTime.Now.Date.ToString("yyyyMMdd")
```

### Default

A default value is used if the data is blank/empty

### Disable

Will disable processing of this item
