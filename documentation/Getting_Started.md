# Getting Started with MVC-Loan

Welcome to the MVC-Loan project! This guide will help you get up and running with the loan calculation application.

## 📋 Prerequisites

Before you begin, ensure you have the following installed on your development machine:

- **Visual Studio 2015** or later (Community, Professional, or Enterprise)
- **.NET Framework 4.5.2** or later
- **IIS Express** (usually included with Visual Studio)
- **SQL Server LocalDB** (optional, for future database features)
- **Git** for version control

## 🚀 Quick Start

### 1. Clone the Repository

```bash
git clone https://github.com/johnvbrennan/MVC-Loan.git
cd MVC-Loan
```

### 2. Open the Solution

1. Open Visual Studio
2. Navigate to `File > Open > Project/Solution`
3. Select the `MVC Loan.sln` file in the root directory

### 3. Restore NuGet Packages

Visual Studio should automatically restore NuGet packages when you open the solution. If not:

1. Right-click on the solution in Solution Explorer
2. Select "Restore NuGet Packages"

### 4. Build the Solution

1. Press `Ctrl+Shift+B` or go to `Build > Build Solution`
2. Ensure all projects build successfully without errors

### 5. Run the Application

1. Set `Contoso.Loan.Mvc` as the startup project (right-click > Set as StartUp Project)
2. Press `F5` or click the "Start" button
3. The application will launch in your default browser

## 🏗️ Project Structure

The solution consists of several projects organized by responsibility:

```
MVC-Loan/
├── Contoso.Loan.Domain/          # Core business logic and domain models
├── Contoso.Loan.Services/        # Application services
├── Contoso.Loan.MvcServices/     # Web-specific services and view models
├── Contoso.Loan.Mvc/             # Web application (Controllers, Views)
├── Contoso.Loan.Contracts/       # Shared contracts and interfaces
├── Contoso.Loan.Web.Tests/       # Web layer tests
├── Contoso.Loan.UnitTests/       # Business logic unit tests
└── packages/                     # NuGet packages
```

## 🎯 Key Features

- **Loan Calculation**: Calculate monthly payments for home loans
- **Payment Schedule**: Generate complete amortization schedules
- **Extensible Design**: Easy to add new loan types and payment strategies
- **Responsive UI**: Bootstrap-based interface with jQuery enhancements
- **Validation**: Client-side and server-side input validation

## 🔧 Development Workflow

### Making Changes

1. **Create a Feature Branch**
   ```bash
   git checkout -b feature/your-feature-name
   ```

2. **Make Your Changes**
   - Follow the existing code patterns and conventions
   - Add unit tests for new functionality
   - Update documentation as needed

3. **Test Your Changes**
   - Run the application locally
   - Execute unit tests
   - Test different loan scenarios

4. **Commit and Push**
   ```bash
   git add .
   git commit -m "Add your descriptive commit message"
   git push origin feature/your-feature-name
   ```

### Running Tests

#### Unit Tests
1. Open Test Explorer (`Test > Test Explorer`)
2. Click "Run All" to execute all unit tests
3. Review results and fix any failing tests

#### Manual Testing
1. Start the application (`F5`)
2. Navigate to the loan calculator
3. Test various scenarios:
   - Valid loan amounts and terms
   - Invalid inputs (negative amounts, etc.)
   - Edge cases (zero interest rate)

## 🏛️ Architecture Overview

### Design Patterns Used

- **MVC Pattern**: Separation of concerns between Model, View, and Controller
- **Strategy Pattern**: `IRepaymentStrategy` for different calculation methods
- **Template Method**: `BankLoanBase` provides framework for loan types
- **Dependency Injection**: Autofac container for loose coupling

### Data Flow

```
User Input → Controller → MvcService → Service → Domain Model → Strategy → Response
```

### Key Components

- **BankLoanBase**: Abstract base class for all loan types
- **HomeLoan**: Concrete implementation for home loans
- **MonthlyRepaymentStrategy**: Calculates monthly payments using amortization
- **LoanController**: Handles web requests and responses
- **HomeLoanService**: Orchestrates loan creation and calculation

## 📝 Adding New Features

### Adding a New Loan Type

1. **Create Domain Model**
   ```csharp
   public class CarLoan : BankLoanBase
   {
       // Implement abstract methods
       // Add car-specific properties and validation
   }
   ```

2. **Create Repayment Strategy** (if needed)
   ```csharp
   public class CarLoanRepaymentStrategy : IRepaymentStrategy
   {
       // Implement calculation logic
   }
   ```

3. **Add Service Layer Support**
   - Update services to handle new loan type
   - Create appropriate view models

4. **Update UI**
   - Add new controller actions
   - Create views for the new loan type

### Adding a New Payment Strategy

1. **Implement Interface**
   ```csharp
   public class WeeklyRepaymentStrategy : IRepaymentStrategy
   {
       public decimal GetRepaymentsFor(decimal principal, decimal interestRate, int term)
       {
           // Weekly calculation logic
       }
       
       public IEnumerable<IPayment> GetRepaymentSchedule(DateTime firstPaymentDate, decimal principal, decimal interestRatePercentage, int term)
       {
           // Weekly schedule generation
       }
   }
   ```

2. **Update Loan Classes**
   - Modify loan classes to use new strategy when appropriate

## 🐛 Troubleshooting

### Common Issues

**Build Errors**
- Ensure all NuGet packages are restored
- Check that .NET Framework 4.5.2 is installed
- Verify Visual Studio version compatibility

**Runtime Errors**
- Check IIS Express is running
- Verify all dependencies are properly injected
- Review application logs for detailed error information

**JavaScript Errors**
- Ensure jQuery and jQuery UI libraries are loaded
- Check browser console for specific errors
- Verify script references in layout files

### Getting Help

1. **Check Documentation**: Review this guide and code comments
2. **Run Tests**: Execute unit tests to identify issues
3. **Debug**: Use Visual Studio debugger to step through code
4. **Ask Questions**: Reach out to team members for assistance

## 📚 Additional Resources

- [ASP.NET MVC Documentation](https://docs.microsoft.com/en-us/aspnet/mvc/)
- [Autofac Documentation](https://autofac.readthedocs.io/)
- [Bootstrap Documentation](https://getbootstrap.com/docs/)
- [jQuery Documentation](https://api.jquery.com/)

## 🔄 Next Steps

After getting the application running:

1. **Explore the Code**: Browse through the different projects and understand the architecture
2. **Run Sample Calculations**: Test the loan calculator with various inputs
3. **Review Tests**: Examine unit tests to understand expected behavior
4. **Read Architecture Documentation**: Review the detailed architecture explanation
5. **Start Contributing**: Pick up a small task or bug fix to get familiar with the codebase

Happy coding! 🎉
