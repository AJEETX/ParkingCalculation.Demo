## Parking Calculation Demo ![GitHub release](https://img.shields.io/github/release/ajeetx/ParkingCalculation.Demo.svg?style=for-the-badge) ![Maintenance](https://img.shields.io/maintenance/yes/2018.svg?style=for-the-badge)

| ![GitHub Release Date](https://img.shields.io/github/release-date/ajeetx/ParkingCalculation.Demo.svg?style=plastic) | ![Website](https://img.shields.io/website-stable-offline-green-red/http/ajeetx.github.io/ParkingCalculation.Demo.svg?label=status&style=plastic)|[![Build Status](https://travis-ci.org/AJEETX/ParkingCalculation.Demo.png?branch=master&style=for-the-badge)](https://travis-ci.org/AJEETX/ParkingCalculation.Demo)
|  --- | ---     | ---   |

 [![.Net Framework](https://img.shields.io/badge/DotNet-4.5.2-blue.svg?style=plastic)](https://www.microsoft.com/en-au/download/details.aspx?id=42642) | ![GitHub language count](https://img.shields.io/github/languages/count/ajeetx/ParkingCalculation.Demo.svg?style=plastic)| ![GitHub top language](https://img.shields.io/github/languages/top/ajeetx/ParkingCalculation.Demo.svg) |![GitHub repo size in bytes](https://img.shields.io/github/repo-size/ajeetx/ParkingCalculation.Demo.svg) 
| ---          | ---        | ---      | ---       |

## Purpose of statement
```
The project features: 
 (a) a console application to enter time-in and time-out
 (b) Class Library with business logic 
 (c) Unit Test project
```

> Application calculates parking charge based on entry-exit times and the rates below

| Type | Entry Timings | Exit-Timings|Duration[hr] | Rate($) |
| ---  | ---           | ---          | ---  | --- |
| EarlyBird | 06:00-09:30 | 15:30-23:30 | as per entry timing| 13:50 |
| Night | 18:00-23:59 | 00:00-06:30 |as per entry timing| 6:50 |
| Weekend | 00:00-23:59 | 00:00-23:59 |as per entry timing| 10:00 / day | 
| Standard | anytime| anytime |0 - 1 |5:00 |
| Standard | anytime| anytime | 1 - 2 | 10:00 |
| Standard | anytime| anytime| 2 - 3 | 15:00 |
| Standard | anytime| anytime| 3 - 24 | 20:00 |
| Standard | anytime| anytime| 24+ | 20.00 / day |

#### Application list and details

| App Name| Project Type | Comments|
| --- | --- | --- |
| ParkingCalculation.Engine| Class Library |Business logic using Chain-of-responsibility design pattern |
| ParkingCalculation.Engine.Test | Test  |unit tests|
| ParkingCalculation.Engine.Demot | Console  | Run as startup project |

### Support or Contact

Having any trouble? Check out our [documentation](https://github.com/AJEETX/ParkingCalculation.Demo/blob/master/README.md) or [contact support](mailto:ajeetkumar@email.com) and we’ll help you sort it out.

|  Counter   | Contributor | Disclaimer
| ---        | ---         | --- |
|[ ![HitCount](http://hits.dwyl.io/ajeetx/ParkingCalculation.Demo/projects/1.svg)](http://hits.dwyl.io/ajeetx/ParkingCalculation.Demo/projects/1) | ![GitHub contributors](https://img.shields.io/github/contributors/ajeetx/ParkingCalculation.Demo.svg?style=plastic)|![license](https://img.shields.io/github/license/ajeetx/ParkingCalculation.Demo.svg?style=plastic)
