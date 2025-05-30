import React from 'react';
import {
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
  Paper,
  TableContainer,
  Typography,
  Box,
  Button,
  Stack,
} from '@mui/material';
import { PagedResponse } from '../models/pagedresponse';
import { Book } from '../models/book';

interface Props {
  results: PagedResponse<Book> | null;
  onPageChange?: (page: number) => void;
}

const tableHeaders = [
  'Book Title',
  'Authors',
  'Type',
  'ISBN',
  'Category',
  'Available Copies',
];

const ResultGrid: React.FC<Props> = ({ results, onPageChange }) => {
  const books = results?.responseList ?? [];
  const pageNumber = results?.pageNumber ?? 1;
  const totalPages = results?.totalPages ?? 1;

  return (
    <TableContainer component={Paper} sx={{ mt: 4 }}>
      <Typography variant="h6" sx={{ p: 2 }}>
        Search Results
      </Typography>

      {results && (
        <Box sx={{ px: 2, pb: 2 }}>
          <Typography variant="body2">
            Page: <b>{results.pageNumber}</b> of <b>{results.totalPages}</b> | 
            Items per page: <b>{results.pageSize}</b> | 
            Total Items: <b>{results.totalItems}</b>
          </Typography>
          <Stack direction="row" spacing={2} justifyContent="center" sx={{ mt: 2 }}>
            <Button
              variant="outlined"
              size="small"
              disabled={pageNumber <= 1}
              onClick={() => onPageChange && onPageChange(pageNumber - 1)}
            >
              Previous
            </Button>
            <Button
              variant="outlined"
              size="small"
              disabled={pageNumber >= totalPages}
              onClick={() => onPageChange && onPageChange(pageNumber + 1)}
            >
              Next
            </Button>
          </Stack>
        </Box>
      )}

      <Table size="small">
        <TableHead>
          <TableRow>
            {tableHeaders.map((header) => (
              <TableCell key={header} align="center"><b>{header}</b></TableCell>
            ))}
          </TableRow>
        </TableHead>
        <TableBody>
          {books.length === 0 ? (
            <TableRow>
              <TableCell colSpan={tableHeaders.length} align="center">
                No results found
              </TableCell>
            </TableRow>
          ) : (
            books.map((book) => (
              <TableRow key={book.isbn || book.title}>
                <TableCell align="center">{book.title}</TableCell>
                <TableCell align="center">
                  {`${book.firstName ?? ''} ${book.lastName ?? ''}`}
                </TableCell>
                <TableCell align="center">{book.type}</TableCell>
                <TableCell align="center">{book.isbn || '-'}</TableCell>
                <TableCell align="center">{book.category || '-'}</TableCell>
                <TableCell align="center">{`${book.copiesInUse}/${book.totalCopies}`}</TableCell>
              </TableRow>
            ))
          )}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

export default ResultGrid;