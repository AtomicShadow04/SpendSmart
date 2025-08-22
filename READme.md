# SpendSmart 💰

A simple and intuitive expense tracking application built with ASP.NET Core MVC and Entity Framework Core.

## Features

- ✅ Add new expenses with description and amount
- ✅ View all expenses in a table format
- ✅ Edit existing expenses
- ✅ Delete expenses
- ✅ Calculate and display total expenses
- ✅ Automatic date tracking for expenses
- ✅ Clean and responsive Bootstrap UI

## Tech Stack

- **Framework:** ASP.NET Core MVC (.NET 9.0)
- **Database:** SQLite with Entity Framework Core
- **Frontend:** Bootstrap 5, HTML, CSS
- **ORM:** Entity Framework Core 9.0.8

## Project Structure

```
SpendSmart/
├── Controllers/
│   └── HomeController.cs          # Main application controller
├── Models/
│   ├── Expense.cs                 # Expense entity model
│   ├── SpendSmartDbContext.cs     # Database context
│   └── ErrorViewModel.cs          # Error handling model
├── Views/
│   ├── Home/
│   │   ├── Index.cshtml           # Home page
│   │   ├── Expenses.cshtml        # Expenses list view
│   │   └── CreateEditExpense.cshtml # Add/Edit expense form
│   └── Shared/
│       ├── _Layout.cshtml         # Main layout template
│       └── Error.cshtml           # Error page
├── Migrations/                    # EF Core database migrations
└── Program.cs                     # Application startup
```

## Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later
- Any code editor (Visual Studio, Visual Studio Code, etc.)

### Installation

1. **Clone or download the project**

   ```bash
   git clone <repository-url>
   cd SpendSmart
   ```

2. **Restore dependencies**

   ```bash
   dotnet restore
   ```

3. **Update the database**

   ```bash
   dotnet ef database update
   ```

   _Note: The SQLite database will be created automatically based on the connection string in `appsettings.json`_

4. **Run the application**

   ```bash
   dotnet run
   ```

5. **Open your browser**
   Navigate to `https://localhost:5001` or `http://localhost:5000`

### Database Configuration

The application uses SQLite by default. The connection string is configured in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "SpendSmart": "Data Source=spendsmart.db"
  }
}
```

## Usage

### Adding an Expense

1. Click "Create/Edit Expense" from the home page
2. Enter a description and amount
3. Click "Create Expense"
4. The current date will be automatically assigned

### Viewing Expenses

1. Click "Overview" from the home page
2. View all expenses in a table format
3. See the total expenses at the top

### Editing an Expense

1. From the expenses list, click "Edit" next to any expense
2. Modify the description and/or amount
3. Click "Create Expense" to save changes
4. _Note: The original date is preserved when editing_

### Deleting an Expense

1. From the expenses list, click "Delete" next to any expense
2. The expense will be removed immediately

## Database Schema

### Expenses Table

| Column      | Type     | Description                    |
| ----------- | -------- | ------------------------------ |
| Id          | INTEGER  | Primary key, auto-increment    |
| Description | TEXT     | Expense description (required) |
| Amount      | DECIMAL  | Expense amount                 |
| Date        | DATETIME | Date when expense was created  |

## API Endpoints

| Method | Route                          | Description              |
| ------ | ------------------------------ | ------------------------ |
| GET    | `/`                            | Home page                |
| GET    | `/Home/Expenses`               | View all expenses        |
| GET    | `/Home/CreateEditExpense`      | New expense form         |
| GET    | `/Home/CreateEditExpense/{id}` | Edit expense form        |
| POST   | `/Home/SubmitForm`             | Create or update expense |
| GET    | `/Home/DeleteExpense/{id}`     | Delete expense           |

## Development

### Adding Migrations

When you modify the database models, create a new migration:

```bash
dotnet ef migrations add MigrationName
dotnet ef database update
```

### Running in Development Mode

```bash
dotnet run --environment Development
```

## Contributing

1. Fork the project
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## Future Enhancements

- 📊 Add expense categories
- 📈 Include charts and analytics
- 📱 Improve mobile responsiveness
- 🔐 Add user authentication
- 📅 Add date range filtering
- 💾 Export expenses to CSV/PDF
- 🏷️ Add expense tags/labels
- 🔍 Implement search functionality

## License

This project is open source and available under the [MIT License](LICENSE).

## Support

If you encounter any issues or have questions, please create an issue in the project repository.

---

**Happy expense tracking! 🎯**
