import React from 'react';

const Thread = ({ thread }) => {
  return (
    <div>
      <h3>{thread.title}</h3>
      <p>Author: {thread.author}</p>
      <p>{thread.posts.length} Posts</p>
    </div>
  );
};

export default Thread;