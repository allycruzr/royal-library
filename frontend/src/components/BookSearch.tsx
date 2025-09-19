import React, { useState, useEffect } from 'react';
import { Book, BookSearchParams } from '../types/Book';
import { BookService } from '../services/BookService';
import './BookSearch.css';

const BookSearch: React.FC = () => {
  const [searchParams, setSearchParams] = useState<BookSearchParams>({
    page: 1,
    pageSize: 10
  });
  const [books, setBooks] = useState<Book[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [total, setTotal] = useState(0);
  const [hasSearched, setHasSearched] = useState(false);

  // Auto-search on component mount
  useEffect(() => {
    handleSearch();
  }, []);

  const handleSearch = async () => {
    setLoading(true);
    setError(null);
    setHasSearched(true);
    
    try {
      const result = await BookService.searchBooks(searchParams);
      setBooks(result.items);
      setTotal(result.total);
    } catch (err) {
      setError('Unable to connect to the API. Please ensure the backend is running on http://localhost:5000');
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

  const getStatusBadge = (status: string) => {
    const statusMap: { [key: string]: { class: string; label: string } } = {
      'own': { class: 'status-own', label: 'Owned' },
      'love': { class: 'status-love', label: 'Loved' },
      'want to read': { class: 'status-want', label: 'Want to Read' }
    };
    return statusMap[status] || { class: '', label: status };
  };

  const handleKeyPress = (e: React.KeyboardEvent) => {
    if (e.key === 'Enter') {
      handleSearch();
    }
  };

  return (
    <div className="container">
      <div className="header">
        <h1>Royal Library</h1>
        <p>Discover and manage your personal book collection</p>
      </div>
      
      <div className="search-container">
        <div className="search-form">
          <div className="form-group">
            <label htmlFor="author">Author</label>
            <input
              id="author"
              type="text"
              className="form-input"
              value={searchParams.author || ''}
              onChange={(e) => handleInputChange('author', e.target.value)}
              onKeyPress={handleKeyPress}
              placeholder="Enter author name"
            />
          </div>
          
          <div className="form-group">
            <label htmlFor="isbn">ISBN</label>
            <input
              id="isbn"
              type="text"
              className="form-input"
              value={searchParams.isbn || ''}
              onChange={(e) => handleInputChange('isbn', e.target.value)}
              onKeyPress={handleKeyPress}
              placeholder="Enter ISBN"
            />
          </div>
          
          <div className="form-group">
            <label htmlFor="status">Status</label>
            <select
              id="status"
              className="form-select"
              value={searchParams.status || ''}
              onChange={(e) => handleInputChange('status', e.target.value)}
            >
              <option value="">All Books</option>
              <option value="own">Owned</option>
              <option value="love">Loved</option>
              <option value="want to read">Want to Read</option>
            </select>
          </div>
          
          <div className="form-group">
            <label htmlFor="page">Page</label>
            <input
              id="page"
              type="number"
              className="form-input"
              value={searchParams.page || 1}
              onChange={(e) => handleInputChange('page', parseInt(e.target.value) || 1)}
              min="1"
            />
          </div>
          
          <div className="form-group">
            <label htmlFor="pageSize">Items per page</label>
            <input
              id="pageSize"
              type="number"
              className="form-input"
              value={searchParams.pageSize || 10}
              onChange={(e) => handleInputChange('pageSize', parseInt(e.target.value) || 10)}
              min="1"
              max="100"
            />
          </div>
          
          <div className="form-group">
            <button
              className="search-button"
              onClick={handleSearch}
              disabled={loading}
            >
              {loading ? (
                <>
                  <span className="loading-spinner"></span>
                  Searching...
                </>
              ) : (
                'Search Books'
              )}
            </button>
          </div>
        </div>
      </div>

      {error && (
        <div className="error-message">
          <span className="error-icon">⚠️</span>
          {error}
        </div>
      )}

      {hasSearched && (
        <div className="results-container">
          {books.length > 0 ? (
            <>
              <div className="results-header">
                <h2 className="results-title">Search Results</h2>
                <span className="results-count">{total} books found</span>
              </div>
              
              <div className="books-grid">
                {books.map((book) => {
                  const statusInfo = book.ownershipStatus ? getStatusBadge(book.ownershipStatus) : null;
                  return (
                    <div key={book.id} className="book-card">
                      <h3 className="book-title">{book.title}</h3>
                      {statusInfo && (
                        <span className={`status-badge ${statusInfo.class}`}>{statusInfo.label}</span>
                      )}
                      
                      <div className="book-detail">
                        <span className="book-detail-label">Author:</span>
                        <span className="book-detail-value">{book.authors}</span>
                      </div>
                      
                      {book.publisher && (
                        <div className="book-detail">
                          <span className="book-detail-label">Publisher:</span>
                          <span className="book-detail-value">{book.publisher}</span>
                        </div>
                      )}
                      
                      {book.isbn && (
                        <div className="book-detail">
                          <span className="book-detail-label">ISBN:</span>
                          <span className="book-detail-value">{book.isbn}</span>
                        </div>
                      )}
                      
                      {book.category && (
                        <div className="book-detail">
                          <span className="book-detail-label">Category:</span>
                          <span className="book-detail-value">{book.category}</span>
                        </div>
                      )}
                      
                      {book.type && (
                        <div className="book-detail">
                          <span className="book-detail-label">Type:</span>
                          <span className="book-detail-value">{book.type}</span>
                        </div>
                      )}
                      
                      <div className="book-detail">
                        <span className="book-detail-label">Available:</span>
                        <span className="book-detail-value">{book.availableCopies}</span>
                      </div>
                    </div>
                  );
                })}
              </div>
            </>
          ) : (
            <div className="empty-state">
              <div className="empty-state-icon">📚</div>
              <p className="empty-state-text">No books found matching your criteria</p>
            </div>
          )}
        </div>
      )}
    </div>
  );
};

export default BookSearch;
