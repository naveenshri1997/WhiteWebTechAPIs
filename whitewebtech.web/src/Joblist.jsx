
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
  
  
  export default function Joblist({ jobs }) {
    const joblistdata = jobs?.result || []; // Safely access jobs.result
  
    return (
      <div>
        <TableContainer
          component={Paper}
          sx={{ maxWidth: "1000px", margin: "auto", mt: 4 }}
        >
          <Typography variant="h4" align="center" gutterBottom>
            Job Listings
          </Typography>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell>
                  <strong>ID</strong>
                </TableCell>
                <TableCell>
                  <strong>Name</strong>
                </TableCell>
                <TableCell>
                  <strong>Title</strong>
                </TableCell>
                <TableCell>
                  <strong>Description</strong>
                </TableCell>
                <TableCell>
                  <strong>Active</strong>
                </TableCell>
                
              </TableRow>
            </TableHead>
            <TableBody>
              {joblistdata.length > 0 ? (
                joblistdata.map((job) => (
                  <TableRow key={job.id}>
                    <TableCell>{job.id}</TableCell>
                    <TableCell>{job.name}</TableCell>
                    <TableCell>{job.title}</TableCell>
                    <TableCell>{job.description}</TableCell>
                    <TableCell>
                      <Switch checked={job.isActive === "1"} disabled />
                    </TableCell>
                    
                  </TableRow>
                ))
              ) : (
                <TableRow>
                  <TableCell colSpan={6} align="center">
                    No job data available.
                  </TableCell>
                </TableRow>
              )}
            </TableBody>
          </Table>
        </TableContainer>
      </div>
    );
  }
  