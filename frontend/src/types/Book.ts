export interface Book {
  id: number;
  title: string;
  publisher?: string;
  authors: string;
  type?: string;
  isbn?: string;
  category?: string;
  availableCopies: string;
}

export interface BookSearchParams {
  author?: string;
  isbn?: string;
  status?: string;
  page?: number;
  pageSize?: number;
}

export interface PagedResult<T> {
  items: T[];
  total: number;
  page: number;
  pageSize: number;
}
