import { render, screen } from '@testing-library/react';
import App from './App';

test('renders score calculator heading', () => {
  render(<App />);
  const headingElement = screen.getByText(/Student Score Calculator/i);
  expect(headingElement).toBeInTheDocument();
});
