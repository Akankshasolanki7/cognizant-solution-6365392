# Lab 1: Understanding ORM with a Retail Inventory System

## 📋 Scenario
You're building an inventory management system for a retail store. The store wants to track products, categories, and stock levels in a SQL Server database.

## 🎯 Objective
Understand what ORM is and how EF Core helps bridge the gap between C# objects and relational tables.

## 📚 Theory

### 1. What is ORM?
- **Object-Relational Mapping (ORM)** maps C# classes to database tables
- **Benefits**: 
  - Productivity: Write C# code instead of SQL
  - Maintainability: Type-safe queries
  - Abstraction: Hide database complexity

### 2. EF Core vs EF Framework
| Feature | EF Core | EF Framework (EF6) |
|---------|---------|-------------------|
| Platform | Cross-platform | Windows-only |
| Performance | Lightweight, faster | More mature but heavier |
| Features | Modern (LINQ, async, compiled queries) | Traditional |
| Support | Active development | Maintenance mode |

### 3. EF Core 8.0 Features
- ✅ **JSON column mapping**
- ✅ **Improved performance** with compiled models
- ✅ **Interceptors** and better bulk operations
- ✅ **Complex types** support
- ✅ **Raw SQL** improvements

## 🛠️ Setup Steps

### Step 1: Create Console App
```bash
dotnet new console -n RetailInventory
cd RetailInventory
```

### Step 2: Install EF Core Packages
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
```

## 🏗️ Basic Concepts

### C# Class → Database Table Mapping
```csharp
// C# Class
public class Product 
{
    public int Id { get; set; }        // → Primary Key
    public string Name { get; set; }   // → nvarchar column
    public decimal Price { get; set; } // → decimal column
}

// Maps to SQL Table:
// CREATE TABLE Products (
//     Id int IDENTITY(1,1) PRIMARY KEY,
//     Name nvarchar(max) NOT NULL,
//     Price decimal(18,2) NOT NULL
// )
```

### ORM Benefits Example
```csharp
// Without ORM (Raw SQL)
string sql = "SELECT * FROM Products WHERE Price > @price";
var command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@price", 1000);
// ... complex data reader code

// With EF Core ORM
var products = await context.Products
    .Where(p => p.Price > 1000)
    .ToListAsync();
```

