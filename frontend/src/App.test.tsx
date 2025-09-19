import React from 'react';
import { render, screen } from '@testing-library/react';
import App from './App';

test('renders Royal Library header', () => {
  render(<App />);
  const headerElement = screen.getByText(/Royal Library/i);
  expect(headerElement).toBeInTheDocument();
});
