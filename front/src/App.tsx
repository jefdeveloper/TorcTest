import React, { useEffect, useState } from 'react';
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

function App() {
  const [results, setResults] = useState<PagedResponse<Book> | null>(null);
  const [currentSearchBy, setCurrentSearchBy] = useState('');
  const [currentSearchValue, setCurrentSearchValue] = useState('');

  const handleSearch = async (searchBy: string, searchValue: string, page = 1) => {
    try {
      setCurrentSearchBy(searchBy);
      setCurrentSearchValue(searchValue);
      const url = `http://localhost:5000/books?${encodeURIComponent(searchBy)}=${encodeURIComponent(searchValue)}&page=${page}`;
      const response = await fetch(url);
      if (!response.ok) {
        throw new Error('API request failed');
      }
      const data: PagedResponse<Book> = await response.json();
      setResults(data);
    } catch (error) {
      setResults(null);
    }
  };

  useEffect(() => {
    handleSearch('title', '', 1);
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