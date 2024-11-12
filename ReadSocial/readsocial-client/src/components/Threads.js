import React, { useState, useEffect } from 'react';

const Threads = () => {
    const [threads, setThreads] = useState([]);
    const [title, setTitle] = useState('');
    const [description, setDescription] = useState('');

    // Cargar hilos al montar el componente
    useEffect(() => {
        displayThreads();
    }, []);

    // Función para obtener y mostrar hilos
    const displayThreads = async () => {
        const response = await fetch('http://localhost:3000/api/threads');
        const data = await response.json();
        setThreads(data);
    };

    // Función para crear un nuevo hilo
    const createThread = async (e) => {
        e.preventDefault();
        const response = await fetch('http://localhost:3000/api/threads', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ title, description })
        });
        if (response.ok) {
            setTitle('');
            setDescription('');
            displayThreads();
        } else {
            console.error('Error al crear el hilo');
        }
    };

    // Función para eliminar un hilo
    const deleteThread = async (id) => {
        await fetch(`http://localhost:3000/api/threads/${id}`, { method: 'DELETE' });
        displayThreads();
    };

    return (
        <div>
            <form onSubmit={createThread}>
                <input
                    type="text"
                    placeholder="Título del Hilo"
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}
                    required
                />
                <textarea
                    placeholder="Descripción del Hilo"
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                ></textarea>
                <button type="submit">Crear Hilo</button>
            </form>
            <div id="threadsList">
                {threads.map(thread => (
                    <div key={thread.ThreadId}>
                        <h3>{thread.Title}</h3>
                        <p>{thread.Description}</p>
                        <button onClick={() => deleteThread(thread.ThreadId)}>Eliminar</button>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default Threads;
