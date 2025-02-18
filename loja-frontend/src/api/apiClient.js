import axios from 'axios';

const apiClient = axios.create({
  baseURL: 'https://api.exemplo.com',
  headers: {
    'Content-Type': 'application/json',
  },
});

export default apiClient;
