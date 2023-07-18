import { render, screen } from '@testing-library/react';
import App from './App';

test('renders articles header', () => {
    render(<App />);
    const linkElement = screen.getByText(/Articles/i);
    expect(linkElement).toBeInTheDocument();
});
