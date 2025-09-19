# Royal Library Database Scripts

This folder contains SQL scripts for creating and populating the Royal Library database.

## Scripts

### 01_CreateDatabase.sql
Creates the `books` table with all required columns:
- `book_id` (Primary Key, Auto Increment)
- `title` (Required)
- `first_name` (Required)
- `last_name` (Required)
- `total_copies` (Default: 0)
- `copies_in_use` (Default: 0)
- `type` (Nullable)
- `isbn` (Nullable)
- `category` (Nullable)
- `publisher` (Nullable)
- `ownership_status` (Nullable)

Also creates indexes for better query performance.

### 02_SeedData.sql
Inserts sample data with 13 books including:
- Realistic publishers
- Ownership status values: "own", "love", "want to read"
- Various book types and categories

## Usage

1. **For SQLite (Recommended):**
   ```bash
   sqlite3 library.db < 01_CreateDatabase.sql
   sqlite3 library.db < 02_SeedData.sql
   ```

2. **For SQL Server:**
   - Remove `AUTOINCREMENT` and use `IDENTITY(1,1)`
   - Adjust data types as needed

3. **For PostgreSQL:**
   - Change `INTEGER PRIMARY KEY AUTOINCREMENT` to `SERIAL PRIMARY KEY`
   - Adjust data types as needed

## Ownership Status Values
- `own` - Books you own
- `love` - Books you love
- `want to read` - Books you want to read

## Notes
- The API uses Entity Framework migrations, so these scripts are for reference
- The actual database is created automatically when running the API
- These scripts match the exact structure used by the .NET application
