<p align="center">
  <a href="https://github.com/kodlamaio-projects/nArchitecture/graphs/contributors"><img src="https://img.shields.io/github/contributors/kodlamaio-projects/nArchitecture.svg?style=for-the-badge"></a>
  <a href="https://github.com/kodlamaio-projects/nArchitecture/network/members"><img src="https://img.shields.io/github/forks/kodlamaio-projects/nArchitecture.svg?style=for-the-badge"></a>
  <a href="https://github.com/kodlamaio-projects/nArchitecture/stargazers"><img src="https://img.shields.io/github/stars/kodlamaio-projects/nArchitecture.svg?style=for-the-badge"></a>
  <a href="https://github.com/kodlamaio-projects/nArchitecture/issues"><img src="https://img.shields.io/github/issues/kodlamaio-projects/nArchitecture.svg?style=for-the-badge"></a>
  <a href="https://github.com/kodlamaio-projects/nArchitecture/blob/master/LICENSE"><img src="https://img.shields.io/github/license/kodlamaio-projects/nArchitecture.svg?style=for-the-badge"></a>
</p><br />

<p align="center">
  <a href="https://github.com/kodlamaio-projects/nArchitecture"><img src="https://user-images.githubusercontent.com/53148314/194872467-827dc967-acee-4bca-88a2-59ed5695bebf.png" height="125"></a>
  <h3 align="center"> CarRental Project with nArchitecture
</h3>
  <p align="center">
    <!-- PROJECT_DESCRIPTION -->
    <!-- <br />
    <a href="https://github.com/kodlamaio-projects/nArchitecture"><strong>Explore the docs »</strong></a>
    <br /> -->
    <!-- <br />
    <a href="https://github.com/kodlamaio-projects/nArchitecture">View Demo</a>
    · -->
    <a href="https://github.com/kodlamaio-projects/nArchitecture/issues">Report Bug</a>
    ·
    <a href="https://github.com/kodlamaio-projects/nArchitecture/discussions">Request Feature</a>
  </p>
</p>

## 💻 About The Project

Inspired by Clean Architecture, the CarRental Project is a monolith project showcasing advanced development techniques and is built with the nArchitecture project. The project includes Clean Architecture, CQRS, Advanced Repository, Dynamic Querying, JWT, OTP, Google & Microsoft Auth, Role-Based Management, Distributed Caching (Redis), Logging (Serilog), Elastic Search, [Code Generator](https://github.com/kodlamaio-projects/nArchitecture.Gen) and much more. 

### Built With

[![](https://img.shields.io/badge/.NET%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://learn.microsoft.com/tr-tr/dotnet/welcome)

## ⚙️ Getting Started

To get a local copy up and running follow these simple steps.

### Prerequisites

- .NET 8

### Installation

1. Clone the repo
   ```sh
   git clone --recurse-submodules https://github.com/atacanguzelkaya/CarRental.git
   ```
2. Configure `appsettings.json` in WebAPI.
3. Run `Update-Database` command with Package Manager Console in WebAPI to create tables in sql server.

- Run the following command to update submodules
  ```sh
   git submodule update --remote
   ```

## 🚀 Usage

1. Run example WebAPI project `dotnet run --project src\carRental\WebAPI`

### Analysis

1. If not, Install dotnet tool `dotnet tool restore`.
2. Run anaylsis command `dotnet roslynator analyze`

### Format

1. If not, Install dotnet tool `dotnet tool restore`.
2. Run format command `dotnet csharpier .`
