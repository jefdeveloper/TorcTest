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
} from '@mui/material';
import { PagedResponse } from '../models/pagedresponse';
import { Book } from '../models/book';


interface Props {
  results: PagedResponse<Book> | null;
}

const ResultGrid: React.FC<Props> = ({ results }) => {
  const books = results?.responseList ?? [];

  return (
    <TableContainer component={Paper} sx={{ mt: 4 }}>
      <Typography variant="h6" sx={{ p: 2 }}>
        Search Results
      </Typography>

      {results && (
        <Box sx={{ px: 2, pb: 2 }}>
          <Typography variant="body2">
            Page: <b>{results.pageNumber}</b> of <b>{results.totalPages}</b> | 
            Itens per page: <b>{results.pageSize}</b> | 
            Total Itens: <b>{results.totalItems}</b>
          </Typography>
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
                <TableCell>{book.Title}</TableCell>
                <TableCell>{`${book.FirstName} ${book.LastName}`}</TableCell>
                <TableCell>{book.Type}</TableCell>
                <TableCell>{book.Isbn || '-'}</TableCell>
                <TableCell>{book.Category || '-'}</TableCell>
                <TableCell>{`${book.CopiesInUse}/${book.TotalCopies}`}</TableCell>
              </TableRow>
            ))
          )}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

export default ResultGrid;