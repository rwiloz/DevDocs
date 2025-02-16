---
title: GeoPoint and GeoExt Utility Classes
description: Documentation for the GeoPoint class and GeoExt static class in C# within the G3.Core.Utils.Geo namespace.
date: 2023-10-01
draft: false
---

# Overview

This documentation provides an overview of the `GeoPoint` class and the `GeoExt` static class used for geographical calculations. These utilities are part of the `G3.Core.Utils.Geo` namespace, offering functionalities such as coordinate representation and distance calculation.

## Namespace

`G3.Core.Utils.Geo`

## Classes

### GeoPoint Class

The `GeoPoint` class represents a geographical point using latitude and longitude coordinates.

#### Constructors

- `GeoPoint()`: Initializes a new instance of the `GeoPoint` class with latitude and longitude set to 0.
- `GeoPoint(double? lat, double? lng)`: Initializes a new instance of the `GeoPoint` class with specified latitude and longitude values. Default is 0 if null.
- `GeoPoint(decimal? lat, decimal? lng)`: Initializes a new instance of the `GeoPoint` class by converting decimal latitude and longitude to double. Default is 0 if null.

#### Properties

- `Lat`: Gets or sets the latitude of the geographical point. Type: `double`.
- `Lng`: Gets or sets the longitude of the geographical point. Type: `double`.

### GeoExt Static Class

The `GeoExt` static class provides additional methods for geographical calculations.

#### Methods

- `CalculateDistance(this GeoPoint point1, GeoPoint point2)`: Calculates the distance in meters between two geographical points using the Haversine formula.

  - **Parameters**
    - `point1`: The first geographical point. Type: `GeoPoint`.
    - `point2`: The second geographical point. Type: `GeoPoint`.
  
  - **Returns**
    - The distance in meters between `point1` and `point2`. Type: `int`.

  - **Example**

    ```csharp
    GeoPoint point1 = new GeoPoint(34.0522, -118.2437);
    GeoPoint point2 = new GeoPoint(40.7128, -74.0060);
    int distance = point1.CalculateDistance(point2);
    ```

  This method uses latitude and longitude to compute the distance on the Earth's surface, approximating the Earth as a sphere with a radius of 6,376,500 meters.

## Usage Example

```csharp
GeoPoint startPoint = new GeoPoint(52.52, 13.405);
GeoPoint endPoint = new GeoPoint(48.8566, 2.3522);
int distance = startPoint.CalculateDistance(endPoint);
Console.WriteLine($"Distance: {distance} meters");
```

This example demonstrates how to create two `GeoPoint` objects and calculate the distance between them using the `CalculateDistance` method.
```