
import React, { Component } from 'react';
import Post from './Post';
class Posts extends Component {
constructor(props) {
super(props);
this.state = {
posts: [],
hasError: false,
errorMessage: ''
};
}
loadPosts() {
fetch('https://jsonplaceholder.typicode.com/posts')
.then(res => res.json())
.then(data => this.setState({ posts: data }))
.catch(error => {
this.setState({ hasError: true, errorMessage: error.message });
});
}
componentDidMount() {
this.loadPosts();
}
componentDidCatch(error, info) {
this.setState({ hasError: true, errorMessage: error.toString() });
alert('An error occurred: ' + error.toString());
}
render() {
if (this.state.hasError) {
return <div>Error: {this.state.errorMessage}</div>;
}
return (
<div>
<h1>Blog Posts</h1>
{this.state.posts.map(post => (
<Post key={post.id} title={post.title} body={post.body} />
))}
</div>
);}}
export default Posts;