import axios from 'axios';
import { Book, BookSearchParams, PagedResult } from '../types/Book';

const API_BASE_URL = 'http://localhost:5000/api';

export const BookService = {
  async searchBooks(params: BookSearchParams): Promise<PagedResult<Book>> {
    const response = await axios.get(`${API_BASE_URL}/books`, { params });
    return response.data;
  }
};
