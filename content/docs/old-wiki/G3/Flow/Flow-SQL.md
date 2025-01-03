# Flow SQL

Flow SQL is a simplied way or querying flow case data. It's similar to normal SQL but with a few differences

```
select [page|pagesize] complexProperty, complexProperty [as transformedProperty]
from caseType
where [expressions]
order by complexProperties
```

"as" can be used to transpost the data to a diffrent output structure

Array's support needs to be added
Soem format types havent been tested yet (dates etc)
Support for encrypted data (see Flow Encryption)

## Select
Optional page number and page size.

```
select 2|10
```

### Properties

Property names are camel case and are **case sensative**

Examples
- status
- address.streetName 
- firstName
- primaryContact.dateOfBirth

```
select 2|10 firstName, surname, address
```

### ComplexProperties
address (objects will return all properties as columns, like SQL * but for this object)

## From
Flow CaseType, odn't puralise this

```
from signUp
```

## Where
This is a list of expressions that must match (like a list of AND clause)

Operators are:
- =
- &lt;
- &gt;
- &lt;=
- &gt;=
- &lt;&gt;
- IN 
- LIKE

Logic 
- and 
- or
- not

IN expects a list of possible matches with square brakets, example 
```
where date > '2023-07-01' and status in ['new', 'pending', 'canceled']
```

## Order by

comma seperated properties (NB Your can't order by encrypted data)

```
order by signUpDate, address.postcode, surname
```





