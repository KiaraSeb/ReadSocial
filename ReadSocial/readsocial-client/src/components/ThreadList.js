import React, { useEffect, useState } from 'react';
import { fetchThreads } from '../services/api';

const ThreadList = () => {
  const [threads, setThreads] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const getThreads = async () => {
      try {
        const response = await fetchThreads();
        setThreads(response.data);
      } catch (error) {
        console.error("Error al obtener los hilos:", error);
      } finally {
        setLoading(false);
      }
    };

    getThreads();
  }, []);

  if (loading) return <p>Cargando hilos...</p>;

  return (
    <div>
      <h2>Hilos de Discusión</h2>
      {threads.length === 0 ? (
        <p>No hay hilos disponibles.</p>
      ) : (
        threads.map((thread) => (
          <div key={thread.id}>
            <h3>{thread.title}</h3>
            <p>{thread.description}</p>
          </div>
        ))
      )}
    </div>
  );
};

export default ThreadList;
