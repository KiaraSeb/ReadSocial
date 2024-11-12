const express = require('express');
const cors = require('cors');
const threadsRoutes = require('./routes/threads'); // Ruta de threads
const app = express();

app.use(cors()); // Para manejar CORS
app.use(express.json());
app.use('/api', threadsRoutes); // Endpoint para threads

app.listen(3000, () => console.log('Servidor corriendo en el puerto 3000'));
