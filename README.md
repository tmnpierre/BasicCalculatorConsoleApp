# .NET Core Console Calculator Project Documentation

## Description
This project is a simple console calculator application developed in .NET Core. It performs basic arithmetic operations such as addition, subtraction, multiplication, and division. The project has been containerized for execution in a Docker environment.

## Features
- Perform basic arithmetic operations (addition, subtraction, multiplication, division).
- Handle calculations with floating-point numbers.
- Display a history of performed calculations.
- Provide user assistance with instructions on how to use the application.
- Operate in a Docker container for increased portability.

## Prerequisites
- .NET Core SDK (version corresponding to the development environment, e.g., .NET 6.0).
- Docker Desktop to build and run the application in a Docker container.

## Installation and Execution
1. **Clone the Project Repository**:
   - Clone the project to your local system using `git clone`.

2. **Build the Docker Image**:
   - Open a terminal at the project root.
   - Run `docker build -t basiccalculatorconsole .` to build the Docker image of the application.

3. **Run the Application in a Docker Container**:
   - Use the command `docker run --name mycalc -it basiccalculatorconsole` to start the application in a Docker container.

## Usage
- The application starts in console mode.
- Enter arithmetic operations to be performed following the format: [number] [operator] [number]. For example, `12 + 4`.
- Use `h` to display the calculation history.
- Type `help` for instructions on how to use the application.
- Enter `q` to quit the application.