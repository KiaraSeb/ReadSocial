// app.js
import { login, getProtectedData } from './api.js';

document.getElementById('loginForm').addEventListener('submit', async (e) => {
  e.preventDefault();
  const username = document.getElementById('username').value;
  const password = document.getElementById('password').value;

  try {
    const response = await login(username, password);
    if (response.token) {
      localStorage.setItem('token', response.token); // Guarda el token
      alert('Inicio de sesión exitoso');
    } else {
      alert('Credenciales incorrectas');
    }
  } catch (error) {
    console.error('Error en el inicio de sesión:', error);
  }
});

document.getElementById('fetchDataButton').addEventListener('click', async () => {
  const token = localStorage.getItem('token');
  if (!token) {
    alert('Por favor, inicia sesión primero');
    return;
  }

  try {
    const data = await getProtectedData(token);
    console.log('Datos protegidos:', data);
  } catch (error) {
    console.error('Error al obtener datos protegidos:', error);
  }
});
