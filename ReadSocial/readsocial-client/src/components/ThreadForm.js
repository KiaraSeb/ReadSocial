import React, { useState } from 'react';
import { createThread } from '../services/api';

const ThreadForm = ({ onNewThread }) => {
  const [title, setTitle] = useState('');
  const [description, setDescription] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const response = await createThread({ title, description });
      onNewThread(response.data);  // Actualiza la lista de hilos
      setTitle('');
      setDescription('');
    } catch (error) {
      console.error("Error al crear el hilo:", error);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <h2>Crear un Nuevo Hilo</h2>
      <input
        type="text"
        placeholder="Título"
        value={title}
        onChange={(e) => setTitle(e.target.value)}
        required
      />
      <textarea
        placeholder="Descripción"
        value={description}
        onChange={(e) => setDescription(e.target.value)}
        required
      />
      <button type="submit">Crear Hilo</button>
    </form>
  );
};

export default ThreadForm;
