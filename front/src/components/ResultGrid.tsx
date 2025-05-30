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
            <TableCell>Book Title</TableCell>
            <TableCell>Authors</TableCell>
            <TableCell>Type</TableCell>
            <TableCell>ISBN</TableCell>
            <TableCell>Category</TableCell>
            <TableCell>Available Copies</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {books.length === 0 ? (
            <TableRow>
              <TableCell colSpan={7} align="center">
                No results found
              </TableCell>
            </TableRow>
          ) : (
            books.map((book, index) => (
              <TableRow key={index}>
                <TableCell>{book.title}</TableCell>
                <TableCell>{`${book.firstName} ${book.lastName}`}</TableCell>
                <TableCell>{book.type}</TableCell>
                <TableCell>{book.isbn || '-'}</TableCell>
                <TableCell>{book.category || '-'}</TableCell>
                <TableCell>{`${book.copiesInUse}/${book.totalCopies}`}</TableCell>
              </TableRow>
            ))
          )}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

export default ResultGrid;