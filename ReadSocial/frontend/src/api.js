// api.js
import API_BASE_URL from './config.js';

export const login = async (username, password) => {
    const response = await fetch(`${API_BASE_URL}/auth/login`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ username, password }),
    });
    return response.json();
};

export const getProtectedData = async (token) => {
    const response = await fetch(`${API_BASE_URL}/protected-route`, {
        method: 'GET',
        headers: {
            Authorization: `Bearer ${token}`,
        },
    });
    return response.json();
};
