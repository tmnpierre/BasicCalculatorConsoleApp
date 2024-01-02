# .NET Core Console Calculator Project Documentation

## Description
This project is a simple console calculator application developed in .NET Core. It performs basic arithmetic operations such as addition, subtraction, multiplication, division, exponentiation, square root, and logarithm calculations. The project has been containerized for execution in a Docker environment and features an enhanced user interface with interactive menus.

## Features
- Perform a wide range of arithmetic operations including addition, subtraction, multiplication, division, exponentiation (power), square root, and logarithm.
- Handle calculations with floating-point numbers.
- Display a history of performed calculations in a dedicated sub-menu.
- Provide user assistance with a dedicated help sub-menu, offering detailed instructions on how to use the application.
- Interactive user interface with main menu and sub-menus for better user experience.
- Operate in a Docker container for increased portability and ease of deployment.

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
- The application starts in console mode with an interactive main menu.
- Select options from the main menu to perform calculations, view history, get help, or quit the application.
- In the calculation sub-menu, enter arithmetic operations following the format: [number] [operator] [number]. For advanced operations like square root and logarithm, follow the on-screen instructions.
- Access the history sub-menu to view past calculations.
- Use the help sub-menu for detailed instructions on how to perform various operations.
- Navigate back to the main menu from any sub-menu by entering 'back'.
- Enter 'q' in the main menu to quit the application.