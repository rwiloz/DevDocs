---
title: "CeoPoint Utils"
description: ""
summary: ""
date: 2023-09-07T16:12:37+02:00
lastmod: 2023-09-07T16:12:37+02:00
draft: false
weight: 900
toc: true
sidebar:
  collapsed: true
seo:
  title: "" # custom title (optional)
  description: "" # custom description (recommended)
  canonical: "" # custom canonical URL (optional)
  robots: "" # custom robot tags (optional)
---

# Class: GeoPoint

The `GeoPoint` class represents a geographical position on a map, defined by its latitude(`Lat`) and longitude(`Lng`). This class is part of the `G3.Core.Utils.Geo` namespace.

## Properties
- **Lat** (double): Represents the latitude of the GeoPoint. 
- **Lng** (double): Represents the longitude of the GeoPoint.

## Constructors
- **GeoPoint()**: The default constructor. Initializes a new instance of `GeoPoint` with both latitude and longitude set to 0.
- **GeoPoint(double? lat, double? lng)**: Initializes a new instance of `GeoPoint` using provided latitude and longitude values. If null values are passed, they're replaced with 0.
- **GeoPoint(decimal? lat, decimal? lng)**: Initializes a new instance of `GeoPoint` using provided latitude and longitude values (decimal type), which are then casted to double. If null values are passed, they're replaced with 0.

# Class: GeoExt

`GeoExt` is a static class that provides utility extension methods for the `GeoPoint` class. 

## Methods
- **CalculateDistance(this GeoPoint point1, GeoPoint point2)**: This is an extension method of the `GeoPoint` class. It calculates and returns the distance in metres between two geographical points (`point1` and `point2`), represented by `GeoPoint` instances. This method uses the 'Haversine' formula to calculate the shortest distance between two points on the surface of a sphere, which provides an accurate distance between these points when considering the Earth's curvature. The distance is returned as an integer.