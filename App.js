// src/App.js
import React, { useState, useEffect } from 'react';
import ThreadList from 'C:\Users\amito\Desktop\ReadSocial\components\ThreadList';

const App = () => {
  const [threads, setThreads] = useState([]);

  useEffect(() => {
    // Aquí realizarías una solicitud al backend para obtener los threads
    fetch('/api/threads')  // Asegúrate de que esta ruta coincida con tu backend
      .then(response => response.json())
      .then(data => setThreads(data))
      .catch(error => console.error('Error fetching threads:', error));
  }, []);

  return (
    <div>
      <h1>Forum</h1>
      <ThreadList threads={threads} />
    </div>
  );
};

export default App;
