# CQRSWithMediatR

A sample project demonstrating the implementation of Command Query Responsibility Segregation (CQRS) with MediatR in .NET.

## Overview

This repository showcases the use of MediatR library to implement CQRS architecture in a .NET application. Command Query Responsibility Segregation is a design pattern that separates the read and write operations of a system, providing a scalable and maintainable solution.

## Features

- **CQRS Implementation**: Explore a clean and structured implementation of CQRS using the MediatR library.
- **Command Handling**: Learn how to handle commands to update the application state.
- **Query Handling**: Understand how queries are handled to retrieve data without affecting the write side.
- **MediatR Integration**: See how MediatR is integrated to simplify the handling of requests and notifications.

## Prerequisites

Ensure you have the following tools installed:

- [.NET SDK 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) (optional, but recommended)

## Getting Started

1. Clone the repository.
2. Open the solution in your preferred IDE.
3. Run the following commands in the terminal or command prompt:

    ```bash
    dotnet restore
    dotnet ef database update
    ```

    This will apply any pending database migrations.

4. Explore the different components in the project, including commands, queries, and handlers.
5. Run the application and see the CQRS pattern in action.

## Technologies

- .Net 8
- EF-Core 
- MediatR
- Web API

