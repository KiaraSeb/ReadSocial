const express = require('express');
const router = express.Router();
const Thread = require('../models/Thread'); // Importa el modelo de Thread

// Crear un hilo
router.post('/threads', async (req, res) => {
    try {
        const { title, description } = req.body;
        const newThread = await Thread.create({ Title: title, Description: description });
        res.status(201).json(newThread);
    } catch (error) {
        res.status(500).json({ error: 'Error al crear el hilo' });
    }
});

// Obtener todos los hilos
router.get('/threads', async (req, res) => {
    try {
        const threads = await Thread.findAll();
        res.json(threads);
    } catch (error) {
        res.status(500).json({ error: 'Error al obtener los hilos' });
    }
});

// Eliminar un hilo
router.delete('/threads/:id', async (req, res) => {
    try {
        const { id } = req.params;
        await Thread.destroy({ where: { ThreadId: id } });
        res.status(204).send();
    } catch (error) {
        res.status(500).json({ error: 'Error al eliminar el hilo' });
    }
});

module.exports = router;
