

// import {
//   Table,
//   TableBody,
//   TableCell,
//   TableContainer,
//   TableHead,
//   TableRow,
//   Paper,
//   Typography,
// } from "@mui/material";
// import React from "react";

// export default function ApplicantList({ applicants }) {
//   const applicantlistdata = applicants?.result || [];// Safely access applicants

//   return (
//     <div>
//       <TableContainer
//         component={Paper}
//         sx={{ maxWidth: "1000px", margin: "auto", mt: 4 }}
//       >
//         <Typography variant="h4" align="center" gutterBottom>
//           Applicant Listings
//         </Typography>
//         <Table>
//           <TableHead>
//             <TableRow>
//               <TableCell>
//                 <strong>ID</strong>
//               </TableCell>
//               <TableCell>
//                 <strong>Applicant Name</strong>
//               </TableCell>
//               <TableCell>
//                 <strong>Applicant Description</strong>
//               </TableCell>
//               <TableCell>
//                 <strong>Applicant State</strong>
//               </TableCell>
//               <TableCell>
//                 <strong>CV</strong>
//               </TableCell>
//             </TableRow>
//           </TableHead>
//           <TableBody>
//             {applicantlistdata.length > 0 ? (
//               applicantlistdata.map((Applicant) => (
//                 <TableRow key={Applicant.id}>
//                   <TableCell>{Applicant.id}</TableCell> {/* Show Applicant ID */}
//                   <TableCell>{Applicant.ApplicantName}</TableCell>
//                   <TableCell>{Applicant.ApplicantDescription}</TableCell>
//                   <TableCell>{Applicant.ApplicantState}</TableCell>
//                   <TableCell>{Applicant.CV}</TableCell>
//                 </TableRow>
//               ))
//             ) : (
//               <TableRow>
//                 <TableCell colSpan={5} align="center">
//                   No applicant data available.
//                 </TableCell>
//               </TableRow>
//             )}
//           </TableBody>
//         </Table>
//       </TableContainer>
//     </div>
//   );
// }

import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  Typography,
} from "@mui/material";
import React from "react";

export default function ApplicantList({ applicants }) {
  const applicantlistdata = applicants?.result || []; // Adjust this based on actual API response structure

  return (
    <div>
      <TableContainer
        component={Paper}
        sx={{ maxWidth: "1000px", margin: "auto", mt: 4 }}
      >
        <Typography variant="h4" align="center" gutterBottom>
          Applicant Listings
        </Typography>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell><strong>ID</strong></TableCell>
              <TableCell><strong>Applicant Name</strong></TableCell>
              <TableCell><strong>Applicant Description</strong></TableCell>
              <TableCell><strong>Applicant State</strong></TableCell>
              <TableCell><strong>CV</strong></TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {applicantlistdata.length > 0 ? (
              applicantlistdata.map((Applicant) => (
                <TableRow key={Applicant.id}>
                  <TableCell>{Applicant.id}</TableCell>
                  <TableCell>{Applicant.ApplicantName}</TableCell>
                  <TableCell>{Applicant.ApplicantDescription}</TableCell>
                  <TableCell>{Applicant.ApplicantState}</TableCell>
                  <TableCell>{Applicant.CV}</TableCell>
                </TableRow>
              ))
            ) : (
              <TableRow>
                <TableCell colSpan={5} align="center">
                  No applicant data available.
                </TableCell>
              </TableRow>
            )}
          </TableBody>
        </Table>
      </TableContainer>
    </div>
  );
}
