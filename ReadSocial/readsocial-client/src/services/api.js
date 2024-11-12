import axios from 'axios';

const API_URL = 'http://localhost:5279/api';

const api = axios.create({
  baseURL: API_URL,
});

export const fetchThreads = () => api.get('/forum/threads');
export const createThread = (data) => api.post('/forum/threads', data);
export const createPost = (threadId, data) => api.post(`/forum/threads/${threadId}/posts`, data);

export default api;
