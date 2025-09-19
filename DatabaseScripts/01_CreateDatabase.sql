-- Royal Library Database Creation Script
-- This script creates the books table with all required columns

CREATE TABLE IF NOT EXISTS books (
    book_id INTEGER PRIMARY KEY AUTOINCREMENT,
    title TEXT NOT NULL,
    first_name TEXT NOT NULL,
    last_name TEXT NOT NULL,
    total_copies INTEGER NOT NULL DEFAULT 0,
    copies_in_use INTEGER NOT NULL DEFAULT 0,
    type TEXT NULL,
    isbn TEXT NULL,
    category TEXT NULL,
    publisher TEXT NULL,
    ownership_status TEXT NULL
);

-- Create indexes for better performance
CREATE INDEX IF NOT EXISTS idx_books_author ON books(first_name, last_name);
CREATE INDEX IF NOT EXISTS idx_books_isbn ON books(isbn);
CREATE INDEX IF NOT EXISTS idx_books_ownership_status ON books(ownership_status);
CREATE INDEX IF NOT EXISTS idx_books_category ON books(category);
