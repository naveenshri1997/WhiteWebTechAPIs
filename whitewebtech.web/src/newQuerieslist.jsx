import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  Typography,
  Switch,
} from "@mui/material";
import React from "react";


export default function newQuerieslist({ newQueries }) {
  const querieslistdata = newQueries?.result || []; // Safely access jobs.result

  return (
    <div>
      <TableContainer
        component={Paper}
        sx={{ maxWidth: "1000px", margin: "auto", mt: 4 }}
      >
        <Typography variant="h4" align="center" gutterBottom>
          Query Listings
        </Typography>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>
                <strong>ID</strong>
              </TableCell>
              <TableCell>
                <strong>firstName</strong>
              </TableCell>
              <TableCell>
                <strong>lastName</strong>
              </TableCell>
              <TableCell>
                <strong>Email</strong>
              </TableCell>
              <TableCell>
                <strong>Mobile</strong>
              </TableCell>
              <TableCell>
                <strong>Query</strong>
              </TableCell>
              
            </TableRow>
          </TableHead>
          <TableBody>
            {querieslistdata.length > 0 ? (
              querieslistdata.map((query) => (
                <TableRow key={query.id}>
                  <TableCell>{query.id}</TableCell>
                  <TableCell>{query.firstName}</TableCell>
                  <TableCell>{query.lastName}</TableCell>
                  <TableCell>{query.email}</TableCell>
                  <TableCell>{query.mobile}</TableCell>
                  <TableCell>
                    {query.query} 
                  </TableCell>
                  
                </TableRow>
              ))
            ) : (
              <TableRow>
                <TableCell colSpan={6} align="center">
                  No Query data available.
                </TableCell>
              </TableRow>
            )}
          </TableBody>
        </Table>
      </TableContainer>
    </div>
  );
}


