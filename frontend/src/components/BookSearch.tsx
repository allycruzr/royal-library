import React, { useState } from 'react';
import { Book, BookSearchParams } from '../types/Book';
import { BookService } from '../services/BookService';

const BookSearch: React.FC = () => {
  const [searchParams, setSearchParams] = useState<BookSearchParams>({
    page: 1,
    pageSize: 10
  });
  const [books, setBooks] = useState<Book[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [total, setTotal] = useState(0);

  const handleSearch = async () => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await BookService.searchBooks(searchParams);
      setBooks(result.items);
      setTotal(result.total);
    } catch (err) {
      setError('Error searching for books. Please check if the API is running.');
      console.error('Error:', err);
    } finally {
      setLoading(false);
    }
  };

  const handleInputChange = (field: keyof BookSearchParams, value: string | number) => {
    setSearchParams(prev => ({
      ...prev,
      [field]: value
    }));
  };

  return (
    <div style={{ padding: '20px', maxWidth: '1200px', margin: '0 auto' }}>
      <h1>Royal Library - Book Search</h1>
      
      {/* Search Form */}
      <div style={{ 
        display: 'grid', 
        gridTemplateColumns: 'repeat(auto-fit, minmax(200px, 1fr))', 
        gap: '10px', 
        marginBottom: '20px',
        padding: '20px',
        border: '1px solid #ddd',
        borderRadius: '8px',
        backgroundColor: '#f9f9f9'
      }}>
        <div>
          <label>Author:</label>
          <input
            type="text"
            value={searchParams.author || ''}
            onChange={(e) => handleInputChange('author', e.target.value)}
            placeholder="Enter author name"
            style={{ width: '100%', padding: '8px', marginTop: '4px' }}
          />
        </div>
        
        <div>
          <label>ISBN:</label>
          <input
            type="text"
            value={searchParams.isbn || ''}
            onChange={(e) => handleInputChange('isbn', e.target.value)}
            placeholder="Enter ISBN"
            style={{ width: '100%', padding: '8px', marginTop: '4px' }}
          />
        </div>
        
        <div>
          <label>Status:</label>
          <select
            value={searchParams.status || ''}
            onChange={(e) => handleInputChange('status', e.target.value)}
            style={{ width: '100%', padding: '8px', marginTop: '4px' }}
          >
            <option value="">All</option>
            <option value="own">Own</option>
            <option value="love">Love</option>
            <option value="want to read">Want to read</option>
          </select>
        </div>
        
        <div>
          <label>Page:</label>
          <input
            type="number"
            value={searchParams.page || 1}
            onChange={(e) => handleInputChange('page', parseInt(e.target.value) || 1)}
            min="1"
            style={{ width: '100%', padding: '8px', marginTop: '4px' }}
          />
        </div>
        
        <div>
          <label>Items per page:</label>
          <input
            type="number"
            value={searchParams.pageSize || 10}
            onChange={(e) => handleInputChange('pageSize', parseInt(e.target.value) || 10)}
            min="1"
            max="100"
            style={{ width: '100%', padding: '8px', marginTop: '4px' }}
          />
        </div>
        
        <div style={{ display: 'flex', alignItems: 'end' }}>
          <button
            onClick={handleSearch}
            disabled={loading}
            style={{
              padding: '10px 20px',
              backgroundColor: '#007bff',
              color: 'white',
              border: 'none',
              borderRadius: '4px',
              cursor: loading ? 'not-allowed' : 'pointer',
              width: '100%'
            }}
          >
            {loading ? 'Searching...' : 'Search Books'}
          </button>
        </div>
      </div>

      {/* Results */}
      {error && (
        <div style={{ 
          padding: '10px', 
          backgroundColor: '#f8d7da', 
          color: '#721c24', 
          border: '1px solid #f5c6cb',
          borderRadius: '4px',
          marginBottom: '20px'
        }}>
          {error}
        </div>
      )}

      {books.length > 0 && (
        <div>
          <h3>Results ({total} books found)</h3>
          <div style={{ 
            display: 'grid', 
            gridTemplateColumns: 'repeat(auto-fill, minmax(300px, 1fr))', 
            gap: '15px' 
          }}>
            {books.map((book) => (
              <div
                key={book.id}
                style={{
                  border: '1px solid #ddd',
                  borderRadius: '8px',
                  padding: '15px',
                  backgroundColor: 'white',
                  boxShadow: '0 2px 4px rgba(0,0,0,0.1)'
                }}
              >
                <h4 style={{ margin: '0 0 10px 0', color: '#333' }}>{book.title}</h4>
                <p style={{ margin: '5px 0', color: '#666' }}><strong>Author:</strong> {book.authors}</p>
                {book.publisher && <p style={{ margin: '5px 0', color: '#666' }}><strong>Publisher:</strong> {book.publisher}</p>}
                {book.isbn && <p style={{ margin: '5px 0', color: '#666' }}><strong>ISBN:</strong> {book.isbn}</p>}
                {book.category && <p style={{ margin: '5px 0', color: '#666' }}><strong>Category:</strong> {book.category}</p>}
                {book.type && <p style={{ margin: '5px 0', color: '#666' }}><strong>Type:</strong> {book.type}</p>}
                <p style={{ margin: '5px 0', color: '#666' }}><strong>Available:</strong> {book.availableCopies}</p>
              </div>
            ))}
          </div>
        </div>
      )}
    </div>
  );
};

export default BookSearch;
