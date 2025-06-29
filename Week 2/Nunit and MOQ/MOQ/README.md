# MOQ Testing Scenarios

This solution demonstrates two key MOQ testing scenarios for Test-Driven Development (TDD):

## Scenario 1: Mail Server Mocking

### Objective
Write unit tests for mail functionality without sending actual emails by mocking external dependencies.

### Projects
- **CustomerCommLib**: Class library containing mail sending functionality
- **CustomerComm.Tests**: Unit test project using NUnit and MOQ

### Key Concepts Demonstrated
- **Dependency Injection**: Constructor injection of `IMailSender` interface
- **Mocking**: Creating mock objects to isolate dependencies
- **Test Isolation**: Testing business logic without external dependencies

### Classes
- `IMailSender`: Interface for mail sending operations
- `MailSender`: Concrete implementation that would send actual emails
- `CustomerComm`: Business logic class that uses dependency injection

### Test Features
- Mock setup with `It.IsAny<string>()` for flexible parameter matching
- Verification of method calls with specific parameters
- Return value mocking to control test behavior

## Scenario 2: File System Mocking

### Objective
Write unit tests for file system operations without accessing the actual file system.

### Projects
- **MagicFilesLib**: Class library containing file system operations
- **DirectoryExplorer.Tests**: Unit test project using NUnit and MOQ

### Key Concepts Demonstrated
- **Abstraction**: Wrapping static `Directory.GetFiles()` in testable interface
- **Mocking Collections**: Returning mocked file collections
- **Test Data**: Using hardcoded test data for predictable results

### Classes
- `IDirectoryExplorer`: Interface for directory operations
- `DirectoryExplorer`: Concrete implementation using `System.IO.Directory`

### Test Features
- Collection assertions (not null, count, contains)
- Mock setup returning predefined file lists
- Verification of method invocations

## Running the Tests

```bash
# Build the solution
dotnet build MOQScenarios.sln

# Run all tests
dotnet test MOQScenarios.sln
```

## Test Results

✅ **All 5 tests pass successfully:**
- 3 DirectoryExplorer tests (File System Mocking)
- 2 CustomerComm tests (Mail Server Mocking)

## Key Learning Points

1. **Mocking Benefits**:
   - Faster test execution
   - Isolation from external dependencies
   - Predictable test results
   - No side effects

2. **Dependency Injection**:
   - Constructor injection for loose coupling
   - Interface-based design for testability
   - Separation of concerns

3. **Test Structure**:
   - Arrange-Act-Assert pattern
   - Setup and teardown with `[SetUp]`
   - Proper test isolation

4. **MOQ Features**:
   - `Mock<T>` for creating mock objects
   - `Setup()` for configuring behavior
   - `Verify()` for asserting interactions
   - `It.IsAny<T>()` for flexible matching

## Technologies Used
- .NET 9.0
- NUnit 3.13.3
- MOQ 4.18.4
- Visual Studio / VS Code
