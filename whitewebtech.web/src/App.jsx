

import { useState, useEffect } from "react";
import reactLogo from "./assets/react.svg";
import viteLogo from "/vite.svg";
import { getAll, getById, postData, updateData, deleteData } from "./redux/api";
import Joblist from "./Joblist";
import Newapplicantlist from "./applicantlist"; 
import Querylist from "./newQuerieslist"
import './App.css';


function App() {
  // State variables to hold fetched data
  const [jobs, setJobs] = useState([]);
  const [applicants, setApplicants] = useState([]);
  const [newQueries, setNewQueries] = useState([]);

  // Fetch data on component mount
  useEffect(() => {
    fetchJobsData();
    fetchApplicantsData();
    fetchNewQueriesData();
  }, []);

  // Function to fetch job data
  const fetchJobsData = async () => {
    try {
      const result = await getAll("api/Jobs/GetAll");
      setJobs(result);
    } catch (error) {
      console.error("Error fetching job data:", error);
    }
  };

  // Function to fetch applicant data
  const fetchApplicantsData = async () => {
    try {
      const result = await getAll("api/Applicant/GetAll");
      setApplicants(result);
    } catch (error) {
      console.error("Error fetching applicant data:", error);
    }
  };

  // Function to fetch new query data
  const fetchNewQueriesData = async () => {
    try {
      const result = await getAll("api/NewQuery/GetAll");
      setNewQueries(result);
    } catch (error) {
      console.error("Error fetching new query data:", error);
    }
  };

  return (
    <div className="App">
      {/* Render Job List */}
      <Joblist jobs={jobs} />

      {/* Render Applicant List */}
      <Newapplicantlist applicants={applicants} />

      {/* Render New Query List */}
      {/* <Newquerylist newQueries={newQueries} /> */}
      <Querylist newQueries={newQueries} />

    </div>
  );
}

export default App;
