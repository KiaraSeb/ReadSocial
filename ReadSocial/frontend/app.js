// Manejar la creación de un hilo
document.getElementById("new-thread-form").addEventListener("submit", async function(event) {
  event.preventDefault(); // Prevenir recarga de la página

  const title = document.getElementById("title").value;

  // Enviar la solicitud para crear el hilo
  const response = await fetch("/api/threads", {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify({ title })
  });

  if (response.ok) {
    const thread = await response.json(); // Obtener el hilo creado
    const threadsList = document.querySelector("#threads-list ul");

    // Crear un nuevo elemento en la lista para el hilo
    const li = document.createElement("li");
    li.textContent = thread.title; // Solo mostrar el título del hilo
    threadsList.appendChild(li); // Agregar el hilo a la lista
  } else {
    alert("Error al crear el hilo");
  }
});

// Manejar la creación de un post
document.getElementById("new-post-form").addEventListener("submit", async function(event) {
  event.preventDefault(); // Prevenir recarga de la página

  const author = document.getElementById("author").value;
  const content = document.getElementById("content").value;

  // Enviar la solicitud para crear el post
  const response = await fetch("/api/posts", {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify({ author, content })
  });

  if (response.ok) {
    const post = await response.json(); // Obtener el post creado
    const postsList = document.querySelector("#posts-list ul");

    // Crear un nuevo elemento en la lista para el post
    const li = document.createElement("li");
    li.textContent = `${post.author}: ${post.content}`; // Mostrar el autor y contenido del post
    postsList.appendChild(li); // Agregar el post a la lista
  } else {
    alert("Error al crear el post");
  }
});
