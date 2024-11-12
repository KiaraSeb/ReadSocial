import React, { useState } from 'react';
import ThreadList from './components/ThreadList';
import ThreadForm from './components/ThreadForm';

function App() {
  const [threads, setThreads] = useState([]);

  const handleNewThread = (newThread) => {
    setThreads((prevThreads) => [newThread, ...prevThreads]);
  };

  return (
    <div className="App">
      <h1>Foro ReadSocial</h1>
      <ThreadForm onNewThread={handleNewThread} />
      <ThreadList />
    </div>
  );
}

export default App;
