import React from 'react';

const Post = ({ post }) => {
  return (
    <div>
      <p>{post.content}</p>
      <p>By: {post.author}</p>
    </div>
  );
};

export default Post;