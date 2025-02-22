# WPF Inventory Management Application

## Overview
This project is a WPF-based desktop application for inventory management, designed as part of the Senior Developer (.NET Focus) technical assessment. The application allows users to manage inventory items efficiently with key functionalities such as listing, editing, adding new items, searching, and filtering inventory data.

## Features
1. **Inventory Listing**: Displays a list of items with columns for name, category, stock quantity, and last updated date.
2. **Detailed View**: Allows users to view and edit inventory item details.
3. **New Item Form**: Enables users to add new inventory items with validation rules (e.g., required name, non-negative stock quantity).
4. **Local Database Persistence**: Uses Entity Framework Core for storing inventory data.
5. **Search & Filter**: Supports searching by item name and filtering by stock status (e.g., low stock, in stock).

## Architecture & Design
### MVVM Pattern
The application follows the Model-View-ViewModel (MVVM) pattern to ensure a clear separation of concerns:
- **Model**: Represents the inventory data and business logic.
- **View**: The UI elements (XAML) that display data and capture user inputs.
- **ViewModel**: Serves as the intermediary between the Model and View, handling commands and data binding.

### Technologies Used
- **.NET 6.0** (or latest available version) for the WPF application.
- **Entity Framework Core** for database interactions.
- **SQLite** as the local database for persistence.
- **XAML** for UI design and data binding.
- **MSTest/xUnit** for unit testing the ViewModel layer.
- **MVVM Toolkit** (Community Toolkit.Mvvm) to facilitate ViewModel development.

## Implementation Details
- **Commands & Events**: Implemented via `RelayCommand` for better separation of logic.
- **Dependency Injection**: Used for managing database context and services.
- **Data Validation**: Enforced through `IDataErrorInfo` to ensure valid user inputs.
- **Async/Await**: Applied in database operations to enhance performance.
- **Unit Testing**: At least two unit tests verify ViewModel logic.

## Installation & Setup
1. Clone the repository:
   ```sh
   git clone <repository_url>
   ```
2. Open the solution in Visual Studio.
3. Build the project and restore NuGet dependencies.
4. Run the application.

## Testing
Unit tests are located in the `Tests` project within the solution. Run them using the built-in test runner in Visual Studio or via the command line:
   ```sh
   dotnet test
   ```



## Questions?
If you have any questions regarding the task, feel free to reach out.

---


