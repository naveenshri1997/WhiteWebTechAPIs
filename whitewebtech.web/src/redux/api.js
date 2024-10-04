// src/api.js
import axios, { Axios } from 'axios';



// export const axios = new Axios({
//   url : 'https://localhost:7065/'

// })

// Base URL for your API
const BASE_URL = 'https://localhost:7065'

// Generic GET All Data
export const getAll = async (endpoint) => {
  try {
    const response = await axios.get(`${BASE_URL}/${endpoint}`);
    return response.data;
  } catch (error) {
    console.error('Error fetching data:', error);
    throw error;
  }
};

// Generic GET by ID
export const getById = async (endpoint, id) => {
  try {
    const response = await axios.get(`${BASE_URL}/${endpoint}/${id}`);
    return response.data;
  } catch (error) {
    console.error('Error fetching data by ID:', error);
    throw error;
  }
};

// Generic POST Data
export const postData = async (endpoint, data) => {
  try {
    const response = await axios.post(`${BASE_URL}/${endpoint}`, data);
    return response.data;
  } catch (error) {
    console.error('Error posting data:', error);
    throw error;
  }
};

// Generic UPDATE Data
export const updateData = async (endpoint, id, data) => {
  try {
    const response = await axios.put(`${BASE_URL}/${endpoint}/${id}`, data);
    return response.data;
  } catch (error) {
    console.error('Error updating data:', error);
    throw error;
  }
};

// Generic DELETE Data
export const deleteData = async (endpoint, id) => {
  try {
    const response = await axios.delete(`${BASE_URL}/${endpoint}/${id}`);
    return response.data;
  } catch (error) {
    console.error('Error deleting data:', error);
    throw error;
  }
};
