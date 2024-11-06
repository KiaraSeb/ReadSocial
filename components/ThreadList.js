import React from 'react';
import Thread from './Thread';

const ThreadList = ({ threads }) => {
  return (
    <div>
      <h2>Threads</h2>
      {threads.map(thread => (
        <Thread key={thread.id} thread={thread} />
      ))}
    </div>
  );
};

export default ThreadList;