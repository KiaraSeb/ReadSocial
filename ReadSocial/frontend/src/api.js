// api.js
const API_URL = 'https://localhost:5001/api'; // Cambia esto si tu API tiene una ruta diferente

export async function login(username, password) {
  const response = await fetch(`${API_URL}/auth/login`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify({ username, password }),
  });

  if (!response.ok) {
    throw new Error('Error en el inicio de sesión');
  }

  return await response.json();
}

export async function getProtectedData(token) {
  const response = await fetch(`${API_URL}/protected`, {
    method: 'GET',
    headers: {
      'Authorization': `Bearer ${token}`,
    },
  });

  if (!response.ok) {
    throw new Error('Error al obtener datos protegidos');
  }

  return await response.json();
}