import React, { useState } from 'react';
import {
  Box,
  Button,
  FormControl,
  InputLabel,
  MenuItem,
  Paper,
  Select,
  SelectChangeEvent,
  TextField,
  Typography,
} from '@mui/material';

type SearchPanelProps = {
  onSearch: (searchBy: string, searchValue: string) => void;
};

const SearchPanel: React.FC<SearchPanelProps> = ({ onSearch }) => {
  const [searchBy, setSearchBy] = useState('');
  const [searchValue, setSearchValue] = useState('');
  const [error, setError] = useState('');

  const handleSearchByChange = (event: SelectChangeEvent) => {
    setSearchBy(event.target.value);
    setError('');
  };

  const handleSearch = () => {
    if (searchBy !== '' && searchBy !== 'None' && searchValue.trim() === '') {
      setError('Please enter a value to search.');
      return;
    }
    setError('');
    onSearch(searchBy, searchValue);
  };

  const handleReset = () => {
    setSearchBy('');
    setSearchValue('');
    setError('');
    onSearch('', '');
  };

  const searchOptions = [
    { value: '', label: 'None' },
    { value: 'title', label: 'Title' },
    { value: 'authors', label: 'Authors' },
    { value: 'type', label: 'Type' },
    { value: 'isbn', label: 'ISBN' },
    { value: 'category', label: 'Category' },
    { value: 'copiesInUse', label: 'Copies In Use' },
    { value: 'totalCopies', label: 'Total Copies' },
  ];

  const isInputRequired = searchBy !== '' && searchBy !== 'None';
  const isInputEmpty = searchValue.trim() === '';

  return (
    <Paper elevation={1} sx={{ p: 3, maxWidth: 600, mx: 'auto', borderRadius: 2 }}>
      <Box display="flex" flexDirection="column" gap={2}>
        <Box display="flex" alignItems="center" gap={2}>
          <Typography minWidth={120}>Search By:</Typography>
          <FormControl fullWidth size="small" error={!!error && isInputRequired && isInputEmpty}>
            <InputLabel id="search-by-label">Select</InputLabel>
            <Select
              labelId="search-by-label"
              value={searchBy}
              label="Select"
              onChange={handleSearchByChange}
            >
              {searchOptions.map((option) => (
                <MenuItem key={option.value} value={option.value}>
                  {option.label}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
        </Box>

        <Box display="flex" alignItems="center" gap={2}>
          <Typography minWidth={120}>Search Value:</Typography>
          <TextField
            variant="outlined"
            size="small"
            fullWidth
            value={searchValue}
            onChange={(e) => {
              setSearchValue(e.target.value);
              setError('');
            }}
            error={!!error && isInputRequired && isInputEmpty}
            helperText={!!error && isInputRequired && isInputEmpty ? error : ''}
            disabled={!isInputRequired}
          />
        </Box>

        <Box display="flex" justifyContent="center" gap={2}>
          <Button variant="outlined" onClick={handleSearch}>
            Search
          </Button>
          <Button variant="outlined" color="secondary" onClick={handleReset}>
            Reset
          </Button>
        </Box>
      </Box>
    </Paper>
  );
};

export default SearchPanel;