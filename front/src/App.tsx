import { useEffect, useState } from 'react';
import { createTheme } from '@mui/material/styles';
import MenuBookIcon from '@mui/icons-material/MenuBook';
import { AppProvider } from '@toolpad/core/AppProvider';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import { Container } from '@mui/material';
import { PagedResponse } from './models/pagedresponse';
import { Book } from './models/book';
import ResultGrid from './components/ResultGrid';
import SearchPanel from './components/SearchPanel';

const demoTheme = createTheme({
  colorSchemes: { light: true, dark: true },
  cssVariables: {
    colorSchemeSelector: 'class',
  },
  breakpoints: {
    values: {
      xs: 0,
      sm: 600,
      md: 600,
      lg: 1200,
      xl: 1536,
    },
  },
});

const API_BASE_URL = 'http://localhost:5000';

function App() {
  // Inicializa busca por título como padrão
  const [results, setResults] = useState<PagedResponse<Book> | null>(null);
  const [currentSearchBy, setCurrentSearchBy] = useState('title');
  const [currentSearchValue, setCurrentSearchValue] = useState('');
  const [errorMessage, setErrorMessage] = useState('');

  // Função para buscar livros
  const handleSearch = async (searchBy: string, searchValue: string, page = 1) => {
    try {
      setCurrentSearchBy(searchBy);
      setCurrentSearchValue(searchValue);
      setErrorMessage('');
      const url = `${API_BASE_URL}/books?${encodeURIComponent(searchBy)}=${encodeURIComponent(searchValue)}&page=${page}`;
      const response = await fetch(url);
      if (!response.ok) {
        throw new Error('API request failed');
      }
      const data: PagedResponse<Book> = await response.json();
      setResults(data);
    } catch (error: unknown) {
      setResults(null);
      setErrorMessage('Failed to fetch books. Please try again.');
    }
  };

  // Busca inicial ao montar o componente
  useEffect(() => {
    handleSearch('', '', 1);
  }, []);

  return (
    <AppProvider theme={demoTheme}>
      <AppBar position="static">
        <Toolbar>
          <MenuBookIcon sx={{ mr: 1 }} />
          <Typography variant="h6">Royal Library</Typography>
        </Toolbar>
      </AppBar>
      <Container sx={{ mt: 5 }}>
        <SearchPanel onSearch={handleSearch} />
        {errorMessage && (
          <Typography color="error" sx={{ mt: 2 }}>
            {errorMessage}
          </Typography>
        )}
      </Container>
      <Container sx={{ mt: 5 }}>
        <ResultGrid
          results={results}
          onPageChange={(page) =>
            handleSearch(currentSearchBy, currentSearchValue, page)
          }
        />
      </Container>
    </AppProvider>
  );
}

export default App;