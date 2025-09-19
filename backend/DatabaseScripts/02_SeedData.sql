-- Royal Library Seed Data Script
-- This script inserts sample data into the books table

-- Clear existing data (optional - uncomment if needed)
-- DELETE FROM books;

-- Insert sample books with publishers and ownership status
INSERT INTO books (title, first_name, last_name, total_copies, copies_in_use, type, isbn, category, publisher, ownership_status)
VALUES 
('Pride and Prejudice', 'Jane', 'Austen', 100, 80, 'Hardcover', '1234567891', 'Fiction', 'Penguin Classics', 'own'),
('To Kill a Mockingbird', 'Harper', 'Lee', 75, 65, 'Paperback', '1234567892', 'Fiction', 'HarperCollins', 'love'),
('The Catcher in the Rye', 'J.D.', 'Salinger', 50, 45, 'Hardcover', '1234567893', 'Fiction', 'Little, Brown and Company', 'own'),
('The Great Gatsby', 'F. Scott', 'Fitzgerald', 50, 22, 'Hardcover', '1234567894', 'Non-Fiction', 'Scribner', 'want to read'),
('The Alchemist', 'Paulo', 'Coelho', 50, 35, 'Hardcover', '1234567895', 'Biography', 'HarperOne', 'own'),
('The Book Thief', 'Markus', 'Zusak', 75, 11, 'Hardcover', '1234567896', 'Mystery', 'Knopf', 'love'),
('The Chronicles of Narnia', 'C.S.', 'Lewis', 100, 14, 'Paperback', '1234567897', 'Sci-Fi', 'HarperCollins', 'own'),
('The Da Vinci Code', 'Dan', 'Brown', 50, 40, 'Paperback', '1234567898', 'Sci-Fi', 'Doubleday', 'want to read'),
('The Grapes of Wrath', 'John', 'Steinbeck', 50, 35, 'Hardcover', '1234567899', 'Fiction', 'Viking Press', 'own'),
('The Hitchhiker''s Guide to the Galaxy', 'Douglas', 'Adams', 50, 35, 'Paperback', '1234567900', 'Non-Fiction', 'Pan Books', 'love'),
('Moby-Dick', 'Herman', 'Melville', 30, 8, 'Hardcover', '8901234567', 'Fiction', 'Harper & Brothers', 'want to read'),
('To Kill a Mockingbird', 'Harper', 'Lee', 20, 0, 'Paperback', '9012345678', 'Non-Fiction', 'J.B. Lippincott & Co.', 'own'),
('The Catcher in the Rye', 'J.D.', 'Salinger', 10, 1, 'Hardcover', '0123456789', 'Non-Fiction', 'Little, Brown and Company', 'love');
