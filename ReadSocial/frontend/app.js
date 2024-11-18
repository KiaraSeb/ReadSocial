// API endpoint
const API_URL = 'http://localhost:5000/api/forum';

// Función para obtener los hilos
async function getThreads() {
  try {
    const response = await fetch(`${API_URL}/threads`);
    const threads = await response.json();
    const threadsList = document.getElementById('threads-list');
    threadsList.innerHTML = '<h2>Hilos:</h2>';
    threads.forEach(thread => {
      const threadElement = document.createElement('div');
      threadElement.innerHTML = `
        <h3>${thread.title}</h3>
        <button onclick="getPosts(${thread.id})">Ver Posts</button>
      `;
      threadsList.appendChild(threadElement);
    });
  } catch (error) {
    console.error('Error al obtener los hilos:', error);
  }
}

// Función para obtener los posts de un hilo
async function getPosts(threadId) {
  try {
    const response = await fetch(`${API_URL}/threads/${threadId}/posts`);
    const posts = await response.json();
    const postsList = document.getElementById('posts-list');
    postsList.innerHTML = `<h2>Posts del Hilo ${threadId}</h2>`;
    posts.forEach(post => {
      const postElement = document.createElement('div');
      postElement.innerHTML = `
        <p><strong>${post.author}</strong>: ${post.content}</p>
      `;
      postsList.appendChild(postElement);
    });
  } catch (error) {
    console.error('Error al obtener los posts:', error);
  }
}

// Función para crear un nuevo hilo
document.getElementById('new-thread-form').addEventListener('submit', async (event) => {
  event.preventDefault();
  const title = document.getElementById('title').value;

  try {
    const response = await fetch(`${API_URL}/threads`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ title })
    });

    if (response.ok) {
      alert('Hilo creado con éxito');
      getThreads(); // Refrescar lista de hilos
    } else {
      alert('Error al crear el hilo');
    }
  } catch (error) {
    console.error('Error al crear el hilo:', error);
  }
});

// Función para crear un nuevo post
document.getElementById('new-post-form').addEventListener('submit', async (event) => {
  event.preventDefault();
  const author = document.getElementById('author').value;
  const content = document.getElementById('content').value;
  const threadId = 1; // En un caso real, este debería ser el ID del hilo actual

  try {
    const response = await fetch(`${API_URL}/posts`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ threadId, author, content })
    });

    if (response.ok) {
      alert('Post creado con éxito');
      getPosts(threadId); // Refrescar lista de posts
    } else {
      alert('Error al crear el post');
    }
  } catch (error) {
    console.error('Error al crear el post:', error);
  }
});

// Cargar los hilos cuando se carga la página
getThreads();
